/*
I denne oppgaven skal dere modellere ut en klasse med forskjellige overloads, og designe programflyt som kjører de forskjellige overloadene basert på brukerinput.

Forslag til denne oppgaven vil være å lage et kalkulatorprogram, som leser forskjellige inputs, og gjør operasjoner basert på hva brukeren spør om.
Programmet kan spør bruker om en operasjon de ønsker å gjøre. Så, spørre bruker om hva data de vil gjøre operasjonen mot.
Her kan det kanskje være lurt å finne en smart måte å la bruker skrive inn flere tall. Her må både parsing og string manipulasjon brukes.

Tips:
 - Husk at her kan vi la programmet vårt kjøre i en while loop, slik at det kjører til bruker avslutter selv.
 - Tenk på å sette opp smarte overloads for hver operasjon.
 - Kanskje vi kan be bruker om en rekke tall de vil gjøre operasjonen mot, sepparert med et kjent tegn vi kan bruke senere for å splitte input?

Dere står fritt til å lage et annet program, så lenge det tar i bruk modeller, og overloading av metoder, samt programflyt.

Husk å planlegge med pseudokode og skisser.

Lykke til!
*/

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



kalkulasjon:
    loop igjennon og sjekk om det er * eller /.
        Legg i en temp liste.

"Display menu:"
    Velkommen til kalulatoren. Skriv quit for å avslutte.
    du bruker ved å skrive in num, operasjon, num, så enter.

Operasjoner:
    add, sub, div, mult
    Params: dynamic, dynamic -> sjekker type inni method, og kalkulerer de sammen.

psudo main:
    while true
        get input
        if input is quit:
            exit
        
        parsedString[[operation, val, val], ditto] = parse input:

        kalkulasjon()
    


        double sum = 0
        loop parsedString:
            switch operation:
                pass val1, val2 to add/sub/div/mul, add return to sum.

        if sum (double) contain no .0 values, convert to int.

        print sum.
*/


/* re-tenking

1 + 2 * 3 + 4 + 5

1 + 6 + 4 + 5


first-pass <- check previous. Other passes only check next.

expected:
    mult: 2 * 3
    add: 1 + 3 + 4 + 5

loop:
    if *:
        add 2, *, 3

*/

// List<string> val = Kalkulator.parseInput("1 + 2 + 5 \\ 3.4");
// for (int i = 0 ; i < val.Count ; i++){
//     if((i % 2) == 0){
//         Console.WriteLine($"numer: {Kalkulator.getNum(val[i])}");
//     }else{
//         Console.WriteLine($"Operator: {val[i]}");
//     }
// }

// Kalkulator.Kalkuler("1 + 3 * 4 + 5 / 2");


Meny.Start();