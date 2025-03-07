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


static public class Kalkulator{
    /// <summary>
    /// Sjekker om det er en nevner eller ikke.
    /// </summary>
    /// <param name="test"></param>

    static public bool ErNevner(char test){
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

    /// <summary>
    /// Ganger A med B
    /// </summary>
    /// <returns>Ganget verdien av A * B</returns>
    public static dynamic Mult(dynamic a, dynamic b){
        return a * b;
    }

    // Vise at jeg vet hva, og forstår hva overloads er, og hvorfor de finnes. Men disse her brukes ikke,
    // p.g.a jeg sender mult som en "reference", og det er derfor ikke mulig (for C#) 
    // å vite hvilken av de som skal brukes (så må ha en dynamic en).
    static public int Mult(int a, int b){
        return a * b;
    }

    static public double Mult(double a, double b){
        return a * b;
    }


    /// <summary>
    /// Deler a med b
    /// </summary>
    /// <returns>delte sum av A / D</returns>
    static public dynamic Div(dynamic a, dynamic b){
        // Tvinger double return, da dynamic foretrekker å returnere int, selv om verdien helt tydelig ikke er.
        return (double)a / (double)b;
    }

    /// <summary>
    /// Går over, og enten ganger, eller deler (varierende av calcFunc).
    /// Så fjerner vi nummerene og nevneren, og gir posisjonen heller summen av det vi kalkulerte.
    /// </summary>
    /// <param name="calcFunc">Funksjon for å enten dele, eller gange</param>
    /// <param name="numSeq">Liste av nummer og nevnere (som strings)</param>
    /// <param name="i">index hvor nevner er</param>
    /// <returns></returns>
    static public List<string> KalkulererSettet(Func<dynamic, dynamic, dynamic> calcFunc, List<string> numSeq, int i){
        dynamic a = GetNum(numSeq[i - 1]);
        dynamic b = GetNum(numSeq[i + 1]);
        numSeq.RemoveAt(i + 1);
        numSeq.RemoveAt(i);
        numSeq[i - 1] = calcFunc(a, b).ToString();
        return numSeq;
    }

    /// <summary>
    /// Går igjennom listen og legger til, eller trekker fra verdiene in i en 'sum'.
    /// </summary>
    /// <param name="numSeq">Parsed set av nummer og nevnere</param>
    /// <returns>Summen som er kalkulert i enten double, eller int.</returns>
    static public dynamic AddSubCheck(List<string> numSeq){
        dynamic sum = 0;
        bool firstPass = true;
        if(numSeq.Count > 1){
            for (int i = 0; i < numSeq.Count ; i++){
                if (i % 2 != 0){
                    if(firstPass){
                        firstPass = false;
                        sum = GetNum(numSeq[i - 1]);
                    }

                    if(numSeq[i] == "+"){
                        sum += GetNum(numSeq[++i]);
                    }else if(numSeq[i] == "-"){
                        sum -= GetNum(numSeq[++i]);
                    }
                }
            }
        // Hvis vi ganger/deler kun 1 nummer, så ligger dette i NumSeq[0].
        }else{
            sum = GetNum(numSeq[0]);
        }
        return sum;
    }

    /// <summary>
    /// Går igjennom listen, og summer opp med ganging, eller deling i riktig rekkefølge.
    /// </summary>
    /// <param name="numSeq">parsed-list av nummer og nevnere.</param>
    /// <returns>Liste med ferdi kalkulert gange/dele verdi'er (som string) uten brukte nevnere (*, /)</returns>
    static public List<string> MulDivCheck(List<string> numSeq){
        for(int i = 0; i < numSeq.Count ; i++){
            if(i % 2 != 0){ // even = numbers
                if (numSeq[i] == "*"){
                    numSeq = KalkulererSettet(Mult, numSeq, i);
                }
                else 
                if(numSeq[i] == "/" || numSeq[i] == "\\"){
                    numSeq = KalkulererSettet(Div, numSeq, i);
                }
            }
        }

        return numSeq;
    }

    /// <summary>
    /// Printer ut en enkel og forstå Error melding uten å bryte program flyten.
    /// </summary>
    static public void Error(){
            Console.WriteLine("ugylding input. Må være nummer, nevner, nummer");
    }

    /// <summary>
    /// Hoved funksjonen for kalkulatoren, sender input videre.
    /// </summary>
    /// <param name="input">bruker input som string</param>
    /// <returns>Summen som er kalkulert</returns>
    static public dynamic Kalkuler(string input){
        dynamic sum = 0;
        try{
            List<string> numSeq = ParseInput(input);
            numSeq = MulDivCheck(numSeq);
            sum = AddSubCheck(numSeq);
        }catch(ArgumentOutOfRangeException){
            Error();
        }catch(InvalidCastException){
            Error();
        }
        return sum;
    }

    /// <summary>
    /// Parser en string til en liste av nummer og nevnere.
    /// </summary>
    /// <param name="input">input string'en</param>
    /// <returns>liste med nummer og nevnere.</returns>
    static public List<string> ParseInput(string input){
        List<string> output = new List<string>();
        string tmpString = "";
        for (int i = 0 ; i < input.Length ; i++){
            if (ErNevner(input[i])){
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
    /// converterer nummere (Som en string) til enten en int eller en double.
    /// </summary>
    /// <param name="numberString">Nummeret vi ønsker å convertere (som string)</param>
    /// <returns>enten double eller int.</returns>
    static public dynamic GetNum (string numberString){
        if(int.TryParse(numberString, out int intValue)){
            return intValue;
        }else if (double.TryParse(numberString, out double doubleValue)){
            return doubleValue;
        }else{
            throw new InvalidCastException($"input: {numberString} is invalid, only accepts a number of either int (2, 3, 4, etc), or double (2.3, 4.3, etc)");
        }
    }
}