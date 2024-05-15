namespace TokenList;

public class TokenList{

    private List<t_token> tokens;
    public TokenList(){
        tokens = new List<t_token>();
    }

    public void AddToken(int tokenCode,String tokenSourceCodeText, int row, int colum){
        tokens.Add(new t_token(tokenCode, tokenSourceCodeText, row, colum));
    }  

    public t_token GetToken(int index){
        //SI LLEGA A DAR ERROR HAY QUE VALIDAR QUE EL INDEX ESTE DENTRO DEL RANGO DE LA LISTA
        return tokens[index];
    }
}

public class t_token{
    public int tokenCode;
    public String tokenSourceCodeText;
    public int row;
    public int colum;


    
    public t_token(int tokenCode, String tokenSourceCodeText, int row, int colum){
        this.tokenCode = tokenCode;
        this.tokenSourceCodeText = tokenSourceCodeText;
        this.row = row;
        this.colum = colum;
    }


}

