    public static class Meny{
        /// <summary>
        ///  Starter kalkulatoren.
        /// </summary>
        static public void Start(){
            string? input = "";
            Console.WriteLine("Velkommen til kalulatoren. Skriv quit, eller exit for å avslutte.");
            Console.WriteLine("du bruker ved å skrive in num, operasjon, num, så enter."); 
            Console.WriteLine("Ex: 2 + 3 * 4\n");

            while(true){
                Console.Write(">> "); // Gir bedre feedback at 'her skal du skrive'.
                input = Console.ReadLine();
                Console.Clear(); // Bedre bruker-følelse / flyt.
                if(input == null || input.ToLower() == "quit" || input.ToLower() == "exit"){
                    Environment.Exit(0);
                }
                if (input.Length > 0){ // Vi ignorerer tomme strings.
                    dynamic sum = Kalkulator.Kalkuler(input);
                    Console.WriteLine($"Sum: {sum}");
                }
            }
        }
}