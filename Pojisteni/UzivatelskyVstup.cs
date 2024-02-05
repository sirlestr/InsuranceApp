using System.Globalization;

namespace SpravaPojistenych
{
    public class UzivatelskyVstup
    {

        public UzivatelskyVstup() { }
        /// <summary>
        /// Vyzadani vstupu uzivatele s minimální délkou nastavitelnbou v parametru
        /// </summary>
        /// <param name="jakyVstup">pojmenování vstupu pro výpis  v konzoli = Zadej "Jméno", Zadej "Příjmení" atd.</param>
        /// <param name="minimalniDelakVstupu">upravení minimální délky vstupu, defaultně 0 = bez limitu</param>
        /// <returns>vrací ošetřený uživatelský vstup</returns>
        /// <exception cref="ArgumentNullException">prázdný vstup</exception>
        /// <exception cref="Exception">všeobecná vyjímka</exception>
        public string VyzadejVstupText(string jakyVstup, int minimalniDelakVstupu = 0)
        {
            Console.Write("Zadej {0}: ", jakyVstup);
            //odstranění mezer
            string vystup = Console.ReadLine().Trim();
            //Ověření jestli ve stringu něco je
            if (String.IsNullOrEmpty(vystup))
            {
                throw new ArgumentNullException($"Zadané {jakyVstup} je prázdné");
            }
            //Ověření minimální délky vstupu, možné budoucí komplikace
            if (vystup.Length < minimalniDelakVstupu)
            {
                throw new ArgumentOutOfRangeException($"Zadané {jakyVstup} je příliš krátké, minimální délka je : {minimalniDelakVstupu} ");
            }
            //vrací vstup jako text bez mezer na zčátku a konci s minimální délkou nastavenou v parametru
            return vystup;
        }
        /// <summary>
        /// Vyžádá si od uživatele datum narození ve formátu d.M.yyyy
        /// </summary>
        /// <returns>vrací ošetřený uživatelský vstup </returns>
        /// <exception cref="ArgumentNullException">prázdná hodnota</exception>
        /// <exception cref="ArgumentException">špatný formát</exception>
        public DateTime VyzadejDatumNarozeni()
        {
            //text do konzole pro vyžádání zadání data narození
            Console.Write("Zadej datum narození ve formátu d.M.yyyy (1.1.1990): ");
            string datumZKonzole = Console.ReadLine().Trim();
            DateTime datumNarozeni;

            //vyjímka na prázdnou proměnou
            if (String.IsNullOrEmpty(datumZKonzole))
            {
                throw new ArgumentNullException("Zadané datum je prázdné");
            }
            //parsování data z konzole
            bool normalniDAtum = DateTime.TryParseExact(datumZKonzole, "d.M.yyyy", null, DateTimeStyles.None, out datumNarozeni);

            //pokud parsování neproběhne v pořádku, vyhoď vyjímku
            if (!normalniDAtum)
            {
                throw new ArgumentException("Zadaný špatný formát, formát data je: \"1.1.1991(d.M.yyyy)\"");
            }
            return datumNarozeni;
        }
    }
}
