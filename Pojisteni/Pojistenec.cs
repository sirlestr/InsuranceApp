namespace SpravaPojistenych
{
    internal class Pojistenec
    {
        // Jméno pojištěného
        public string Jmeno { get; set; }
        // Příjmení pojištěného
        public string Prijmeni { get; set; }
        // Věk pojištěného        
        public int Vek { get; set; }
        // Telefon na pojištěného        
        public string Telefon { get; set; }
        
        /// <summary>
        /// třída pojištěnce
        /// </summary>
        /// <param name="jmeno">Jméno pojistěnce</param>
        /// <param name="prijmeni">Příjmení pojištěnce</param>
        /// <param name="vek">Věk pojištěnce</param>
        /// <param name="telefon">Telefonní číslo</param>
        public Pojistenec(string jmeno, string prijmeni, int vek, string telefon)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }
        // přepsání ToString na zobrazní všech informací
        public override string ToString()
        {
            return Jmeno + " " + Prijmeni + " " + Vek + " " + Telefon;
        }
    }
}
