    public static class Meny{
        static public void Start(){
            string? input = "";
            Console.WriteLine("Velkommen til kalulatoren. Skriv quit, eller exit for å avslutte.");
            Console.WriteLine("du bruker ved å skrive in num, operasjon, num, så enter."); 
            Console.WriteLine("Ex: 2 + 3 * 4\n");
            while(true){
                Console.Write(">> ");
                input = Console.ReadLine();
                Console.Clear();
                if(input == null || input.ToLower() == "quit" || input.ToLower() == "exit"){
                    Environment.Exit(0);
                }
                if (input.Length > 0){
                    dynamic sum = Kalkulator.Kalkuler(input);
                    Console.WriteLine($"Sum: {sum}");
                }
            }
        }
}