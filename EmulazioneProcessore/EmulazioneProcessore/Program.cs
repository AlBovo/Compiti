using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

#define WINDOWS

namespace EmulazioneProcessore
{
    internal class Program
    {
        const ushort MaxValue = 1 << 15;
        static ushort[] RAM = new ushort[32768];
        static ushort[] registers = new ushort[8];
        static ushort pc = 0;
        static Stack<ushort> stack = new Stack<ushort>();

        static bool IsRegister(ushort addr)
        {
            return addr >= (1 << 15) && addr <= (1 << 15) + 7;
        }

        /*
         * Return code 0: exit code
         * Return code 1: ok code
         * Return code 2: overflow code
         */

        /*
         * Manda in blocco il microprocessore emulato, provocando la terminazione del programma di emulazione.
         */
        static int Halt()
        {
            return 0;
        }

        /*
         * Assegna all’operando op1 il valore dato dall’operando op2
         */
        static int Set(ushort op1, ushort op2)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            registers[op1 % MaxValue] = (IsRegister(op2) ? registers[op2 % MaxValue] : op2);
            return 1;
        }

        /*
         * Inserisce in cima allo stack il valore op1
         */
        static int Push(ushort op1)
        {
            stack.Push(IsRegister(op1) ? registers[op1 % MaxValue] : op1);   
            return 1;
        }

