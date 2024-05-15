using TokenList;
namespace Scanner;

public class Reader{
    List<string> TokenList;

    public void ReadDataSheet(){
          String line, data;
            data = "controller_data_003.txt";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(data);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null){
                    //write the line to console window
                    if(line.Contains("True")){
                        Console.WriteLine(line);
                        TokenList.Add(line);
                    }
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

    }
    public List<string> GetTokenList(){
        return TokenList;
    }

}