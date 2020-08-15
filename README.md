# MiniatureinCSharp
It is an implementation of a similar-to-MIPS language called Miniature in C Sharp.

Here are sample instructions of Miniature:
  
  1.
    lw	1,0,five
    lw	2,1,2
    start	add	1,1,2
    beq	0,1,done
    j	start
    done	halt
    five	.fill	5
    neg1	.fill	-1
    stAddr	.fill	start

The program will be prompt the user with a user interface asking for commands ending with "halt". Then, after processing each line of code, it generates the assembly code of user-enetered code.
