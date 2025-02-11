/*
parseString -> inputString:
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
            currentWorking += current-char
*/


using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

static public class Kalkulator{
    /// <summary>
    /// Check if passed character is an math-operator or not
    /// </summary>
    /// <param name="test"></param>
    /// <returns></returns>
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


    static public dynamic mult(dynamic a, dynamic b){
        return a * b;
    }

    static public int mult(int a, int b){
        return a * b;
    }

    static public double mult(double a, double b){
        return a * b;
    }


    static private List<string> calcTest(Func<dynamic, dynamic, dynamic> test, List<string> numSeq, int i){
        dynamic a = getNum(numSeq[i - 1]);
        dynamic b = getNum(numSeq[i + 1]);
        numSeq.RemoveAt(i + 1);
        numSeq.RemoveAt(i);
        numSeq[i - 1] = test(a, b).ToString();
        return numSeq;
    }


    static private dynamic add(List<string> numSeq, int i, int sum){
        return sum;
    }

    static private dynamic addSubCheck(List<string> numSeq){
        dynamic sum = 0;
        bool firstPass = true;
        for (int i = 0; i < numSeq.Count ; i++){
            if (i % 2 != 0){
                if(firstPass){
                    firstPass = false;
                    sum = getNum(numSeq[i - 1]);
                }
                if(numSeq[i] == "+"){
                    sum += getNum(numSeq[++i]);
                }else if(numSeq[i] == "-"){
                    sum -= getNum(numSeq[++i]);
                }
            }
        }
        return sum;
    }

    static private List<string> mulDivCheck(List<string> numSeq){
        for(int i = 0; i < numSeq.Count ; i++){
            if(i % 2 != 0){ // even = numbers
                if (numSeq[i] == "*"){
                    numSeq = calcTest(mult, numSeq, i);
                }
                // else if(numSeq[i] == "/" || numSeq[i] == "\\"){
                //     // en funksjon som gjør det?
                //     numSeq = calcTest(div, numSeq, i);
                // }
            }
        }

        return numSeq;
    }

    static public void Kalkuler(string input){
        List<string> numSeq = parseInput(input);
        numSeq = mulDivCheck(numSeq);
        dynamic sum = addSubCheck(numSeq);
        Console.WriteLine($"sum = {sum}");
    }

    /// <summary>
    /// Parses a string-input into an list of strings separating the numbers, with the operators.
    /// </summary>
    /// <param name="input">The user inputed string</param>
    /// <returns>list separating numbers and operators in sequence.</returns>
    static public List<string> parseInput(string input){
        List<string> output = new List<string>();
        string tmpString = "";
        for (int i = 0 ; i < input.Length ; i++){
            if (isOperator(input[i])){
                output.Add(tmpString);
                output.Add(input[i].ToString());
                tmpString = "";
            }else if (input[i] != ' '){
                tmpString += input[i];
            }
        }

        if (tmpString.Length > 0)
            output.Add(tmpString);
        return output;
    }

    /// <summary>
    /// Convert the passed number (as string) into either an int, or a float.
    /// </summary>
    /// <param name="numberString">The number we want to convert</param>
    /// <returns>Either int, or float of the passed number</returns>
    static public dynamic getNum (string numberString){
        if(int.TryParse(numberString, out int intValue)){
            return intValue;
        }else if (float.TryParse(numberString, out float floatValue)){
            return floatValue;
        }else{
            throw new Exception($"input: {numberString} is invalid, only accepts a number of either int (2, 3, 4, etc), or float (2.3, 4.3, etc)");
        }
    }
}