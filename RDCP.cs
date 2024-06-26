using System;
using System.Collections.Generic;
using TokenList;

namespace RDCP
{
    static class Constants
    {
        // TERMINAL SYMBOLS
        public const int TERMINAL_SYMBOL_LG = 1;
        public const int TERMINAL_SYMBOL_LT = 2;
        public const int TERMINAL_SYMBOL_A = 3;
        public const int TERMINAL_SYMBOL_B = 4;
        public const int TERMINAL_SYMBOL_X = 5;
        public const int TERMINAL_SYMBOL_Y = 6;

        // NOT TERMINAL SYMBOLS
        public const int NT_SYMBOL_Ciclo = 1;
        public const int NT_SYMBOL_Action = 2;
        public const int NT_SYMBOL_Grab = 3;
        public const int NT_SYMBOL_Hold = 4;
        public const int NT_SYMBOL_Move_away = 5;
        public const int NT_SYMBOL_Get_close = 6;
        public const int NT_SYMBOL_Rotate_left = 7;
        public const int NT_SYMBOL_Rotate_right = 8;

        // Assembly Language Instructions
        public const int A_LG = 9;  // Grab Object
        public const int A_LT = 10; // Hold Object
        public const int A_A = 11;  // Move away Object
        public const int A_B = 12;  // Get close to Object
        public const int A_X = 13;  // Rotate left
        public const int A_Y = 14;  // Rotate right
        public const int A_END = 8; // End program
    }

    public class RDCP_ex
    {
        private TokenList.TokenList tokenlist;
        private TokenList.TokenList currentToken;
        private bool parseError;
        private int n;

        // Processor Registers
        private int PC = 0;   // Program counter
        private int IR1 = 0;  // Instruction Register 1
        private int ACC = 0;  // Accumulator
        private int[] mem = new int[256]; // Memory

        // Flags
        private bool FLAG_EQUAL_TO_ZERO = false;
        private bool FLAG_GREATER_THAN_ZERO = false;
        private bool FLAG_LESS_THAN_ZERO = false;

        public RDCP_ex(TokenList.TokenList tokenlist)
        {
            this.n = 0;
            this.tokenlist = tokenlist;
            this.currentToken = tokenlist;
            this.parseError = false;
        }

        public bool CurrentToken(int NTSymbol)
        {
            if (n >= currentToken.getMax())
            {
                return false;
            }
            else if (currentToken.GetToken(n).tokenCode == NTSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Expect(int Tsymbol)
        {
            if (CurrentToken(Tsymbol))
            {
                Console.Write($"\nToken syntactically OK = {currentToken.GetToken(n).tokenSourceCodeText}");
                n++;
            }
            else
            {
                parseError = true;
                Console.Write($"\nSyntax Error = {currentToken.GetToken(n).tokenSourceCodeText}");
            }
        }

        public bool CurrentTokenInFirst(int NTSymbol)
        {
            bool res = false;
            switch (NTSymbol)
            {
                case Constants.NT_SYMBOL_Ciclo:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_A)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_B)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_X)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_Y)) res = true;
                    break;

