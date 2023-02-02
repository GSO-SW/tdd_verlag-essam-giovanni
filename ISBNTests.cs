using System;

namespace ISBNTests
{
    public class ISBNTests
    {
        
        public void TestGültigISBN10()
        {
            string ISBN = "0306406152";
            bool erwartet = true;
            bool aktuell= IstGültigISBN(ISBN);

            Assert.Equal(erwartet, aktuell);
        }

        
        public void TestUngültigISBN10()
        {
            string ISBN = "030640615X";
            bool erwartet= false;
            bool aktuell= IstGültigISBN(ISBN);
;

            Assert.Equal(erwartet, aktuell);
        }

        
        public void TestGültigISBN13()
        {
            string ISBN = "9780306406157";
            bool erwartet = true;
            bool aktuell = IstGültigISBN(ISBN);

            Assert.Equal(erwartet, aktuell);
        }

        
        public void TestUngültigISBN13()
        {
            string ISBN = "978030640615X";
            bool erwartet= false;
            bool aktuell= IstGültigISBN(ISBN);

            Assert.Equal(erwartet, aktuell);
        }

        private bool IstGültigISBN(string ISBN)
        {
            
        }
    }
}


using System;
namespace BuchBibliothekTests
{
    
    public class BuchTests
    {
        [Test]
        public void WennGültigISBNHinzugefügt_DannWirdISBNKorrektGespeichert()
        {
            // arrange
            var buch = new Buch();
            var erwartetesISBN = "978-3-16-148410-0";

            // act
            buch.ISBN = erwartetesISBN;

            // assert
            Assert.AreEqual(erwartetesISBN, buch.ISBN);
        }

        [Test]
        public void WennUngültigesISBNHinzugefügt_DannWirdAusnahmeGeworfen()
        {
            // arrange
            var buch = new Buch();
            var ungültigesISBN = "ungültig";

            // Act
            Assert.Throws<ArgumentException>(() => buch.ISBN = ungültigesISBN);
        }

        [Test]
        public void WennLeeresISBNHinzugefügt_DannWirdAusnahmeGeworfen()
        {
            // arrange
            var buch = new Buch();
            var leeresISBN = "";

            // Act
            Assert.Throws<ArgumentException>(() => buch.ISBN = leeresISBN);
        }

        [Test]
        public void WennExistierendesISBNHinzugefügt_DannWirdAusnahmeGeworfen()
        {
            // arrange
            var buch = new Buch { ISBN = "existierendes ISBN" };
            var existierendesISBN = "existierendes ISBN";

            // Act
            Assert.Throws<ArgumentException>(() => buch.ISBN = existierendesISBN);
        }

        [Test]
        public void WennValidISBNAbgefragt_DannWirdKorrektesISBNZurückgegeben()
        {
            // arrange
            var buch = new Buch { ISBN = "valid ISBN" };
            var erwartetesISBN = "valid ISBN";

            // act
            var tatsächlichesISBN = buch.ISBN;

            // assert
            Assert.AreEqual(erwartetesISBN, tatsächlichesISBN);
        }
    }

    public class Buch
    {
        private string _isbn;
        public string ISBN
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ISBN darf nicht leer sein");
                }

                if (_isbn != null && _isbn == value)
                {
                    throw new ArgumentException("ISBN ist vorhanden");
                }

                _isbn = value;
            }
        }
    }
}
