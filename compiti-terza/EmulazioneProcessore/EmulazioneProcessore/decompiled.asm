nop 
nop 
out "B"
out "e"
out "n"
out "v"
out "e"
out "n"
out "u"
out "t"
out "o"
out " "
out "a"
out "l"
out "l"
out "'"
out "I"
out "T"
out "T"
out "S"
out " "
out "P"
out "a"
out "s"
out "c"
out "a"
out "l"
out " "
out "C"
out "P"
out "U"
out "-"
out "E"
out "m"
out "u"
out "l"
out "a"
out "t"
out "i"
out "o"
out "n"
out " "
out "C"
out "h"
out "a"
out "l"
out "l"
out "e"
out "n"
out "g"
out "e"
out "!"
out "\n"
out "R"
out "i"
out "c"
out "o"
out "r"
out "d"
out "a"
out "t"
out "i"
out " "
out "d"
out "i"
out " "
out "s"
out "e"
out "g"
out "n"
out "a"
out "l"
out "a"
out "r"
out "e"
out " "
out "i"
out " "
out "t"
out "u"
out "o"
out "i"
out " "
out "p"
out "r"
out "o"
out "g"
out "r"
out "e"
out "s"
out "s"
out "i"
out " "
out "s"
out "u"
out " "
out "C"
out "l"
out "a"
out "s"
out "s"
out "r"
out "o"
out "o"
out "m"
out "\n"
out "r"
out "i"
out "p"
out "o"
out "r"
out "t"
out "a"
out "n"
out "d"
out "o"
out " "
out "i"
out " "
out "c"
out "o"
out "d"
out "i"
out "c"
out "i"
out " "
out "c"
out "o"
out "m"
out "e"
out " "
out "q"
out "u"
out "e"
out "s"
out "t"
out "o"
out ":"
out " "
out "d"
out "X"
out "M"
out "K"
out "o"
out "p"
out "z"
out "N"
out "W"
out "s"
out "y"
out "L"
out "\n"
out "\n"
out "E"
out "s"
out "e"
out "c"
out "u"
out "z"
out "i"
out "o"
out "n"
out "e"
out " "
out "d"
out "e"
out "l"
out "l"
out "'"
out "a"
out "u"
out "t"
out "o"
out "-"
out "t"
out "e"
out "s"
out "t"
out "."
out "."
out "."
out "\n"
out "\n"
jmp 0x187
out "j"
out "m"
out "p"
out " "
out "f"
out "a"
out "i"
out "l"
out "s"
out "\n"
int3 
nop 
nop 
nop 
nop 
nop 
nop 
nop 
nop 
nop 
jmp 0x192
jmp 0x19c
jmp 0x1b9
jmp 0x210
jmp 0x1d4
jmp 0x1f1
nop 
nop 
nop 
nop 
out "j"
out "m"
out "p"
out " "
out "l"
out "a"
out "n"
out "d"
out "s"
out " "
out "-"
out "2"
out "\n"
int3 
nop 
nop 
out "j"
out "m"
out "p"
out " "
out "l"
out "a"
out "n"
out "d"
out "s"
out " "
out "-"
out "1"
out "\n"
int3 
nop 
nop 
out "j"
out "m"
out "p"
out " "
out "l"
out "a"
out "n"
out "d"
out "s"
out " "
out "+"
out "1"
out "\n"
int3 
nop 
nop 
nop 
nop 
out "j"
out "m"
out "p"
out " "
out "l"
out "a"
out "n"
out "d"
out "s"
out " "
out "+"
out "2"
out "\n"
int3 
jt 0x0, 0x45e
jf 0x1, 0x45e
jt 0x1, 0x21b
jmp 0x45e
jf 0x0, 0x220
jmp 0x45e
jt [$rax], 0x471
jt [$rbx], 0x471
jt [$rcx], 0x471
jt [$rdx], 0x471
jt [$r11], 0x471
jt [$r12], 0x471
jt [$r13], 0x471
jt [$r14], 0x471
mov $rax, 0x1
jf [$rax], 0x48a
mov $rax, 0x0
jt [$rax], 0x48a
add [$rax], 0x1, 0x1
jt [$rax], 0x260
out "n"
out "o"
out " "
out "a"
out "d"
out "d"
out " "
out "o"
out "p"
out "\n"
int3 
cmp [$rbx], [$rax], 0x2
jt [$rbx], 0x27a
out "n"
out "o"
out " "
out "e"
out "q"
out " "
out "o"
out "p"
out "\n"
int3 
push [$rax]
push [$rbx]
pop $rax
pop $rbx
cmp [$rcx], [$rbx], 0x2
jf [$rcx], 0x4b2
cmp [$rcx], [$rax], 0x1
jf [$rcx], 0x4b2
gt [$rcx], [$rbx], [$rax]
jf [$rcx], 0x49f
gt [$rcx], [$rax], [$rbx]
jt [$rcx], 0x49f
gt [$rcx], 0x2a, 0x2a
jt [$rcx], 0x49f
and [$rax], 0x70f0, 0x4caa
cmp [$rbx], [$rax], 0x40a0
jf [$rbx], 0x4c5
or [$rbx], 0x70f0, 0x4caa
cmp [$rax], [$rbx], 0x7cfa
jt [$rax], 0x2d8
out "n"
out "o"
out " "
out "b"
out "i"
out "t"
out "w"
out "i"
out "s"
out "e"
out " "
out "o"
out "r"
out "\n"
int3 
not [$rax], 0x0
cmp [$rbx], [$rax], 0x7fff
jf [$rbx], 0x4e4
not [$rax], 0x5555
cmp [$rbx], [$rax], 0x2aaa
jf [$rbx], 0x4e4
call 0x531
jmp 0x535
pop $rax
cmp [$rbx], [$rax], 0x2f0
jt [$rbx], 0x535
cmp [$rbx], [$rax], 0x2ee
jf [$rbx], 0x535
mov $rax, 0x533
call [$rax]
jmp 0x535
pop $rax
cmp [$rbx], [$rax], 0x307
jt [$rbx], 0x535
cmp [$rbx], [$rax], 0x305
jf [$rbx], 0x535
add [$rax], 0x7fff, 0x7fff
cmp [$rbx], [$rax], 0x7ffe
jf [$rbx], 0x54c
cmp [$rbx], 0x7ffe, [$rax]
jf [$rbx], 0x54c
add [$rax], 0x4000, 0x4000
jt [$rax], 0x54c
add [$rax], 0x4000, 0x4000
jt [$rax], 0x54c
mult [$rax], 0x6, 0x9
cmp [$rbx], [$rax], 0x2a
jt [$rbx], 0x591
cmp [$rbx], [$rax], 0x36
jf [$rbx], 0x5b2
mult [$rax], 0x3039, 0x7d7b
cmp [$rbx], [$rax], 0x63
jf [$rbx], 0x54c
mod [$rax], 0x6, 0x3
cmp [$rbx], [$rax], 0x0
jf [$rbx], 0x5c9
mod [$rax], 0x46, 0x6
cmp [$rbx], [$rax], 0x4
jf [$rbx], 0x5c9
mult [$rax], 0x7ffe, 0xf
cmp [$rbx], [$rax], 0x7fe2
jf [$rbx], 0x54c
jmp 0x379
rmem [$rax], 0x377
cmp [$rbx], [$rax], 0x4e20
jf [$rbx], 0x503
add [$rcx], 0x377, 0x1
rmem [$rax], [$rcx]
cmp [$rbx], [$rax], 0x2710
jf [$rbx], 0x503
mov $rax, 0x377
wmem [$rax], 0x7530
rmem [$rcx], [$rax]
cmp [$rbx], [$rcx], 0x7530
jf [$rbx], 0x51a
call 0x6e7
rmem [$rax], 0x17f1
cmp [$rbx], [$rax], 0xb
jf [$rbx], 0x503
add [$rcx], 0x17f1, 0x1
rmem [$rax], [$rcx]
cmp [$rbx], [$rax], 0x74
jf [$rbx], 0x503
wmem [$rcx], 0x54
rmem [$rax], [$rcx]
cmp [$rbx], [$rax], 0x74
jt [$rbx], 0x51a
cmp [$rbx], [$rax], 0x54
jf [$rbx], 0x51a
wmem 0x3d5, 0x15
wmem 0x3d6, 0x7
nop 
jt 0x13, 0x3fe
out "w"
out "m"
out "e"
out "m"
out " "
out "o"
out "p"
out "w"
out "r"
out "i"
out "t"
out "e"
out " "
out "f"
out "a"
out "i"
out "l"
out "\n"
int3 
add [$rbx], 0xa, 0x17fd
add [$rbx], [$rbx], 0x1
rmem [$rcx], 0x1829
add [$rcx], [$rcx], 0x1829
mov $rax, 0x1829
add [$rax], [$rax], 0x1
gt [$rdx], [$rax], [$rcx]
jt [$rdx], 0x42b
rmem [$r11], [$rax]
wmem [$rbx], [$r11]
add [$rax], [$rax], 0x1
add [$rbx], [$rbx], 0x1
jmp 0x414
rmem [$rax], 0x17fd
rmem [$rbx], 0x1810
add [$rax], [$rax], [$rbx]
add [$rax], [$rax], 0x1
wmem 0x17fd, [$rax]
wmem 0x1810, 0x2c
mov $rax, 0x17fd
call 0x61a
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x6f97
mov $rbx, 0x627
add [$rcx], 0x24d4, 0x3327
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0xada
out "n"
out "o"
out " "
out "j"
out "t"
out "/"
out "j"
out "f"
out "\n"
int3 
out "n"
out "o"
out "n"
out "z"
out "e"
out "r"
out "o"
out " "
out "r"
out "e"
out "g"
out "\n"
int3 
out "n"
out "o"
out " "
out "s"
out "e"
out "t"
out " "
out "o"
out "p"
out "\n"
int3 
out "n"
out "o"
out " "
out "g"
out "t"
out " "
out "o"
out "p"
out "\n"
int3 
out "n"
out "o"
out " "
out "s"
out "t"
out "a"
out "c"
out "k"
out "\n"
int3 
out "n"
out "o"
out " "
out "b"
out "i"
out "t"
out "w"
out "i"
out "s"
out "e"
out " "
out "a"
out "n"
out "d"
out "\n"
int3 
out "n"
out "o"
out " "
out "b"
out "i"
out "t"
out "w"
out "i"
out "s"
out "e"
out " "
out "n"
out "o"
out "t"
out "\n"
int3 
out "n"
out "o"
out " "
out "r"
out "m"
out "e"
out "m"
out " "
out "o"
out "p"
out "\n"
int3 
out "n"
out "o"
out " "
out "w"
out "m"
out "e"
out "m"
out " "
out "o"
out "p"
out "\n"
int3 
jmp 0x2f0
jmp 0x307
out "n"
out "o"
out " "
out "c"
out "a"
out "l"
out "l"
out " "
out "o"
out "p"
out "\n"
int3 
out "n"
out "o"
out " "
out "m"
out "o"
out "d"
out "u"
out "l"
out "o"
out " "
out "m"
out "a"
out "t"
out "h"
out " "
out "d"
out "u"
out "r"
out "i"
out "n"
out "g"
out " "
out "a"
out "d"
out "d"
out " "
out "o"
out "r"
out " "
out "m"
out "u"
out "l"
out "t"
out "\n"
int3 
out "n"
out "o"
out "t"
out " "
out "h"
out "i"
out "t"
out "c"
out "h"
out "h"
out "i"
out "k"
out "i"
out "n"
out "g"
out "\n"
int3 
out "n"
out "o"
out " "
out "m"
out "u"
out "l"
out "t"
out " "
out "o"
out "p"
out "\n"
int3 
out "n"
out "o"
out " "
out "m"
out "o"
out "d"
out " "
out "o"
out "p"
out "\n"
int3 
push [$rax]
push [$rdx]
push [$r11]
push [$r12]
push [$r13]
mov $r13, [$rax]
mov $r12, [$rbx]
rmem [$r11], [$rax]
mov $rbx, 0x0
add [$rdx], 0x1, [$rbx]
gt [$rax], [$rdx], [$r11]
jt [$rax], 0x60f
add [$rdx], [$rdx], [$r13]
rmem [$rax], [$rdx]
call [$r12]
add [$rbx], [$rbx], 0x1
jt [$rbx], 0x5f4
pop $r13
pop $r12
pop $r11
pop $rdx
pop $rax
ret 
push [$rbx]
mov $rbx, 0x624
call 0x5de
pop $rbx
ret 
out "耀"
ret 
push [$rbx]
mov $rbx, [$rcx]
call 0x879
out "耀"
pop $rbx
ret 
push [$rbx]
push [$rdx]
rmem [$rdx], [$rax]
jf [$rdx], 0x647
call 0x5de
jt [$rbx], 0x647
mov $rax, [$rcx]
jmp 0x64a
mov $rax, 0x7fff
pop $rdx
pop $rbx
ret 
push [$rbx]
push [$rcx]
mov $rcx, [$rbx]
mov $rbx, 0x671
call 0x633
pop $rcx
pop $rbx
ret 
push [$rbx]
push [$rcx]
mov $rcx, [$rbx]
mov $rbx, 0x69c
call 0x633
pop $rcx
pop $rbx
ret 
cmp [$rax], [$rax], [$rcx]
jf [$rax], 0x67e
mov $rcx, [$rbx]
mov $rbx, 0x7fff
ret 
push [$rdx]
add [$rdx], [$rcx], 0x1
add [$rdx], [$rdx], [$rbx]
rmem [$rdx], [$rdx]
cmp [$rdx], [$rax], [$rdx]
jt [$rdx], 0x699
mov $rcx, [$rbx]
mov $rbx, 0x7fff
pop $rdx
ret 
push [$rbx]
mov $rbx, [$rcx]
call 0x6af
pop $rbx
jf [$rax], 0x6ae
mov $rcx, [$rbx]
mov $rbx, 0x7fff
ret 
push [$rbx]
push [$rcx]
push [$rdx]
push [$r11]
rmem [$rdx], [$rax]
rmem [$r11], [$rbx]
cmp [$rcx], [$rdx], [$r11]
jf [$rcx], 0x6db
or [$rcx], [$rdx], [$r11]
jf [$rcx], 0x6d6
mov $rcx, [$rbx]
mov $rbx, 0x67f
call 0x5de
jf [$rbx], 0x6db
mov $rax, 0x1
jmp 0x6de
mov $rax, 0x0
pop $r11
pop $rdx
pop $rcx
pop $rbx
ret 
push [$rax]
push [$rbx]
mov $rbx, 0x17f1
rmem [$rax], [$rbx]
push [$rbx]
mult [$rbx], [$rbx], [$rbx]
call 0x879
mov $rbx, 0x4154
call 0x879
pop $rbx
wmem [$rbx], [$rax]
add [$rbx], [$rbx], 0x1
cmp [$rax], 0x7d3b, [$rbx]
jf [$rax], 0x6ee
pop $rbx
pop $rax
ret 
push [$rax]
push [$rcx]
push [$rdx]
push [$r11]
push [$r12]
add [$rcx], [$rbx], [$rax]
mov $rax, [$rbx]
mov $r12, 0x0
add [$rax], [$rax], 0x1
gt [$rdx], [$rax], [$rcx]
jt [$rdx], 0x744
in [$r11]
cmp [$rdx], [$r11], 0xa
jt [$rdx], 0x744
wmem [$rax], [$r11]
add [$r12], [$r12], 0x1
jmp 0x727
wmem [$rbx], [$r12]
cmp [$rdx], [$r11], 0xa
jt [$rdx], 0x752
in [$r11]
jmp 0x747
pop $r12
pop $r11
pop $rdx
pop $rcx
pop $rax
ret 
push [$rdx]
push [$r11]
push [$r12]
push [$r13]
mov $r13, 0x1
add [$r11], [$rdx], [$r13]
rmem [$r11], [$r11]
add [$r12], 0x1832, [$r13]
wmem [$r12], [$r11]
add [$r13], [$r13], 0x1
rmem [$r12], 0x1832
gt [$r11], [$r13], [$r12]
jf [$r11], 0x768
mov $rdx, 0x0
mov $r11, 0x0
rmem [$r12], 0x1832
mod [$r12], [$r11], [$r12]
add [$r12], [$r12], 0x1832
add [$r12], [$r12], 0x1
rmem [$r13], [$r12]
mult [$r13], [$r13], 0x1481
add [$r13], [$r13], 0x3039
wmem [$r12], [$r13]
push [$rax]
push [$rbx]
mov $rbx, [$r13]
call 0x879
mov $r13, [$rax]
pop $rbx
pop $rax
rmem [$r12], [$rbx]
mod [$r13], [$r13], [$r12]
add [$r13], [$r13], 0x1
gt [$r12], [$r13], [$rcx]
jt [$r12], 0x7cc
mov $rdx, 0x1
add [$r13], [$r13], [$rbx]
rmem [$r13], [$r13]
add [$r11], [$r11], 0x1
add [$r12], [$r11], 0x1836
wmem [$r12], [$r13]
rmem [$r12], 0x1836
cmp [$r12], [$r11], [$r12]
jf [$r12], 0x78a
jf [$rdx], 0x784
push [$rax]
mov $rax, 0x1836
call 0x61a
pop $rax
pop $r13
pop $r12
pop $r11
pop $rdx
ret 
push [$rax]
push [$rbx]
push [$rcx]
push [$rdx]
push [$r11]
push [$r12]
mov $rcx, 0x1
mov $r12, 0x0
jf [$rax], 0x858
cmp [$r11], [$rcx], 0x2710
mov $rdx, [$rax]
jt [$r11], 0x824
mult [$rbx], [$rcx], 0xa
mod [$rdx], [$rax], [$rbx]
mov $r11, 0x0
mult [$rcx], [$rcx], 0x7fff
jf [$rdx], 0x838
add [$r11], [$r11], 0x1
add [$rdx], [$rdx], [$rcx]
jmp 0x82b
mult [$rcx], [$rcx], 0x7fff
mult [$rdx], [$r11], [$rcx]
mult [$rdx], [$rdx], 0x7fff
add [$rax], [$rax], [$rdx]
add [$r11], [$r11], 0x30
mult [$rcx], [$rcx], 0xa
add [$r12], [$r12], 0x1
push [$r11]
jmp 0x80f
jt [$r12], 0x85f
out "0"
jmp 0x86c
jf [$r12], 0x86c
pop $rax
out "耀"
add [$r12], [$r12], 0x7fff
jmp 0x85f
pop $r12
pop $r11
pop $rdx
pop $rcx
pop $rbx
pop $rax
ret 
push [$rbx]
push [$rcx]
and [$rcx], [$rax], [$rbx]
not [$rcx], [$rcx]
or [$rax], [$rax], [$rbx]
and [$rax], [$rax], [$rcx]
pop $rcx
pop $rbx
ret 
add [$rax], [$rax], [$rbx]
gt [$rbx], [$rbx], [$rax]
ret 
push [$rcx]
gt [$rcx], [$rbx], [$rax]
mult [$rbx], [$rbx], 0x7fff
add [$rax], [$rax], [$rbx]
mov $rbx, [$rcx]
pop $rcx
ret 
jf [$rax], 0x8ed
jf [$rbx], 0x8ed
push [$rcx]
push [$rdx]
gt [$rcx], [$rbx], [$rax]
jt [$rcx], 0x8c8
mov $rcx, [$rax]
mov $rax, [$rbx]
mov $rbx, [$rcx]
mov $rcx, [$rax]
mov $rax, 0x0
add [$rax], [$rax], [$rbx]
gt [$rdx], [$rbx], [$rax]
jt [$rdx], 0x8e5
add [$rcx], [$rcx], 0x7fff
jt [$rcx], 0x8ce
mov $rbx, 0x0
jmp 0x8e8
mov $rbx, 0x1
pop $rdx
pop $rcx
ret 
mov $rax, 0x0
mov $rbx, 0x0
ret 
push [$rbx]
push [$rcx]
jf [$rbx], 0x910
add [$rbx], [$rbx], 0x7fff
and [$rcx], [$rax], 0x4000
mult [$rax], [$rax], 0x2
jf [$rcx], 0x8f8
or [$rax], [$rax], 0x1
jmp 0x8f8
pop $rcx
pop $rbx
ret 
push [$rbx]
gt [$rbx], [$rax], 0xe
jt [$rbx], 0x931
mov $rbx, [$rax]
mov $rax, 0x1
jf [$rbx], 0x934
add [$rbx], [$rbx], 0x7fff
mult [$rax], [$rax], 0x2
jmp 0x924
mov $rax, 0x7fff
pop $rbx
ret 
jmp 0xada
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
int3 
push [$rax]
push [$rbx]
push [$rcx]
push [$rdx]
rmem [$rbx], 0xad8
rmem [$rax], 0xad9
cmp [$rax], [$rax], [$rbx]
jt [$rax], 0xafe
rmem [$rax], 0xad8
add [$rax], [$rax], 0x4
rmem [$rax], [$rax]
jf [$rax], 0xafe
call [$rax]
rmem [$rbx], 0xad8
rmem [$rax], 0xad9
cmp [$rax], [$rax], [$rbx]
jt [$rax], 0xb13
mov $rax, 0x6bb9
wmem [$rax], 0x0
call 0xbc0
wmem 0xad9, [$rbx]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x71e5
mov $rbx, 0x627
add [$rcx], 0x4a3, 0x24a
call 0x5de
pop $rcx
pop $rbx
pop $rax
mov $rax, 0x20
mov $rbx, 0x6bb9
call 0x713
out "\n"
out "\n"
mov $rax, 0x6bb9
mov $rbx, 0x20
call 0x64f
cmp [$rbx], [$rax], 0x7fff
jf [$rbx], 0xb4c
rmem [$rax], 0x6bb9
mov $rcx, [$rax]
rmem [$rbx], 0x6bb9
push [$rbx]
wmem 0x6bb9, [$rcx]
mov $rax, 0x71d5
mov $rbx, 0x6bb9
call 0x660
pop $rbx
wmem 0x6bb9, [$rbx]
cmp [$rbx], [$rax], 0x7fff
jf [$rbx], 0xb71
mov $rax, 0x0
mov $rcx, 0x0
add [$rbx], 0x71dd, 0x1
add [$rbx], [$rbx], [$rax]
rmem [$rbx], [$rbx]
rmem [$rdx], 0x6bb9
cmp [$rdx], [$rdx], [$rcx]
jt [$rdx], 0xbac
mult [$rax], [$rcx], 0x7fff
rmem [$rdx], 0x6bb9
add [$rdx], [$rax], [$rdx]
jf [$rcx], 0xb98
add [$rdx], [$rdx], 0x7fff
mod [$rdx], [$rdx], 0x20
add [$rax], 0x6bb9, [$rcx]
jf [$rcx], 0xba7
add [$rax], [$rax], 0x1
wmem [$rax], [$rdx]
jmp 0xbb2
mov $rax, 0x6bb9
wmem [$rax], 0x0
call [$rbx]
jt [$rbx], 0xae2
pop $rdx
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
rmem [$rbx], [$rax]
jf [$rbx], 0xc04
call 0x175e
jf [$rax], 0xbea
push [$rax]
call 0x17a3
mov $rbx, [$rax]
pop $rax
jf [$rbx], 0xbea
add [$rbx], [$rax], 0x1
rmem [$rax], [$rbx]
call 0x61a
out "\n"
jmp 0xce3
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x71f7
mov $rbx, 0x627
add [$rcx], 0xaf2, 0x46ef
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0xce3
rmem [$rax], 0xad8
push [$rax]
out "="
out "="
out " "
add [$rax], [$rax], 0x0
rmem [$rax], [$rax]
call 0x61a
out " "
out "="
out "="
out "\n"
pop $rax
push [$rax]
add [$rax], [$rax], 0x1
rmem [$rax], [$rax]
rmem [$rbx], [$rax]
cmp [$rbx], [$rbx], 0x2
jf [$rbx], 0xc4c
push [$rax]
mov $rax, 0xaa4
call 0x17a3
mov $rbx, [$rax]
pop $rax
add [$rax], [$rax], 0x1
add [$rax], [$rax], [$rbx]
rmem [$rax], [$rax]
call 0x61a
out "\n"
pop $rax
push [$rax]
call 0x16fc
jf [$rax], 0xc76
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x721c
mov $rbx, 0x627
add [$rcx], 0x668, 0x1887
call 0x5de
pop $rcx
pop $rbx
pop $rax
rmem [$rcx], 0xad8
call 0x1731
pop $rax
push [$rax]
add [$rax], [$rax], 0x2
rmem [$rax], [$rax]
rmem [$rax], [$rax]
cmp [$rcx], [$rax], 0x1
out "\n"
jt [$rcx], 0xcb1
out "C"
out "i"
out " "
out "s"
out "o"
out "n"
out "o"
out " "
call 0x7fd
out " "
out "o"
out "p"
out "z"
out "i"
out "o"
out "n"
out "i"
jmp 0xccd
out "C"
out "'"
out "e"
out "'"
out " "
out "1"
out " "
out "o"
out "p"
out "z"
out "i"
out "o"
out "n"
out "e"
out ":"
out "\n"
pop $rax
push [$rax]
add [$rax], [$rax], 0x2
rmem [$rax], [$rax]
mov $rbx, 0x16f3
call 0x5de
pop $rax
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
mov $rbx, [$rax]
rmem [$rax], 0xad8
add [$rax], [$rax], 0x2
rmem [$rax], [$rax]
call 0x660
cmp [$rcx], [$rax], 0x7fff
jt [$rcx], 0xd23
rmem [$rcx], 0xad8
add [$rcx], [$rcx], 0x3
rmem [$rcx], [$rcx]
add [$rcx], [$rcx], 0x1
add [$rcx], [$rcx], [$rax]
rmem [$rcx], [$rcx]
wmem 0xad8, [$rcx]
wmem 0xad9, 0x0
jmp 0xd3b
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7235
mov $rbx, 0x627
add [$rcx], 0x797, 0xc58
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7267
mov $rbx, 0x627
add [$rcx], 0x1c58, 0x43a7
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rax
ret 
push [$rax]
push [$rcx]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x751c
mov $rbx, 0x627
add [$rcx], 0x466d, 0x297e
call 0x5de
pop $rcx
pop $rbx
pop $rax
mov $rcx, 0x0
call 0x1731
pop $rcx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
call 0x175e
jf [$rax], 0xdbe
add [$rbx], [$rax], 0x2
rmem [$rax], [$rbx]
rmem [$rcx], 0xad8
cmp [$rcx], [$rax], [$rcx]
jf [$rcx], 0xdbe
wmem [$rbx], 0x0
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x752b
mov $rbx, 0x627
add [$rcx], 0x48c9, 0x31a9
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0xdd6
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7533
mov $rbx, 0x627
add [$rcx], 0x6d3, 0xa96
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
call 0x175e
jf [$rax], 0xe10
add [$rbx], [$rax], 0x2
rmem [$rax], [$rbx]
jt [$rax], 0xe10
rmem [$rax], 0xad8
wmem [$rbx], [$rax]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7552
mov $rbx, 0x627
add [$rcx], 0x5959, 0x1da6
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0xe28
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x755d
mov $rbx, 0x627
add [$rcx], 0x1717, 0x18d7
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
call 0x175e
jf [$rax], 0xe4e
add [$rbx], [$rax], 0x2
rmem [$rbx], [$rbx]
jt [$rbx], 0xe4e
add [$rbx], [$rax], 0x3
rmem [$rbx], [$rbx]
jf [$rbx], 0xe68
call [$rbx]
jmp 0xe80
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x757f
mov $rbx, 0x627
add [$rcx], 0xfce, 0xdac
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0xe80
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x759c
mov $rbx, 0x627
add [$rcx], 0x1b5, 0x8ca
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0xaa4
call 0x17a3
jt [$rax], 0xeab
add [$rax], 0xaa0, 0x2
wmem [$rax], 0x7fff
add [$rax], 0xaa4, 0x2
wmem [$rax], 0x7fff
add [$rax], 0xa9c, 0x2
wmem [$rax], 0x7fff
wmem 0xad8, 0xa84
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x75b2
mov $rbx, 0x627
add [$rcx], 0x4fe, 0x1cfc
call 0x5de
pop $rcx
pop $rbx
pop $rax
int3 
int3 
push [$rbx]
rmem [$rbx], 0xecb
or [$rbx], [$rbx], [$rax]
wmem 0xecb, [$rbx]
pop $rbx
ret 
wmem 0xecb, 0x0
ret 
push [$rax]
mov $rax, 0x1
call 0xecc
pop $rax
ret 
push [$rax]
mov $rax, 0x2
call 0xecc
pop $rax
ret 
push [$rax]
mov $rax, 0x4
call 0xecc
pop $rax
ret 
push [$rax]
mov $rax, 0x8
call 0xecc
pop $rax
ret 
push [$rax]
mov $rax, 0x10
call 0xecc
pop $rax
ret 
push [$rax]
mov $rax, 0x20
call 0xecc
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
push [$rdx]
mov $rax, 0x40
call 0xecc
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x75d1
mov $rbx, 0x627
add [$rcx], 0x186f, 0x3b0c
call 0x5de
pop $rcx
pop $rbx
pop $rax
rmem [$rax], 0xecb
mov $rbx, 0x6b43
mov $rcx, 0x7fff
mov $rdx, 0x7604
call 0x75d
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7608
mov $rbx, 0x627
add [$rcx], 0x2dd, 0x40b
call 0x5de
pop $rcx
pop $rbx
pop $rax
wmem 0xad8, 0x99d
pop $rdx
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
rmem [$rax], 0x9ca
rmem [$rbx], 0x70ac
cmp [$rax], [$rax], [$rbx]
jt [$rax], 0xfa1
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x763a
mov $rbx, 0x627
add [$rcx], 0x223b, 0x3abc
call 0x5de
pop $rcx
pop $rbx
pop $rax
wmem 0xad8, 0x9c5
wmem 0xad9, 0x9c5
pop $rbx
pop $rax
ret 
int3 
int3 
int3 
int3 
int3 
int3 
push [$rax]
push [$rbx]
mov $rax, 0x2
mov $rbx, 0x0
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x8
mov $rbx, 0x1
call 0x10f4
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x1
mov $rbx, 0x2
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x1
mov $rbx, 0x3
call 0x10f4
call 0x11f2
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x4
mov $rbx, 0x4
call 0x10f4
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x2
mov $rbx, 0x5
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0xb
mov $rbx, 0x6
call 0x10f4
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x2
mov $rbx, 0x7
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x0
mov $rbx, 0x8
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x4
mov $rbx, 0x9
call 0x10f4
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x1
mov $rbx, 0xa
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x12
mov $rbx, 0xb
call 0x10f4
pop $rbx
pop $rax
ret 
call 0x1240
ret 
push [$rax]
push [$rbx]
mov $rax, 0x1
mov $rbx, 0xc
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x9
mov $rbx, 0xd
call 0x10f4
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0x2
mov $rbx, 0xe
call 0x10b7
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
add [$rcx], 0xac8, 0x2
rmem [$rcx], [$rcx]
jt [$rcx], 0x10ed
call 0x1172
wmem 0xfac, [$rax]
add [$rbx], [$rax], 0xfa6
rmem [$rbx], [$rbx]
mov $rax, 0x6bed
call 0x61a
mov $rax, [$rbx]
call 0x61a
mov $rax, 0x6c37
call 0x61a
mov $rax, [$rbx]
call 0x61a
out "."
out "\n"
out "\n"
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
add [$rcx], 0xac8, 0x2
rmem [$rcx], [$rcx]
jt [$rcx], 0x116b
call 0x1172
push [$rax]
rmem [$rax], 0xfac
add [$rbx], [$rax], 0xfa6
rmem [$rbx], [$rbx]
mov $rax, 0x6c62
call 0x61a
mov $rax, [$rbx]
call 0x61a
mov $rax, 0x6c9c
call 0x61a
pop $rax
mov $rbx, [$rax]
rmem [$rax], 0xfad
rmem [$rcx], 0xfac
add [$rcx], [$rcx], 0xfa9
rmem [$rcx], [$rcx]
call [$rcx]
jt [$rbx], 0x1164
rmem [$rbx], 0xfad
wmem 0xfad, [$rax]
gt [$rcx], [$rax], [$rbx]
jf [$rcx], 0x114e
push [$rax]
mov $rax, 0x6cdd
call 0x61a
pop $rax
gt [$rcx], [$rbx], [$rax]
jf [$rcx], 0x115e
push [$rax]
mov $rax, 0x6d07
call 0x61a
pop $rax
out "\n"
out "\n"
jmp 0x116b
call 0x1271
mov $rax, 0x6d31
call 0x61a
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
push [$rdx]
push [$r11]
push [$r12]
rmem [$r12], 0xfae
gt [$rdx], [$r12], 0x752f
jt [$rdx], 0x118f
add [$r12], [$r12], 0x1
wmem 0xfae, [$r12]
mov $rdx, [$rax]
mov $r11, [$rbx]
add [$rax], [$r12], 0x2
call 0x915
rmem [$rbx], 0xfaf
or [$rax], [$rbx], [$rax]
mov $rbx, [$r11]
call 0x8f4
wmem 0xfaf, [$rax]
mov $rax, 0xfb0
add [$rbx], [$r12], 0x2
mov $rcx, [$r11]
call 0x11e0
mov $rax, 0xfb1
mult [$rbx], [$r12], [$r12]
mult [$rcx], [$r11], [$r11]
call 0x11e0
mov $rax, 0xfb2
mov $rbx, 0xd
mult [$rcx], [$rdx], 0x9
mult [$rcx], [$rcx], [$rcx]
call 0x11e0
pop $r12
pop $r11
pop $rdx
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
rmem [$rax], [$rax]
call 0x8f4
mov $rbx, [$rcx]
call 0x879
pop $rbx
wmem [$rbx], [$rax]
ret 
push [$rax]
add [$rax], 0xac8, 0x2
rmem [$rax], [$rax]
jt [$rax], 0x123d
mov $rax, 0x6d4e
call 0x61a
rmem [$rax], 0xfad
cmp [$rax], [$rax], 0x1e
jt [$rax], 0x121b
mov $rax, 0x6d79
call 0x61a
mov $rax, 0x6dad
call 0x61a
call 0x1271
jmp 0x123d
mov $rax, 0x6dd2
call 0x61a
rmem [$rax], 0xfaf
add [$rax], [$rax], 0x1
jt [$rax], 0x1231
mov $rax, 0x6e08
call 0x61a
jmp 0x1212
mov $rax, 0x6e6b
call 0x61a
add [$rax], 0xac8, 0x2
wmem [$rax], 0x7fff
pop $rax
ret 
push [$rax]
add [$rax], 0xac8, 0x2
rmem [$rax], [$rax]
jt [$rax], 0x126e
mov $rax, 0x6f02
call 0x61a
rmem [$rax], 0xad8
cmp [$rax], [$rax], 0xa6b
jt [$rax], 0x1262
mov $rax, 0x6f0a
call 0x61a
jmp 0x1267
mov $rax, 0x6f15
call 0x61a
mov $rax, 0x6f21
call 0x61a
call 0x1271
pop $rax
ret 
push [$rax]
wmem 0xfad, 0x16
wmem 0xfae, 0x0
wmem 0xfaf, 0x0
wmem 0xfb0, 0x0
wmem 0xfb1, 0x0
wmem 0xfb2, 0x0
add [$rax], 0xac8, 0x2
wmem [$rax], 0xa6b
pop $rax
ret 
push [$rax]
add [$rax], 0xac8, 0x2
rmem [$rax], [$rax]
cmp [$rax], [$rax], 0x7fff
jt [$rax], 0x12aa
mov $rax, 0x6f74
call 0x61a
wmem 0xad8, 0xa3e
wmem 0xad9, 0xa3e
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
push [$rdx]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7653
mov $rbx, 0x627
add [$rcx], 0x625c, 0x495
call 0x5de
pop $rcx
pop $rbx
pop $rax
mov $rax, 0x1092
mov $rbx, 0x6b43
mov $rcx, 0x7fff
mov $rdx, 0x766b
call 0x75d
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x766f
mov $rbx, 0x627
add [$rcx], 0x3bc5, 0x2139
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rdx
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
add [$rax], 0xa9c, 0x2
rmem [$rax], [$rax]
jt [$rax], 0x1337
add [$rax], 0xaa8, 0x2
wmem [$rax], 0x7fff
add [$rax], 0xa9c, 0x2
wmem [$rax], 0x7fff
add [$rax], 0xaa0, 0x2
wmem [$rax], 0x0
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x769e
mov $rbx, 0x627
add [$rcx], 0x74dc, 0x298
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0x134f
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x76d3
mov $rbx, 0x627
add [$rcx], 0x2cf9, 0x484
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rax
ret 
push [$rax]
add [$rax], 0xaa0, 0x2
wmem [$rax], 0x7fff
add [$rax], 0xaa4, 0x2
wmem [$rax], 0x0
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7708
mov $rbx, 0x627
add [$rcx], 0x2366, 0x3105
call 0x5de
pop $rcx
pop $rbx
pop $rax
wmem 0xad9, 0x0
pop $rax
ret 
push [$rax]
add [$rax], 0xaa0, 0x2
wmem [$rax], 0x0
add [$rax], 0xaa4, 0x2
wmem [$rax], 0x7fff
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7726
mov $rbx, 0x627
add [$rcx], 0x42ce, 0x1d2d
call 0x5de
pop $rcx
pop $rbx
pop $rax
wmem 0xad9, 0x0
pop $rax
ret 
push [$rcx]
push [$rdx]
rmem [$rcx], 0xad8
cmp [$rcx], [$rcx], 0x9c5
jt [$rcx], 0x13d6
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7740
mov $rbx, 0x627
add [$rcx], 0x410, 0xd1
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0x1515
add [$rcx], [$rax], 0x2
wmem [$rcx], 0x7fff
rmem [$rcx], 0x9ca
add [$rcx], [$rcx], 0x70a6
add [$rcx], [$rcx], 0x1
rmem [$rcx], [$rcx]
add [$rdx], 0x9c5, 0x1
rmem [$rdx], [$rdx]
add [$rdx], [$rdx], [$rcx]
add [$rcx], [$rbx], 0x30
wmem [$rdx], [$rcx]
rmem [$rcx], 0x9ca
add [$rcx], [$rcx], 0x70ac
add [$rcx], [$rcx], 0x1
wmem [$rcx], [$rbx]
push [$rax]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x776c
mov $rbx, 0x627
add [$rcx], 0x2b06, 0x276a
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rax
push [$rax]
add [$rcx], [$rax], 0x0
rmem [$rax], [$rcx]
call 0x61a
pop $rax
push [$rax]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7779
mov $rbx, 0x627
add [$rcx], 0x1dff, 0x3162
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rax
rmem [$rcx], 0x9ca
add [$rcx], [$rcx], 0x1
wmem 0x9ca, [$rcx]
rmem [$rdx], 0x70ac
cmp [$rdx], [$rcx], [$rdx]
jf [$rdx], 0x1515
mov $rax, 0x0
add [$rbx], 0x70ac, 0x1
rmem [$rbx], [$rbx]
add [$rax], [$rax], [$rbx]
add [$rbx], 0x70ac, 0x2
rmem [$rbx], [$rbx]
add [$rcx], 0x70ac, 0x3
rmem [$rcx], [$rcx]
mult [$rcx], [$rcx], [$rcx]
mult [$rbx], [$rbx], [$rcx]
add [$rax], [$rax], [$rbx]
add [$rbx], 0x70ac, 0x4
rmem [$rbx], [$rbx]
mult [$rcx], [$rbx], [$rbx]
mult [$rcx], [$rcx], [$rbx]
add [$rax], [$rax], [$rcx]
add [$rbx], 0x70ac, 0x5
rmem [$rbx], [$rbx]
mult [$rbx], [$rbx], 0x7fff
add [$rax], [$rax], [$rbx]
cmp [$rbx], [$rax], 0x18f
jt [$rbx], 0x14fd
add [$rcx], 0xaac, 0x2
wmem [$rcx], 0x9c5
add [$rcx], 0xab0, 0x2
wmem [$rcx], 0x9c5
add [$rcx], 0xab4, 0x2
wmem [$rcx], 0x9c5
add [$rcx], 0xab8, 0x2
wmem [$rcx], 0x9c5
add [$rcx], 0xabc, 0x2
wmem [$rcx], 0x9c5
wmem 0x9ca, 0x0
mov $rax, 0x70a6
mov $rbx, 0x151a
call 0x5de
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x779e
mov $rbx, 0x627
add [$rcx], 0x945, 0x1b9
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0x1515
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x77e9
mov $rbx, 0x627
add [$rcx], 0x4e72, 0x7fa
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rdx
pop $rcx
ret 
push [$rcx]
add [$rcx], 0x9c5, 0x1
rmem [$rcx], [$rcx]
add [$rcx], [$rcx], [$rax]
wmem [$rcx], 0x5f
pop $rcx
ret 
push [$rax]
push [$rbx]
mov $rax, 0xaac
mov $rbx, 0x2
call 0x13ae
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0xab0
mov $rbx, 0x3
call 0x13ae
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0xab4
mov $rbx, 0x5
call 0x13ae
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0xab8
mov $rbx, 0x7
call 0x13ae
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
mov $rax, 0xabc
mov $rbx, 0x9
call 0x13ae
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
jf [$r14], 0x1622
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x782e
mov $rbx, 0x627
add [$rcx], 0x29c2, 0x101f
call 0x5de
pop $rcx
pop $rbx
pop $rax
nop 
nop 
nop 
nop 
nop 
mov $rax, 0x4
mov $rbx, 0x1
call 0x17c8
cmp [$rbx], [$rax], 0x6
jf [$rbx], 0x1608
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x78e9
mov $rbx, 0x627
add [$rcx], 0x1e86, 0x2476
call 0x5de
pop $rcx
pop $rbx
pop $rax
mov $rax, [$r14]
mov $rbx, 0x6b43
mov $rcx, 0x7fff
push [$rdx]
mov $rdx, 0x79e5
call 0x75d
pop $rdx
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x79e9
mov $rbx, 0x627
add [$rcx], 0xfa6, 0x7041
call 0x5de
pop $rcx
pop $rbx
pop $rax
wmem 0xad8, 0x9ee
wmem 0xad9, 0x0
add [$rbx], 0xac0, 0x2
wmem [$rbx], 0x7fff
jmp 0x168f
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7a8e
mov $rbx, 0x627
add [$rcx], 0x4bbc, 0x337
call 0x5de
pop $rcx
pop $rbx
pop $rax
jmp 0x168f
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7b2e
mov $rbx, 0x627
add [$rcx], 0x4d2e, 0x1840
call 0x5de
pop $rcx
pop $rbx
pop $rax
mov $rax, 0x0
add [$rcx], 0x1, 0x70ac
rmem [$rbx], [$rcx]
add [$rax], [$rax], [$rbx]
mult [$rax], [$rax], 0x7bac
call 0x879
rmem [$rbx], 0x70ac
add [$rbx], [$rbx], 0x70ac
add [$rcx], [$rcx], 0x1
gt [$rbx], [$rcx], [$rbx]
jf [$rbx], 0x1641
mov $rbx, 0x6b43
mov $rcx, 0x7fff
push [$rdx]
mov $rdx, 0x7bb3
call 0x75d
pop $rdx
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7bb7
mov $rbx, 0x627
add [$rcx], 0x1b5b, 0x4a92
call 0x5de
pop $rcx
pop $rbx
pop $rax
wmem 0xad8, 0x9e4
wmem 0xad9, 0x0
jmp 0x168f
pop $rcx
pop $rbx
pop $rax
ret 
push [$rax]
push [$rbx]
push [$rcx]
push [$rdx]
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7c0f
mov $rbx, 0x627
add [$rcx], 0x10db, 0x198d
call 0x5de
pop $rcx
pop $rbx
pop $rax
rmem [$rax], 0xfb0
rmem [$rbx], 0xfb1
call 0x879
rmem [$rbx], 0xfb2
call 0x879
mov $rbx, 0x6b78
mov $rcx, 0x4
push [$rdx]
mov $rdx, 0x7cd0
call 0x75d
pop $rdx
push [$rax]
push [$rbx]
push [$rcx]
mov $rax, 0x7cd4
mov $rbx, 0x627
add [$rcx], 0x48f2, 0x6f
call 0x5de
pop $rcx
pop $rbx
pop $rax
pop $rdx
pop $rcx
pop $rbx
pop $rax
ret 
out "-"
out " "
call 0x61a
out "\n"
ret 
push [$rbx]
push [$rcx]
mov $rax, 0x71c4
mov $rbx, 0x1713
mov $rcx, 0x0
call 0x5de
mov $rax, [$rcx]
pop $rcx
pop $rbx
ret 
push [$rdx]
push [$r11]
rmem [$rdx], 0xad8
add [$r11], [$rax], 0x2
rmem [$r11], [$r11]
cmp [$rdx], [$rdx], [$r11]
jf [$rdx], 0x172c
add [$rcx], [$rcx], 0x1
pop $r11
pop $rdx
ret 
push [$rax]
push [$rbx]
mov $rax, 0x71c4
mov $rbx, 0x1742
call 0x5de
pop $rbx
pop $rax
ret 
push [$rdx]
add [$rdx], [$rax], 0x2
rmem [$rdx], [$rdx]
cmp [$rdx], [$rcx], [$rdx]
jf [$rdx], 0x175b
add [$rax], [$rax], 0x0
rmem [$rax], [$rax]
call 0x16f3
pop $rdx
ret 
push [$rbx]
push [$rcx]
mov $rcx, [$rax]
mov $rax, 0x71c4
mov $rbx, 0x1789
call 0x633
cmp [$rbx], [$rax], 0x7fff
jt [$rbx], 0x1781
add [$rbx], 0x71c4, [$rax]
add [$rbx], [$rbx], 0x1
rmem [$rax], [$rbx]
jmp 0x1784
mov $rax, 0x0
pop $rcx
pop $rbx
ret 
push [$rbx]
mov $rbx, [$rcx]
add [$rax], [$rax], 0x0
rmem [$rax], [$rax]
call 0x6af
pop $rbx
jf [$rax], 0x17a2
mov $rcx, [$rbx]
mov $rbx, 0x7fff
ret 
push [$rbx]
push [$rcx]
add [$rax], [$rax], 0x2
rmem [$rax], [$rax]
jf [$rax], 0x17c0
rmem [$rbx], 0xad8
cmp [$rbx], [$rax], [$rbx]
jt [$rbx], 0x17c0
mov $rax, 0x0
jmp 0x17c3
mov $rax, 0x1
pop $rcx
pop $rbx
ret 
jt [$rax], 0x17d0
add [$rax], [$rbx], 0x1
ret 
jt [$rbx], 0x17dd
add [$rax], [$rax], 0x7fff
mov $rbx, [$r14]
call 0x17c8
ret 
push [$rax]
add [$rbx], [$rbx], 0x7fff
call 0x17c8
mov $rbx, [$rax]
pop $rax
add [$rax], [$rax], 0x7fff
call 0x17c8
ret 
