namespace TokenList;

static class Constants{

    //TERMINAL SYMBOLS
    public const int TERMINAL_SYMBOL_LG = 1;
    public const int TERMINAL_SYMBOL_LT = 2;
    public const int TERMINAL_SYMBOL_A = 3;
    public const int TERMINAL_SYMBOL_B = 4;
    public const int TERMINAL_SYMBOL_X = 5;
    public const int TERMINAL_SYMBOL_Y = 6;
   // public const int TERMINAL_SYMBOL_OC = 8;


    //NOT TERMINAL SYMBOLS
    public const int NT_SYMBOL_Ciclo = 1;
    public const int NT_SYMBOL_Action = 2;
    public const int NT_SYMBOL_Grab = 3;
    public const int NT_SYMBOL_Hold = 4;
    public const int NT_SYMBOL_Move_away = 5;
    public const int NT_SYMBOL_Get_close = 6;
    public const int NT_SYMBOL_Rotate_left = 7;
    public const int NT_SYMBOL_Rotate_right = 8;
}

public class TokenList{

    private List<t_token> tokens;
    public TokenList(){
        tokens = new List<t_token>();
    }

    public void AddToken(int tokenCode,String tokenSourceCodeText, bool status){
        tokens.Add(new t_token(tokenCode,tokenSourceCodeText, status));
    }  
    
    public void MakeListToken(List<String> Tokens){
        tokens.Clear();
        foreach (string item in Tokens){
            switch(item){
                case "LG True":
                    AddToken(Constants.TERMINAL_SYMBOL_LG, item, true);
                break;
            
                case "LT True":
                    AddToken(Constants.TERMINAL_SYMBOL_LT, item, true);
                break;
                
                case "A True":
                    AddToken(Constants.TERMINAL_SYMBOL_A, item, true);
                break;
                
                case "B True":
                    AddToken(Constants.TERMINAL_SYMBOL_B, item, true);
                break;
                
                case "X True":
                    AddToken(Constants.TERMINAL_SYMBOL_X, item, true);
                break;
                
                case "Y True":
                    AddToken(Constants.TERMINAL_SYMBOL_Y, item, true);
                break;
            }
        }
    }

    public List<t_token> GetTokenList(){
        return this.tokens;
    }
    
    public t_token GetToken(int index){
        //SI LLEGA A DAR ERROR HAY QUE VALIDAR QUE EL INDEX ESTE DENTRO DEL RANGO DE LA LISTA
        return tokens[index];
    }

    public int getMax(){
        return tokens.Count;
    }
}

public class t_token{
    
    public int tokenCode;
    public String tokenSourceCodeText;
    public bool status;
    

    public t_token(int tokenCode,String tokenSourceCodeText, bool status ){
        this.tokenCode = tokenCode;
        this.tokenSourceCodeText = tokenSourceCodeText;
        this.status = status;
    }
}

