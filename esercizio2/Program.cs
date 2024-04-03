﻿//Creare una .NET Console App che simuli le funzionalità di base di una calcolatrice. Al lancio, l'applicazione presenterà all'utente un menu di selezione per il tipo di operazione matematica desiderata: addizione, sottrazione, moltiplicazione, divisione, o l'opzione per terminare l'esecuzione del programma. Una volta selezionata l'operazione, l'applicazione richiederà all'utente di inserire due valori numerici. Dopo l'inserimento, calcolerà e visualizzerà il risultato dell'operazione scelta. L'applicazione poi riproporrà il menu per permettere all'utente di eseguire ulteriori calcoli o di terminare il programma. Durante l'interazione, l'applicazione gestirà eventuali errori di input, assicurando che l'utente possa inserire solo numeri validi e prevenendo il crash del programma in caso di errori di digitazione.

namespace esercizio2
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.Write(
                    "Seleziona l'operazione desiderata:\n1. Addizione\n2. Sottrazione\n3. Moltiplicazione\n4. Divisione\n5. Esci\nScelta: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        EseguiOperazione('+');
                        break;
                    case "2":
                        EseguiOperazione('-');
                        break;
                    case "3":
                        EseguiOperazione('*');
                        break;
                    case "4":
                        EseguiOperazione('/');
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("\nScelta non valida. Riprova.");
                        Console.Write("Premi un tasto per continuare..."); // Attesa di un input per continuare
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void EseguiOperazione(char operatore)
        {
            var numeri = new double[2];

            for (var i = 0; i < 2; i++)
            {
                Console.Write($"Inserisci il {(i == 0 ? "primo" : "secondo")} numero: ");
                while (!double.TryParse(Console.ReadLine(), out numeri[i])) // Ripeti finché l'input non è un numero
                {
                    Console.WriteLine("\nInput non valido. Inserisci un numero valido.");
                    Console.Write($"{(i == 0 ? "Primo" : "Secondo")} numero: ");
                }
            }

            double risultato;

            switch (operatore)
            {
                case '+':
                    risultato = numeri[0] + numeri[1];
                    break;
                case '-':
                    risultato = numeri[0] - numeri[1];
                    break;
                case '*':
                    risultato = numeri[0] * numeri[1];
                    break;
                case '/':
                    if (numeri[1] != 0) // Controllo per evitare la divisione per zero
                    {
                        risultato = numeri[0] / numeri[1];
                    }
                    else
                    {
                        Console.WriteLine("\nImpossibile dividere per zero.");
                        Console.Write("Premi un tasto per continuare...");
                        Console.ReadKey();
                        return;
                    }

                    break;
                default:
                    Console.WriteLine("Operatore non riconosciuto.");
                    return;
            }

            Console.WriteLine($"\nRisultato: {risultato:N2}"); // Visualizzazione del risultato con due cifre decimali
            Console.Write("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}