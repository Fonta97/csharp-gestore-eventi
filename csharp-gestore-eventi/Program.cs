namespace GestoreEvento
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Inserisci i dettagli del nuovo evento:");


                //titolo
                Console.Write("Inserisci il nome dell'evento: ");
                string titolo = Console.ReadLine();


                //data
                Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);


                //capienza
                Console.Write("Inserisci il numero di posti totali: ");
                int capienzaEvento = int.Parse(Console.ReadLine());



                Evento nuovoEvento = new Evento(titolo, data, capienzaEvento);

                Console.WriteLine();
                Console.Write("Vuoi effettuare delle prenotazioni? (si/no): ");
                string risposta = Console.ReadLine();

                Console.WriteLine();
                if (risposta == "si")
                {
                    //posti prenotati
                    Console.WriteLine("Quanti posti desideri prenotare? ");
                    int numeroPostiCheSiVoglionoPrenotare = int.Parse(Console.ReadLine());

                    // effettua le prenotazioni utilizzando il metodo PrenotaPosti
                    int postiPrenotati = nuovoEvento.PrenotaPosti(numeroPostiCheSiVoglionoPrenotare);

                    Console.WriteLine();
                    Console.WriteLine($"Numero di posti prenotati: {postiPrenotati}");
                    Console.WriteLine($"Numero di posti disponibili: {nuovoEvento.CapienzaEvento - postiPrenotati}");
                }

                Console.WriteLine();
                while (risposta == "si")
                {
                    Console.WriteLine("Vuoi disdire dei posti? (si/no): ");
                    risposta = Console.ReadLine();

                    if (risposta == "si")
                    {
                        Console.WriteLine($"Ok, va bene!");
                        //posti da disdire
                        Console.WriteLine($"Indica il numero dei posti che vuoi disdire: ");
                        int numeroPostiCheSiVoglionoDisdire = int.Parse(Console.ReadLine());

                        // effettua le disdette utilizzando il metodo DisdisciPosti
                        int postiCancellati = nuovoEvento.DisdisciPosti(numeroPostiCheSiVoglionoDisdire);

                        Console.WriteLine();
                        Console.WriteLine($"Numero di posti prenotati: {nuovoEvento.NumeroPostiPrenotati}");
                        Console.WriteLine($"Numero di posti disponibili: {nuovoEvento.CapienzaEvento - nuovoEvento.NumeroPostiPrenotati}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Si è verificato un errore: {e}");
            }
        }
    }
}