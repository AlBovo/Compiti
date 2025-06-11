section .data
    firstNumb: db "Enter the first number: "
    secondNumb: db "Enter the second number: "
    finished: db "Here is the sum: "
    feedLine: db 0x0a
    error: db "The number is not valid!", 0x0a

section .text
    global _start
    _start:
        mov rax, 0x1 ; write syscall
        mov rdi, 0x1 ; standard output
        lea rsi, [firstNumb] ; buff address 
        mov rdx, 0x18 ; lunghezza del buff
        syscall

        call readNum ; prendo il primo numero
        mov r15, rax

        mov rax, 0x1 ; write syscall
        mov rdi, 0x1 ; standard output
        lea rsi, [secondNumb] ; buff address 
        mov rdx, 0x19 ; lunghezza del buff
        syscall
        
        call readNum ; prendo il secondo numero
        add r15, rax

        mov rax, 0x1 ; write syscall
        mov rdi, 0x1 ; standard output
        lea rsi, [finished] ; buff address 
        mov rdx, 0x11 ; lunghezza del buff
        syscall

        mov rdi, r15 ; metto la somma in rdi
        call printNum

        jmp _exit

    printNum:
        push r12 ; mi salvo il registro
        xor r12, r12 ; metto r12=0
        mov rax, rdi

        printNum_while:
            cmp rax, 0x0 ; se rax = 0 allora ho finito di dividere
            je printNum_exit
            xor rdx, rdx ; rdx => 0x0
            mov rcx, 0xa ; rcx => 10
            div rcx ; rax = rax / rcx && rdx = rax mod rcx

            add rdx, 0x30 ; rendo ascii il numero
            sub rsp, 0x1 ; aggiungo sullo stack
            mov [rsp], dl ; sposto sullo stack
            inc r12 ; aumento il contatore

        jmp printNum_while

        printNum_exit:
            mov rax, 0x1 ; write syscall
            mov rdi, 0x1 ; standard input
            lea rsi, [rsp] ; puntatore allo stack della stringa
            mov rdx, r12 ; lunghezza del buffer
            syscall

            add rsp, r12 ; resetto lo stack frame
            pop r12 ; rimuovo r12
            mov rax, 0x1 ; write syscall
            mov rdi, 0x1 ; standard input
            lea rsi, [feedLine] ; puntatore all'accapo
            mov rdx, 1 ; un carattere
            syscall
            ret

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
            mov rdx, 0x19 ; lunghezza del buff
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