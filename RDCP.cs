using System.Diagnostics;
using TokenList;

namespace RDCP;

public class RDCP_ex{

    TokenList.TokenList tokenlist;
    TokenList.TokenList currentToken;
    bool parseError;
    int n = 0;

    bool CurrentToken(int TSymbol){
        if (currentToken.GetToken(n).tokenCode == TSymbol){
            return true;
        }else{
            return false;
        }
    }

    void Expect(int TSymbol){
        if(CurrentToken(TSymbol)){
            Console.WriteLine($"\nToken syntatically OK = {currentToken.GetToken(n).tokenSourceCodeText}, Row = {currentToken.GetToken(n).row}, Column = {currentToken.GetToken(n).colum}");
            n++;
        }else{
            parseError = true;
            Console.WriteLine($"\nSyntax Error = {currentToken.GetToken(n).tokenSourceCodeText}, Row = {currentToken.GetToken(n).row}, Column {currentToken.GetToken(n).colum}");
        }
    }

    bool CurrentTokenInFirst(int NTSymbol){
        bool res = false;
        switch (NTSymbol){ 
            //AQUI DEBEN DE IR LOS NT SYMBOLS QUE DETECTE DE MI GRAMMAR
        }
        return res;
    }

///EN ESTA PARTE DEBEN DE IR LAS INSTRUCCIONES QUE TENGA DE MI GRAMAR EJEMPLO: <summary>
/// //InstrObject ::= "PICKUP" | "PUTDOWN"
    /*void InstrObject(){
        if(CurrentToken(TERMINAL_SYMBOL_PICKUP)){
            Expect(TERMINAL_SYMBOL_PICKUP);
        } else {
            Expect(TERMINAL_SYMBOL_PUTDOWN);
            }
    }*/

/// </summary>


    void parser_RDCP(){
        parseError = false;
        currentToken = tokenlist;
    }

}
