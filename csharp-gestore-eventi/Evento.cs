using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestoreEvento
{
    public class Evento
    {

        private string _titolo;
        private DateTime _data;
        private int _capienzaEvento;
        private int _numeroPostiPrenotati;

        public string Titolo
        {
            get
            {
                return _titolo;
            }
            set
            {
                //controllo titolo
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _titolo = value;
                }
                else
                {
                    throw new Exception("Il titolo non può essere vuoto.");
                }
            }
        }
        public DateTime Data
        {
            get
            {
                return _data;
            }
            set
            {
                //if la date è minore di oggi
                if (value >= DateTime.Now)
                {
                    _data = value;
                }
                else
                {
                    throw new Exception("La data non può essere al passato");
                }
            }
        }
        public int CapienzaEvento
        {
            get
            {
                return _capienzaEvento;
            }
            private set
            {

                //if la capienza è maggiore di 0
                if (value > 0)
                {
                    _capienzaEvento = value;
                }
                else
                {
                    throw new Exception("La capienza non può essere inferiore a 0");
                }
            }
        }
        public int NumeroPostiPrenotati { get; private set; }


        public Evento(string titolo, DateTime date, int capienzaEvento)
        {
            Titolo = titolo;
            Data = date;
            CapienzaEvento = capienzaEvento;
            NumeroPostiPrenotati = 0;
        }


        public int PrenotaPosti(int postiDaPrenotare)
        {
            // if l'evento è già passato
            if (Data < DateTime.Now)
            {
                throw new Exception("L'evento è già passato.");
            }

            //if n di posti è > della capienza massima o i posti da prenotare sono > della capienza
            else if (NumeroPostiPrenotati > CapienzaEvento || CapienzaEvento < postiDaPrenotare)
            {
                throw new Exception("L'evento non ha più posti a disposizione.");
            }

            return NumeroPostiPrenotati += postiDaPrenotare;
        }

        public int DisdisciPosti(int postiDaCancellare)
        {

            if (Data < DateTime.Now)
            {
                throw new Exception("L'evento è già passato.");
            }

            if (NumeroPostiPrenotati >= postiDaCancellare)
            {
                NumeroPostiPrenotati -= postiDaCancellare;
            }
            else
            {
                throw new Exception("Non ci sono abbastanza posti prenotati da disdire.");
            }


            return NumeroPostiPrenotati -= postiDaCancellare;

        }

        public override string ToString()
        {
            string data = Data.ToString("dd/MM/yyyy");

            return $"{data} - {Titolo}";
        }

    }
