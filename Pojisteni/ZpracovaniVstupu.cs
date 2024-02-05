using System.Text.RegularExpressions;

namespace SpravaPojistenych
{
    internal class ZpracovaniVstupu
    {


        //prazdny konstruktor.
        public ZpracovaniVstupu() { }




        /// <summary>
        /// upravi vstupní retezec na retezec zacinající velkým písmenem
        /// </summary>
        /// <param name="coUpravit">Vstupní retezec</param>
        /// <returns>vrací retezec s prvním velýk písmenem</returns>
        public  string PrvniVelke(string coUpravit)
        {
            return String.Format(char.ToUpper(coUpravit[0]) + coUpravit.Substring(1));

        }

        /// <summary>
        /// Odstrani speciální znaky v řetězci, pozor na použití!!
        /// </summary>
        /// <param name="coUpravit">vstupní řetězect</param>
        /// <returns>upravený řetězec bez znaků typu #&@{} atd..</returns>
        public  string OdstranSpecialniZnaky(string coUpravit)
        {

            return Regex.Replace(coUpravit, "[^a-zA-Z0-9_.ěščřžýáíéĚŠČŘŽÝÁÍÉ]+", "", RegexOptions.Compiled);
        }

        /// <summary>
        /// souhrnná funkce na upravu a formatování textu, odstranění speiálních znaků a první velké písmeno
        /// </summary>
        /// <param name="coUpravit">Textk k upravení</param>
        /// <returns>string bez speciálních znaků a první velké písmeno</returns>
        public string NaformatujText(string coUpravit)
        {
            string upravenyText= OdstranSpecialniZnaky(coUpravit);
            upravenyText = PrvniVelke(upravenyText);
            
            return upravenyText;
            


        }




        /// <summary>
        /// Zpracování věku na základě data narození
        /// </summary>
        /// <param name="datumNarozeni">datum narození</param>
        /// <param name="limitVeku">limit věku pro zpracování, defaultně 110</param>
        /// <returns>vrací věk s ohledem na přestupný rok</returns>
        /// <exception cref="Exception">vyjímka při překročení limitu věku</exception>
        public  int ZpracujVek(DateTime datumNarozeni, int limitVeku = 110)
        {
            //dnešní datum
            DateTime dnesniDatum = DateTime.Now;
            //základní výpočet věku
            int vek = dnesniDatum.Year - datumNarozeni.Year;

            //počet dní do dalších narozenin
            int doNarozenin = datumNarozeni.DayOfYear - dnesniDatum.DayOfYear;


            //řešení narozenin v současném roce a ošetření přestupného roku
            if (doNarozenin >= 0)
                vek -= 1;
            else
            {
                doNarozenin += 365;
                if (((DateTime.IsLeapYear(dnesniDatum.Year) && (dnesniDatum.DayOfYear < 60)) ||
                      DateTime.IsLeapYear(dnesniDatum.AddYears(1).Year) && (datumNarozeni.DayOfYear > 59))) { doNarozenin += 1; }
            }


            //podmínka na ověření limitu věku
            if (vek > limitVeku)
            {
                throw new Exception($"Prekrocen limit věku, limit je: {limitVeku}");
            }

            return vek;

        }



        /// <summary>
        /// Vraci telefoní číslo pokud ma spravný počet znaků (9) bez předvolby a (13) s předvolbou
        /// </summary>
        /// <param name="coUpravit">vstupní string</param>
        /// <returns>telefoní číslo jako string</returns>
        /// <exception cref="FormatException">zadaný string neodpovídá formátu čísla</exception>
        public  string ZpracujTelefoniCislo(string coUpravit)
        {

            if ((coUpravit.Length == 9 || coUpravit.Length == 13))
            {
                return coUpravit;
            }
            else
            {
                throw new FormatException("Neplatný formát");
            }

        }



    }

}
