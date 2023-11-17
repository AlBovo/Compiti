section .data
    welcome: db "Welcome,", 0xa, "Enter 1 to print your name", 0xa, "Enter 2 to print a random number", 0xa, "Enter 3 to end the program.", 0xa
    pathWhoami: db "/usr/bin/whoami", 0x0

section .text
    global _start
    _start:
        mov rax, 0x1
        mov rdi, 0x1
        lea rsi, [welcome]
        mov rdx, 0x61
        syscall

        sub rsp, 0x1

        xor rax, rax
        xor rdi, rdi
        lea rsi, [rsp]
        mov rdx, 0x2
        syscall

        sub byte [rsp], "0"

        cmp byte [rsp], 1
        jl _start
        je printName
        cmp byte [rsp], 2
        je printRandom
        jmp _exit

    printName:
        mov rax, 0x3b
        mov rdi, pathWhoami
        xor rsi, rsi
        xor rdx, rdx
        syscall
        
    printRandom: ; non è random in realtà
        mov rax, 0x1
        mov rdi, 0x1
        push r11
        mov r11, [rsp - 0x10]
        and r11, 1
        add r11, "0"
        push r11
        lea rsi, byte [rsp]
        pop r11
        pop r11
        mov rdx, 0x1
        syscall

    _exit:
        mov rax, 0x3c
        xor rdi, rdi
        syscall
