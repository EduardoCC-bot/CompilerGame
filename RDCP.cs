using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    }

    public class RDCP_ex
    {
        private TokenList.TokenList tokenlist;
        private TokenList.TokenList currentToken;
        private bool parseError;
        private int n;

        public RDCP_ex(TokenList.TokenList tokenlist)
        {
            this.n = 0;
            this.tokenlist = tokenlist;
            this.currentToken = tokenlist;
            this.parseError = false;
        }

        public bool CurrentToken(int NTSymbol)
        {
            if (currentToken.GetToken(n).tokenCode == NTSymbol)
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
                Console.Write($"\nToken syntactically OK ={currentToken.GetToken(n).tokenSourceCodeText}");
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
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    break;

                case Constants.NT_SYMBOL_Move_away:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_A)) res = true;
                    break;

                case Constants.NT_SYMBOL_Get_close:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_B)) res = true;
                    break;

                case Constants.NT_SYMBOL_Rotate_left:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_X)) res = true;
                    break;

                case Constants.NT_SYMBOL_Rotate_right:
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LG)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_LT)) res = true;
                    if (CurrentToken(Constants.TERMINAL_SYMBOL_Y)) res = true;
                    break;
            }
            return res;
        }

        /*--------------------------------------------------- */
        public void Ciclo()
        {
            Action();
            while (CurrentTokenInFirst(Constants.NT_SYMBOL_Action))
            {
                Action();
            }
        }

        /*
            GRAB
            HOLD
            MOVE_AWAY
            GET_CLOSE
            ROTATE_LEFT
            ROTATE_RIGHT
         */
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
                Get_close();
            }
            else if (CurrentTokenInFirst(Constants.NT_SYMBOL_Rotate_left))
            {
                Rotate_left();
            }
            else
            {
                Rotate_right();
            }
        }

        // GRAB ::= "LG"
        public void Grab()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
        }

        // HOLD ::=  "LG" "LT"
        public void Hold()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
            Expect(Constants.TERMINAL_SYMBOL_LT);
        }

        // MOVE_AWAY ::= "LG" "LT" "A"
        public void Move_away()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
            Expect(Constants.TERMINAL_SYMBOL_LT);
            Expect(Constants.TERMINAL_SYMBOL_A);
        }

        // GET_CLOSE ::= "LG" "LT" "B"
        public void Get_close()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
            Expect(Constants.TERMINAL_SYMBOL_LT);
            Expect(Constants.TERMINAL_SYMBOL_B);
        }

        // ROTATE_LEFT ::= "LG" "LT" "X"
        public void Rotate_left()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
            Expect(Constants.TERMINAL_SYMBOL_LT);
            Expect(Constants.TERMINAL_SYMBOL_X);
        }

        // ROTATE_RIGHT ::= "LG" "LT" "Y"
        public void Rotate_right()
        {
            Expect(Constants.TERMINAL_SYMBOL_LG);
            Expect(Constants.TERMINAL_SYMBOL_LT);
            Expect(Constants.TERMINAL_SYMBOL_Y);
        }

        public void parser_RDCP()
        {
            parseError = false;
            currentToken = tokenlist;
            Ciclo();
        }
    }
}
