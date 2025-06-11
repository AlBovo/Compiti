section .data
    hello: db "Enter the word: "
    len equ $ - hello
    yepPalindrome: db "The string is palindrome!", 0xa
    len1 equ $ - yepPalindrome
    nopPalindrome: db "The string is not palindrome!", 0xa
    len2 equ $ - nopPalindrome

section .text
    global _start
    _start: ; I/O del programma
        mov rax, 0x1 ; syscall write
        mov rdi, rax ; standard output 
        lea rsi, [hello] ; address del buffer
        mov rdx, len ; lunghezza del buffer
        syscall

        call isPalindrome

        mov r12, rax
        mov rax, 0x1 ; preparo i registri per un write
        mov rdi, rax ; preparo i registri per un write
        cmp r12, 0x1
        je _start_yes
        
        ; sarebbe un no :)
        lea rsi, [nopPalindrome]
        mov rdx, len2
        syscall
        jmp _exit

        _start_yes:
            lea rsi, [yepPalindrome]
            mov rdx, len1
            syscall
        
        jmp _exit

    isPalindrome:
        push r12 ; mi salvo il registro
        push r13 ; mi salvo il registro
        sub rsp, 0x10 ; aggiungo 16 bytes allo stack

        xor rax, rax ; syscall read
        xor rdi, rdi ; standard input
        lea rsi, [rsp] ; address del buffer
        mov rdx, 0x10 ; lunghezza del buffer
        syscall

        cmp rax, 0x1 ; se la stringa ha lunghezza 1 allora è palindroma
        je isPalindrome_finish

        mov r12, 0x0 ; puntatore al primo char
        mov r13, rax ; lunghezza del buff
        xor rax, rax ; resetto il registro
        inc rax ; lo setto a true
        cmp byte [rsp+r13-0x1], 0xa ; l'ultimo carattere è un carattere 
        je isPalindrome_n
        
        isPalindrome_while:
            cmp r13, r12
            jle isPalindrome_finish
            mov bl, byte [rsp+r13]
            cmp byte [rsp+r12], bl
            jne isNotPalindrome
            inc r12 ; aumento il puntatore all'inizio della stringa
            dec r13 ; decremento il puntatore alla fine della stringa

        jmp isPalindrome_while
    
        isPalindrome_n:
            sub r13, 0x2 ; "tolgo" il \n dalla stringa
            jmp isPalindrome_while ; ritorno da dove sono jumpato 
        
        isNotPalindrome:
            dec rax ; lo setto a false
        
        isPalindrome_finish:
            add rsp, 0x10 ; resetto lo stack frame
            pop r12 ; restoro il registro
            pop r13 ; restoro il registro
        ret 

    _exit:
        mov rax, 0x3c ; syscall exit
        xor rdi, rdi ; error 0
        syscall
