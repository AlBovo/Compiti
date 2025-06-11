section .data
    enterNumber: db "Enter a number to see if it's even or odd: "
    len0 equ $ - enterNumber
    isEven: db "This number is even!", 0xa
    len1 equ $ - isEven
    isOdd: db "This number is odd!", 0xa
    len2 equ $ - isOdd
    error: db "The text you entered is not a valid number!", 0xa
    len3 equ $ - error

section .text
    global _start
    _start:
        mov rax, 0x1
        mov rdi, 0x1
        lea rsi, [enterNumber]
        mov rdx, len0
        syscall

        call readNum
        and rax, 0x1

        cmp al, 0x1
        mov rax, 0x1
        mov rdi, 0x1
        je _start_odd

        lea rsi, [isEven]
        mov rdx, len1
        syscall
        jmp _exit

        _start_odd:
            lea rsi, [isOdd]
            mov rdx, len2
            syscall

        jmp _exit
    
    readNum:
        sub rsp, 0x10 ; aggiungo 16 bytes
        
        push r12 ;
        push r13 ; preservo i registri ;
        push r14 ;

        xor rax, rax ; read syscall
        xor rdi, rdi ; standard input
        lea rsi, [rsp] ; address dell buff
        mov rdx, 0x10  ; lunghezza del buff
        syscall

        lea rsi, [rsp] ; prendo il buff

        xor r12, r12 ;
        xor r13, r13 ;
        xor r14, r14 ; resetto i registri
        xor rcx, rcx ; 

        readNum_while:
            cmp r14, rax
            jg readNum_finish
            cmp byte [rsi], 0x0a ; se è un \n finisco
            je readNum_finish
            cmp byte [rsi], 0x39 ; se è maggiore di '9' è errato
            jg readNum_error 
            cmp byte [rsi], 0x30 ; se è minore di '0' è errato
            jl readNum_error

            sub byte [rsi], 0x30
            mov cl, byte [rsi]

            ; r12 *= 10
            mov r13, r12
            shl r12, 0x3
            shl r13, 0x1
            add r12, r13
            
            add r12, rcx ; aggiungo il numero alla variabile
            inc r14 ; aumento il contatore
            inc rsi ; aumento il puntatore
        jmp readNum_while

        readNum_error:
            mov rax, 0x1 ; write syscall
            mov rdi, 0x1 ; standard output
            lea rsi, [error] ; buff address 
            mov rdx, len3 ; lunghezza del buff
            syscall
            jmp _exit

        readNum_finish:
            mov rax, r12
            pop r12 ;
            pop r13 ; restoro i registri
            pop r14 ;
            add rsp, 16
            ret

    _exit:
        mov rax, 60
        xor rdi, rdi
        syscall
