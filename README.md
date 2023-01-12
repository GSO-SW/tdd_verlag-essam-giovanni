tdd_Verlag
using System;

public class verlag
    {
        public verlag()
        {
            Buch buch = new Buch("Harry Potter und der Gefangene von Askaban");
            buch = new Buch("Harry Potter und der Gefangene von Askaban");
            Console.ReadLine();
        }
    }
    public class Buch
    {
        private string titel;
        private string autor;
        private int auflage;

        public Buch(string titel, int auflage)
        {
            this.titel = titel;
            this.auflage = auflage;
            this.autor = autor;
        }
        public Buch(string titel, string autor)
        {
            this.titel = titel;
            this.auflage = auflage;
            this.autor = autor;
        }
        public Buch(string titel, string autor, int auflage)
        {
            this.titel = titel;
            this.autor = autor;
            this.auflage = auflage;
        }
    }

