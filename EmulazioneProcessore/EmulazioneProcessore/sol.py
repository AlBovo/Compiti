#!/usr/bin/env python3
import string

def isRegister(i: int) -> bool:
    return i in range(32768, 32776)

data = open("code.txt", "r").read().split("\n")
decompiled = open("decompiled.asm", "w")

instr = {
    0 : [0, "int3"], 1 : [2, "mov"], 2 : [1, "push"],
    3 : [1, "pop"], 4 : [3, "cmp"], 5 : [3, "gt"], # gt is cmp
    6 : [1, "jmp"], 7 : [2, "jt"], 8 : [2, "jf"],
    9 : [3, "add"],
    10 : [3, "mult"], 11 : [3, "mod"], 12 : [3, "and"],
    13 : [3, "or"], 14 : [2, "not"], 15 : [2, "rmem"],
    16 : [2, "wmem"], 17 : [1, "call"], 18 : [0, "ret"],
    19 : [1, "out"], 20 : [1, "in"], 21 : [0, "nop"]
}

r = ["$rax", "$rbx", "$rcx", "$rdx", "$r11", "$r12", "$r13", "$r14"]

i = 0
try:
    while True:
        if int(data[i]) not in range(0, 22):
            print(f"Errore: l'istruzione non esiste {i} {data[i]}")
            i += 1
            continue
        else:
            d = instr[int(data[i])][1] + " "

            if data[i] == "0":
                decompiled.write(d + "\n")
                i += 1
                continue
            elif data[i] == "1":
                if isRegister(int(data[i+2])):
                    decompiled.write(d + r[int(data[i+1]) % (1 << 15)] + ", " + f'[{r[int(data[i+2]) % (1 << 15)]}]' + "\n")
                else:
                    decompiled.write(d + r[int(data[i+1]) % (1 << 15)] + ", " + hex(int(data[i+2])) + "\n")
                i += 3
                continue
            elif data[i] == "2":
                if isRegister(int(data[i+1])):
                    decompiled.write(d + f'[{r[int(data[i+1]) % (1 << 15)]}]' + "\n")
                else:
                    decompiled.write(d + hex(int(data[i+1])) + "\n")
                i += 2
                continue
            elif data[i] == "3":
                decompiled.write(d + r[int(data[i+1]) % (1 << 15)] + "\n")
                i += 2
                continue
            elif data[i] == "4":
                t1 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                t2 = f'[{r[int(data[i+3]) % (1 << 15)]}]' if isRegister(int(data[i+3])) else hex(int(data[i+3]))

                decompiled.write(d + f'[{r[int(data[i+1]) % (1 << 15)]}]' + ", " + t1 + ", " + t2 + "\n")
                i += 4
                continue
            elif data[i] == "5":
                t1 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                t2 = f'[{r[int(data[i+3]) % (1 << 15)]}]' if isRegister(int(data[i+3])) else hex(int(data[i+3]))

                decompiled.write(d + f'[{r[int(data[i+1]) % (1 << 15)]}]' + ", " + t1 + ", " + t2 + "\n")
                i += 4
                continue
            elif data[i] == "6":
                t1 = f'[{r[int(data[i+1]) % (1 << 15)]}]' if isRegister(int(data[i+1])) else hex(int(data[i+1]))
                decompiled.write(d + t1 + "\n")
                i += 2
                continue
            elif data[i] == "7":
                t1 = f'[{r[int(data[i+1]) % (1 << 15)]}]' if isRegister(int(data[i+1])) else hex(int(data[i+1]))
                t2 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                decompiled.write(d + t1 + ", " + t2 + "\n")
                i += 3
                continue
            elif data[i] == "8":
                t1 = f'[{r[int(data[i+1]) % (1 << 15)]}]' if isRegister(int(data[i+1])) else hex(int(data[i+1]))
                t2 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                decompiled.write(d + t1 + ", " + t2 + "\n")
                i += 3
                continue
            elif data[i] in ["9", "10", "11", "12", "13"]:
                t1 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                t2 = f'[{r[int(data[i+3]) % (1 << 15)]}]' if isRegister(int(data[i+3])) else hex(int(data[i+3]))

                decompiled.write(d + f'[{r[int(data[i+1]) % (1 << 15)]}]' + ", " + t1 + ", " + t2 + "\n")
                i += 4
                continue
            elif data[i] == "14":
                t2 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                decompiled.write(d + f'[{r[int(data[i+1]) % (1 << 15)]}]' + ", " + t2 + "\n")
                i += 3
                continue
            elif data[i] in ["15", "16"]:
                t1 = f'[{r[int(data[i+1]) % (1 << 15)]}]' if isRegister(int(data[i+1])) else hex(int(data[i+1]))
                t2 = f'[{r[int(data[i+2]) % (1 << 15)]}]' if isRegister(int(data[i+2])) else hex(int(data[i+2]))
                decompiled.write(d + t1 + ", " + t2 + "\n")
                i += 3
                continue
            elif data[i] in ["17", "19"]:
                if data[i] == "17":
                    t1 = f'[{r[int(data[i+1]) % (1 << 15)]}]' if isRegister(int(data[i+1])) else hex(int(data[i+1]))
                else:
                    t1 = f'"{chr(int(data[i+1]))}"'.replace("\n", "\\n")
                decompiled.write(d + t1 + "\n")
                i += 2
                continue
            elif data[i] == "18":
                decompiled.write(d + "\n")
                i += 1
                continue
            elif data[i] == "20":
                decompiled.write(d + f"[{r[int(data[i+1]) % (1 << 15)]}]" + "\n")
                i += 2
                continue
            elif data[i] == "21":
                decompiled.write(d + "\n")
                i += 1
                continue
            else:
                print(f"Errore: l'istruzione non esiste {i} {data[i]}")
                i += 1
                continue
except:
    pass
# decompiled.close()
# data = open("decompiled.asm", "r").read().split("\n")
# decompiled = open("decompiled.asm", "w")

# prev = ''
# for i in range(len(data)):
#     if "out" in data[i]:
#         prev += data[i].split(" ")[1].replace('"', '')
#         i += 1
#     else:
#         if prev != '':
#             decompiled.write(f'out "{prev}"\n')
#             prev = ''
#         decompiled.write(data[i] + "\n")
    