/*parseString -> inputString:
    string[] output
    string currentworking
    bool operatorFound = false
    loop over string:
        if operator-char:
            if(operatorFound = true)
                output.push <- currentWorking
                operatorFound = false
                continue 
            else
                operatorFound = true
                continue
        else is-not-whitespace:
            currentWorking += current-char*/


static public class Kalkulator{
    static private bool isOperator(char test){
        switch (test){
            case '+':
            case '-':
            case '/':
            case '\\':
            case '*':
                return true;
        }
        return false;
    }

    struct  tempValues{
        public string firstNum;
        public string instruction;
    }

    static public List<string[]> parseInput(string input){
        List<string[]> parsedOutput = new List<string[]>();
        tempValues tmp = new tempValues();
        string currentWorking = "";
        bool operatorFound = false;

        for(int i = 0; i < input.Length ; i++){
            if(isOperator(input[i])){
                if(operatorFound){
                    operatorFound = false;
                    parsedOutput.Add([tmp.firstNum, tmp.instruction, currentWorking]);
                    currentWorking = "";
                    continue;
/*
                output.push <- currentWorking
                operatorFound = false
                continue */
                }else{
                    tmp.firstNum = currentWorking;
                    currentWorking = "";
                    tmp.instruction = input[i].ToString();
                    operatorFound = true;
                    continue;
                /*operatorFound = true
                continue*/
                }
            }else if(input[i] != ' '){
                currentWorking += input[i];
            }
        }

        if(operatorFound){
                    operatorFound = false;
                    parsedOutput.Add([tmp.firstNum, tmp.instruction, currentWorking]);
                    currentWorking = "";
        }
        return parsedOutput;
    }
}