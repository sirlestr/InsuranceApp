namespace SpravaPojistenych
{
    internal class Databaze
    {
        //deklarace listu pojistencu
        private List<Pojistenec> databaze;

        //konstruktor4      
        public Databaze()
        {

            //inicialikzace listu se záznamy pojistenych, abych to nemusel furt psát znovu
            databaze = new List<Pojistenec>
            {
                new Pojistenec("Michal", "Lesák", 32, "73995487"),
                new Pojistenec("Pepa", "Kahoun", 54, "73995487"),
                new Pojistenec("Anežka", "Holá", 18, "73995487"),
                new Pojistenec("Pepa", "Doležel", 27, "73995487"),
                new Pojistenec("Franta", "Novotný", 34, "73995487"),
            };
        }

        //Prida zaznam do seznamu
        // oveření jestli byl záznam přidán
        public bool PridejZaznam(string jmeno, string prijmeni, int vek, string telefon)
        {
            int pocetZaznamu = databaze.Count();
            databaze.Add(new Pojistenec(jmeno, prijmeni, vek, telefon));
            if (databaze.Count > pocetZaznamu)
            {
                return true;
                //Console.WriteLine("Záznam  byl přidán");
            }
            return false;

        }


        /// <summary>
        /// Vyhledej Záznamy v databázi pojištěnců
        /// </summary>
        /// <param name="jmeno">Jméno, může být i null</param>
        /// <param name="prijmeni">Příjmení, může být i null</param>
        public List<Pojistenec> NajdiZaznam(string? jmeno, string? prijmeni)
        {
            //nová instance listu pro uložení vyhledaných záznamů
            List<Pojistenec> vysledek = new List<Pojistenec>();
            //prochazení prvků v listu
            foreach (var p in databaze)
            {    //vyhledávání podle jména a/nebo příjmení    
                if ((!String.IsNullOrEmpty(jmeno) && p.Jmeno == jmeno) || (!String.IsNullOrEmpty(prijmeni) && p.Prijmeni == prijmeni))
                {
                    vysledek.Add(p);
                }
            }

            //vypsání nalezených záznamů do konzole
            //vysledek.ForEach(p => { Console.WriteLine(p); });
            return vysledek;
        }


        /// <summary>
        /// předá aktuální instanci databáze záznamu pro vypsání v menu
        /// </summary>
        public List<Pojistenec> ZobrazZáznamy()
        {
          return databaze;            
        }



        /// <summary>
        /// Odebere záznam z databáze na základě vyhledání Jména a Příjmení
        /// </summary>
        /// <param name="jmeno">Jméno</param>
        /// <param name="prijmeni">Příjmení</param>
        public bool OdeberZaznam(string jmeno, string prijmeni)
        {

            List<Pojistenec> zaznam = NajdiZaznam(jmeno, prijmeni);
            if (zaznam.Count > 0)
            {
                foreach (Pojistenec p in zaznam)
                {
                    databaze.Remove(p);
                }
                //Console.WriteLine("Záznam byl Odstraněn");
                return true;

            }
            return false;
        }
    }
}
