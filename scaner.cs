using System.Security.Cryptography.X509Certificates;
using TokenList;
namespace Scanner;

public class Reader{
    List<string> TokenList;
    String data;

    public Reader(){
        TokenList = new List<string>();
    }

    public List<String> getTokenList(){
        ReadDataSheet(@"C:\Users\ecarr\Desktop\Escuela\6to_semestre\Compiladores\Poyect\CompilerGame\controller_data.txt");
        return this.TokenList;
    }

    /*public int iteraitons(){
        int n = 0;  
        ReadDataSheet(@"C:\Users\ecarr\Desktop\Escuela\6to_semestre\Compiladores\Poyect\CompilerGame\controller_data.txt");
        for(int i = 0; i < this.TokenList.Count; i++){
            if(TokenList[i] == "LG True"){
                n++;
            }
        }
        return n;
    }*/
    public void ReadDataSheet(String data){
        String line;    
            try
            {
                StreamReader sr = new StreamReader(data);
                line = sr.ReadLine();
                while (line != null){
                    if(line.Contains("True")){
                        //Console.WriteLine(line);
                        this.TokenList.Add(line);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
    }

    public int simplifyList(){

        return 0;
    }
}