        /*
         * Estrae un valore dalla cima dello stack e lo assegna all’operando op1
         */
        static int Pop(ushort op1)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("Error: the stack is empty");
                return Halt();
            }

            registers[op1 % MaxValue] = stack.Pop();            
            return 1;
        }

        /*
         * Verifica per uguaglianza di op2 con op3
         */
        static int Equal(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;

            registers[op1 % MaxValue] = (ushort)((op2 == op3) ? 1 : 0);
            return 1;
        }

        /*
         * Verifica per “maggiore di” fra op2 con op3
         */
        static int Greater(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;

            registers[op1 % MaxValue] = (ushort)((op2 > op3) ? 1 : 0);
            return 1;
        }

        /*
         * Salta in modo incondizionato all’indirizzo specificato da op1
         */
        static int Jump(ushort op1)
        {
            pc = IsRegister(op1) ? registers[op1 % MaxValue] : op1;
            return 1;
        }

        /*
         * Salta in modo condizionato “per vero” all’indirizzo specificato da op2
         */
        static int JumpTrue(ushort op1, ushort op2)
        {
            op1 = IsRegister(op1) ? registers[op1 % MaxValue] : op1;

            if (op1 != 0)
                pc = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            
            return 1;
        }

        /*
         * Salta in modo condizionato “per falso” all’indirizzo specificato da op2
         */
        static int JumpFalse(ushort op1, ushort op2)
        {
            op1 = IsRegister(op1) ? registers[op1 % MaxValue] : op1;

            if (op1 == 0)
                pc = IsRegister(op2) ? registers[op2 % MaxValue] : op2;

            return 1;
        }

        /*
         * Somma gli operandi op2 e op3 e mette il risultato in op1
         */
        static int Add(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;

            int code = 1;

            if ((uint)op2 + op3 >= MaxValue)
                code = 2;

            registers[op1 % MaxValue] = (ushort)((op2 + op3) % MaxValue);
            return code;
        }

        /*
         * Moltiplica gli operandi op2 e op3 e mette il risultato in op1
         */
        static int Multiply(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;

            int code = 1;

            if ((ulong)op2 * op3 >= MaxValue)
                code = 2;

            registers[op1 % MaxValue] = (ushort)((op2 * op3) % MaxValue);
            return code;
        }

        /*
         * Calcola i modulo (resto della divisione) fra gli operandi operandi op2 e op3 e mette il risultato in op1
         */
        static int Modulo(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;

            if (op3 == 0)
            {
                Console.WriteLine("Error: division by 0 is impossible");
                return Halt();
            }

            registers[op1 % MaxValue] = (ushort)(op2 % op3); // assert the modulo is < MaxValue
            return 1;
        }

        /*
         * Calcola il bitwise-and (and bit a bit) fra gli operandi op2 e op3 e mette il risultato in op1
         */
        static int AndBitwise(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;
            int code = 1;

            if ((op2 & op3) >= MaxValue)
                code = 2;

            registers[op1 % MaxValue] = (ushort)((op2 & op3) & ((1 << 15) - 1));
            return code;
        }

        /*
         * Calcola il bitwise-or (or bit a bit) fra gli operandi op2 e op3 e mette il risultato in op1
         */
        static int OrBitwise(ushort op1, ushort op2, ushort op3)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            op3 = IsRegister(op3) ? registers[op3 % MaxValue] : op3;
            int code = 1;

            if ((op2 | op3) >= MaxValue)
                code = 2;

            registers[op1 % MaxValue] = (ushort)((op2 | op3) & ((1 << 15) - 1));
            return code;
        }

        /*
         * Calcola il bitwise-not (complemento a uno o negazione bit per bit) dell’operando op2 e mette il risultato in op1
         */
        static int NotBitwise(ushort op1, ushort op2)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;
            int code = 1;

            if ((~op2) >= MaxValue)
                code = 2;

            registers[op1 % MaxValue] = (ushort)((~op2) & ((1 << 15) - 1));
            return code;
        }

        /*
         * Carica un valore dall’indirizzo di memoria specificato da op2 e lo memorizza nel registro op1
         */
        static int ReadMemory(ushort op1, ushort op2)
        {
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;

            registers[op1 % MaxValue] = RAM[op2];
            return 1;
        }

        /*
         * Scrive all’indirizzo di memoria specificato da op1 il valore di op2
         */
        static int WriteMemory(ushort op1, ushort op2)
        {
            op1 = IsRegister(op1) ? registers[op1 % MaxValue] : op1;
            if (op1 >= MaxValue)
            {
                Console.WriteLine("Error: the address is not valid");
                return Halt();
            }

            op2 = IsRegister(op2) ? registers[op2 % MaxValue] : op2;

            RAM[op1] = op2;
            return 1;
        }

        /*
         * Salta all’indirizzo indicato da op1 e inserisce in cima allo stack l'indirizzo dell’istruzione successiva alla call.
         */
        static int Call(ushort op1)
        {
            op1 = IsRegister(op1) ? registers[op1 % MaxValue] : op1;
            stack.Push(pc);
            pc = op1;
            return 1;
        }

        /*
         * Estrae un valore dalla cima dello stack e lo utilizza come indirizzo per l’istruzione successiva.
         */
        static int Return()
        {
            if(stack.Count == 0)
            {
                Console.WriteLine("Error: the stack is empty");
                return Halt();
            }

            pc = stack.Pop();
            return 1;
        }

        /*
         * Mostra a video il carattere ASCII corrispondente al valore indicato da op1.
         */
        static int Out(ushort op1)
        {
            int result;
            if (IsRegister(op1))
            {
                result = registers[op1 % MaxValue];
            }
            else if (op1 < 0 || op1 > 255)
            {
                Console.WriteLine("Error: the character you're trying to print is not valid");
                return Halt();
            }
            else
            {
                result = op1;
            }
            
            Console.Write((char)result);
            return 1;
        }

        /*
         * Acquisisce da input un carattere e ne pone il valore ASCII corrispondente in op1.
         */
        static int In(ushort op1)
        {
            int result;
            if (!IsRegister(op1))
            {
                Console.WriteLine("Error: the address must be a register");
                return Halt();
            }

            if ((result = Console.Read()) == -1)
            {
                Console.WriteLine("Error: there are no character to read");
                return Halt();
            }

            if (result == '\r')
                result = '\n';

            registers[op1 % MaxValue] = (ushort)result;
            return 1;
        }

        /*
         * Operazione nulla (no operation). Non fa nulla.
         */
        static int Nop()
        {
            return 1;
        }

        static ushort FetchByte()
        {
            return RAM[pc++];
        }

        static void ExecuteProgram()
        {
            while (true)
            {
                // Instruction Fetch
                ushort instr_addr = pc;
                ushort instr_code = FetchByte();
                ushort op1, op2, op3;

                // Instruction Decode + Execute
                switch (instr_code)
                {
                    case 0: // halt
                        throw new Exception($"Istruzione di halt all'indirizzo {instr_addr}");

                    case 1: // set op1, op2
                        op1 = FetchByte();
                        op2 = FetchByte();
                        //Debug.Print($"set {op1:X} {op2:X}");
                        Set(op1, op2);
                        break;

                    case 2: // push op1
                        op1 = FetchByte();
                        //Debug.Print($"push {op1:X}");
                        Push(op1);
                        break;

                    case 3: // pop
                        op1 = FetchByte();
                        //Debug.Print($"pop {op1:X}");
                        Pop(op1);
                        break;

                    case 4: // eq op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"eq {op1:X} {op2:X} {op3:X}");
                        Equal(op1, op2, op3);
                        break;

                    case 5: // gt op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"gt {op1:X} {op2:X} {op3:X}");
                        Greater(op1, op2, op3);
                        break;

                    case 6: // jump op1
                        op1 = FetchByte();
                        //Debug.Print($"jmp {op1:X}");
                        Jump(op1);
                        break;

                    case 7: // jt op1, op2
                        op1 = FetchByte();
                        op2 = FetchByte();
                        //Debug.Print($"jt {op1:X} {op2:X}");
                        JumpTrue(op1, op2);
                        break;

                    case 8: // jf op1, op2
                        op1 = FetchByte();
                        op2 = FetchByte();
                        //Debug.Print($"jf {op1:X} {op2:X}");
                        JumpFalse(op1, op2);
                        break;

                    case 9: // add op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"add {op1:X} {op2:X} {op3:X}");
                        Add(op1, op2, op3);
                        break;

                    case 10: // mult op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"mult {op1:X} {op2:X} {op3:X}");
                        Multiply(op1, op2, op3);
                        break;

                    case 11: // mod op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"mod {op1:X} {op2:X} {op3:X}");
                        Modulo(op1, op2, op3);
                        break;

                    case 12: // and op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"and {op1:X} {op2:X} {op3:X}");
                        AndBitwise(op1, op2, op3);
                        break;

                    case 13: // or op1, op2, op3
                        op1 = FetchByte();
                        op2 = FetchByte();
                        op3 = FetchByte();
                        //Debug.Print($"or {op1:X} {op2:X} {op3:X}");
                        OrBitwise(op1, op2, op3);
                        break;

                    case 14: // not op1, op2
                        op1 = FetchByte();
                        op2 = FetchByte();
                        //Debug.Print($"not {op1:X} {op2:X}");
                        NotBitwise(op1, op2);
                        break;

                    case 15: // rmem op1, op2
                        op1 = FetchByte();
                        op2 = FetchByte();
                        //Debug.Print($"rmem {op1:X} {op2:X}");
                        ReadMemory(op1, op2);
                        break;

                    case 16: // wmem op1, op2
                        op1 = FetchByte();
                        op2 = FetchByte();
                        //Debug.Print($"wmem {op1:X} {op2:X}");
                        WriteMemory(op1, op2);
                        break;

                    case 17: // call op1
                        op1 = FetchByte();
                        Call(op1);
                        //Debug.Print($"call {op1:X}");
                        break;

                    case 18: // ret
                        //Debug.Print($"ret");
                        Return();
                        break;

                    case 19: // out op1
                        op1 = FetchByte();
                        //Debug.Print($"out {op1:X}");
                        Out(op1);
                        break;

                    case 20: // in op1
                        op1 = FetchByte();
                        //Debug.Print($"in {op1:X}");
                        In(op1);
                        break;

                    case 21: // nop
                        //Debug.Print($"nop");
                        Nop();
                        break;

                    default:
                        throw new Exception($"Istruzione {instr_code} non valida all'indirizzo {instr_addr}");
                }
            }
        }

        static void DumpRAM(string file_name)
        {
            using (StreamWriter sw = new StreamWriter(file_name))
            {
                for (int i = 0; i < RAM.Length; i++)
                {
                    sw.WriteLine(RAM[i]);
                }
                sw.Close();
            }
        }

        static void LoadRAM(string file_name)
        {
            using (StreamReader sr = new StreamReader(file_name))
            {
                for (int i = 0; !sr.EndOfStream && i < RAM.Length; ++i)
                {
                    if (!ushort.TryParse(sr.ReadLine(), out RAM[i]))
                    {
                        throw new Exception($"Error parsng file '{file_name}' at line {i + 1}");
                    }
                }
                sr.Close();
            }
        }

        static void Main(string[] args)
        {
            #if WINDOWS
            string path = @"..\..\..\code.txt";
            #else
            string path = "../../code.txt";
            #endif
            
            LoadRAM(path);
            try
            {
                ExecuteProgram();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
