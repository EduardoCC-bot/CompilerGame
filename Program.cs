using System;
using System.Collections.Generic;
using TokenList;
using Scanner;
using Reader = Scanner.Reader;
using tokenList = TokenList.TokenList;
using RDCP;
using Microsoft.VisualBasic;

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
            
            iterations(StrTokenList, tokenLists);
        }

        public static void iterations(List<string> StrTokenList, tokenList tokenLists){
            List<string> aux = new List<string>();
            for(int i = 0; i < StrTokenList.Count; i++){
                if(StrTokenList[i] is "LG True"){
                    do{
                        aux.Add(StrTokenList[i]);
                        i++;
                        if(i >= StrTokenList.Count){
                            i++;
                            break;
                        }
                    }while(StrTokenList[i] != "LG True");
                    i--;
                    tokenLists.MakeListToken(aux);
                    RDCP_ex parser = new RDCP_ex(tokenLists);
                    parser.parser_RDCP();
                    Console.WriteLine("\n=============================");
                    aux.Clear();
                }
            }
            

        }
    }
}
