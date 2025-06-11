using System;
using System.Collections;

namespace Compito8
{
    internal class Program
    {
        static Array Merge(Array vett_A, Array vett_B)
        {
            if (vett_A.GetType().GetElementType() != vett_B.GetType().GetElementType())
                throw new Exception("Le array devono essere dello stesso tipo");

            Array.Sort(vett_A); Array.Sort(vett_B);
            Array array = Array.CreateInstance(vett_A.GetType().GetElementType(), vett_A.Length + vett_B.Length);
            int vett_A_index = 0, vett_B_index = 0;
            for(int i=0; i<vett_A.Length + vett_B.Length; i++)
            {
                if(vett_A_index == vett_A.Length)
                    array.SetValue(vett_B.GetValue(vett_B_index++), i);
                else if(vett_B_index == vett_B.Length)
                    array.SetValue(vett_A.GetValue(vett_A_index++), i);
                else if(Comparer.Default.Compare(vett_A.GetValue(vett_A_index), vett_B.GetValue(vett_B_index)) < 0)
                    array.SetValue(vett_A.GetValue(vett_A_index++), i);
                else
                    array.SetValue(vett_B.GetValue(vett_B_index++), i);
            }
            return array;
        }

        #region Merge di array di interi
        static void TestInt()
        {
            int[] vett_A = { 2, 1, 5, 9, 8 };
            Console.WriteLine("Vettore A: " + string.Join(" ", vett_A));
            int[] vett_B = { 4, 1, 6, 9, 2, 3, 1 };
            Console.WriteLine("Vettore B: " + string.Join(" ", vett_B));

            int[] vett_C = (int[])Merge(vett_A, vett_B);
            Console.Write("La fusione dei due vettori ordinata è: ");
            foreach (int i in vett_C)
                Console.Write(i + " ");
            Console.WriteLine();
        }
        #endregion

        #region Merge di array di double
        static void TestDouble()
        {
            double[] vett_A = { 2.1, 1.6, 5.9, 9.0, 8.5 };
            Console.WriteLine("Vettore A: " + string.Join(" ", vett_A));
            double[] vett_B = { 4.6, 3.1, 6.7, 9.3, 2.9, 3.0, 1.7 };
            Console.WriteLine("Vettore B: " + string.Join(" ", vett_B));

            double[] vett_C = (double[])Merge(vett_A, vett_B);
            Console.Write("La fusione dei due vettori ordinata è: ");
            foreach (double i in vett_C)
                Console.Write(i + " ");
            Console.WriteLine();
        }
        #endregion

        #region Merge di array di stringhe
        static void TestString()
        {
            string[] vett_A = { "prova", "vestito", "parola", "salmone", "shellcode", "buonanno" };
            Console.WriteLine("Vettore A: " + string.Join(" ", vett_A));
            string[] vett_B = { "armadio", "televisore", "bicicletta", "aereo", "felicità", "natale", "storia" };
            Console.WriteLine("Vettore B: " + string.Join(" ", vett_B));

            string[] vett_C = (string[])Merge(vett_A, vett_B);
            Console.Write("La fusione dei due vettori ordinata è: ");
            foreach (string i in vett_C)
                Console.Write(i + " ");
            Console.WriteLine();
        }
        #endregion

        #region Merge di due array con diverso tipo
        static void TestArray()
        {
            string[] vett_A = { "prova", "vestito", "parola", "salmone", "shellcode", "buonanno" };
            Console.WriteLine("Vettore A: " + string.Join(" ", vett_A));

            int[] vett_B = { 4, 1, 6, 9, 2, 3, 1 };
            Console.WriteLine("Vettore B: " + string.Join(" ", vett_B));

            try
            {
                Array vett_C = Merge(vett_A, vett_B);
                Console.Write("La fusione dei due vettori ordinata è: ");
                foreach (string i in vett_C)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Non è possibile fondere due array di tipo diverso");
            }
            
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Test di fusione di due array di interi");
            TestInt();
            Console.WriteLine("\nTest di fusione di due array di double");
            TestDouble();
            Console.WriteLine("\nTest di fusione di due array di stringhe");
            TestString();
            Console.WriteLine("\nTest di fusione di due array di tipo diverso");
            TestArray();

            Console.Write("\nPremi un tasto per terminare l'esecuzione del programma...");
            Console.ReadKey(false);
        }
    }
}
