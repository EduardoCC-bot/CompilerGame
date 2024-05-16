using System;
using System.Collections.Generic;
using TokenList;
using Scanner;
using Reader = Scanner.Reader;
using tokenList = TokenList.TokenList;
using RDCP; 

namespace CompilerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> StrTokenList = new List<string>();
            Reader sc = new Reader();
            tokenList tokenLists = new tokenList();

            StrTokenList = sc.getTokenList();
            tokenLists.MakeListToken(StrTokenList);

            RDCP_ex parser = new RDCP_ex(tokenLists);
            parser.parser_RDCP();
        }
    }
}