                case Constants.NT_SYMBOL_Action:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_A)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_B)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_X)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_Y)) res = true;
                    break;

                case Constants.NT_SYMBOL_Grab:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    break;

                case Constants.NT_SYMBOL_Hold:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    break;

                case Constants.NT_SYMBOL_Move_away:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_A)) res = true;
                    break;
                case Constants.NT_SYMBOL_Get_close:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_B)) res = true;
                    break;

                case Constants.NT_SYMBOL_Rotate_left:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_X)) res = true;
                    break;

                case Constants.NT_SYMBOL_Rotate_right:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_Y)) res = true;
                    break;
            }
            return res;
        }

        public void Ciclo()
        {
            if (CurrentTokenInFirst(Constants.NT_SYMBOL_Grab))
            {
                Grab();
                if (n < currentToken.getMax() && CurrentTokenInFirst(Constants.NT_SYMBOL_Hold))
                {
                    Hold();
                    if (n < currentToken.getMax() && CurrentTokenInFirst(Constants.NT_SYMBOL_Move_away))
                    {
                        Move_away();
                    }
                    else if (n < currentToken.getMax() && CurrentTokenInFirst(Constants.NT_SYMBOL_Get_close))
                    {
                        GetClose();
                    }
                    else if (n < currentToken.getMax() && CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_left))
                    {
                        Rotate_left();
                    }
                    else if (n < currentToken.getMax() && CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_right))
                    {
                        Rotate_right();
                    }
                    else if (n >= currentToken.getMax())
                    {
                        // No more tokens, valid sequence ending with LT
                        return;
                    }
                    else
                    {
                        parseError = true;
                        Console.WriteLine("\nSyntax Error: Expected A, B, X, or Y after LT");
                    }
                }
                else if (n >= currentToken.getMax())
                {
                    // No more tokens, valid sequence ending with LG
                    return;
                }
                else if (n < currentToken.getMax() && CurrentTokenInFirst(Constants.NT_SYMBOL_Move_away) ||
                         CurrentTokenInFirst(Constants.NT_SYMBOL_Get_close) ||
                         CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_left) ||
                         CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_right))
                {
                    parseError = true;
                    Console.WriteLine("\nSyntax Error: Expected LT after LG");
                }
                else if (n >= currentToken.getMax())
                {
                    // No more tokens, valid sequence ending with LG
                    return;
                }
            }
            else
            {
                parseError = true;
                Console.WriteLine("\nSyntax Error: Expected LG at the beginning");
            }
        }

        public void Action()
        {
            if (CurrentTokenInFirst(Constants.NT_SYMBOL_Grab))
            {
                Grab();
            }
            else if (CurrentTokenInFirst(Constants.NT_SYMBOL_Hold))
            {
                Hold();
            }
            else if (CurrentTokenInFirst(Constants.NT_SYMBOL_Move_away))
            {
                Move_away();
            }
            else if (CurrentTokenInFirst(Constants.NT_SYMBOL_Get_close))
            {
                GetClose();
            }
            else if (CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_left))
            {
                Rotate_left();
            }
            else if (CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_right))
            {
                Rotate_right();
            }
        }

        // GRAB ::= "LG"
        public void Grab()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
            ExecuteInstruction(Constants.A_LG);
        }

        // HOLD ::=  "LT"
        public void Hold()
        {
            Expect(Constants.TERMINAL_SYMBOL_LT);
            ExecuteInstruction(Constants.A_LT);
        }

        // MOVE_AWAY ::= "A"
        public void Move_away()
        {
            Expect(Constants.TERMINAL_SYMBOL_A);
            ExecuteInstruction(Constants.A_A);
        }

        public void GetClose()
        {
            Expect(Constants.TERMINAL_SYMBOL_B);
            ExecuteInstruction(Constants.A_B);
        }

        // ROTATE_LEFT ::= "X"
        public void Rotate_left()
        {
            Expect(Constants.TERMINAL_SYMBOL_X);
            ExecuteInstruction(Constants.A_X);
        }

        // ROTATE_RIGHT ::= "Y"
        public void Rotate_right()
        {
            Expect(Constants.TERMINAL_SYMBOL_Y);
            ExecuteInstruction(Constants.A_Y);
        }

        // EXECUTE INSTRUCTION
        private void ExecuteInstruction(int instruction)
        {
            mem[PC++] = instruction;
            switch (instruction)
            {
                case Constants.A_LG:
                    // Logic for LG
                    break;
                case Constants.A_LT:
                    // Logic for LT
                    break;
                case Constants.A_A:
                    // Logic for A
                    break;
                case Constants.A_B:
                    // Logic for B
                    break;
                case Constants.A_X:
                    // Logic for X
                    break;
                case Constants.A_Y:
                    // Logic for Y
                    break;
                case Constants.A_END:
                    // Logic for END
                    break;
                default:
                    throw new InvalidOperationException("Unknown instruction");
            }
        }

        public void parser_RDCP()
        {
            parseError = false;
            currentToken = tokenlist;
            Ciclo();
        }
    }
}
