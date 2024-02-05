namespace SpravaPojistenych
{
    class Menu
    {
        //  konstruktor pro spuštění v Main
        public Menu(){ }
        
        string volba = "";
        //oddělovač textu, je dlouhý a znepřehlednuje kod
        string oddelovac = "-------------------------------------";
        //často se ve funkci opakuje
        string navratDoMenu = "Stiskněte Enter pro návrat do hlavního menu.";
        //Databaze pojistencu
        protected Databaze data = new Databaze();
        //uzivatelsky vstup
        protected UzivatelskyVstup vstup = new UzivatelskyVstup();
        //zpracovani vstupu
        protected ZpracovaniVstupu zpracovaniVstupu = new ZpracovaniVstupu();
        
        /// <summary>
        /// Uvodní obrazovka a menu aplikace
        /// </summary>
        public void VypisUvodniObrazovku()
        {
            //cyklus menu
            while (volba != "5")
            {
                //hlavní menu
                Console.Clear();
                Console.WriteLine(oddelovac);
                Console.WriteLine("Vítejte v programu Evidence pojištění");
                Console.WriteLine(oddelovac);
                Console.WriteLine("");
                Console.WriteLine("Zadejte číslo pro výběr možnosti: ");
                Console.WriteLine(oddelovac);
                Console.WriteLine("1. Přidej pojištěnce");
                Console.WriteLine("2. Odeber pojištěnce");
                Console.WriteLine("3. Zobraz všechny pojištěnné");
                Console.WriteLine("4. Vyhledej pojištěnce");
                Console.WriteLine("5. Konec");
                Console.Write("Vyberte číslo položky a stiskněte Enter: ");

                volba = Console.ReadLine().Trim();
                //volba jednotlivých funkcí
                switch (volba)
                {
                    case "1":
                        PridejPojistence();
                        break;
                    case "2":
                        OdeberPojistence();
                        break;
                    case "3":
                        ZobrazVsechnyPojistence();
                        break;
                    case "4":
                        VyhledejPojistence();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Stiskněte Enter pro pokračování.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        /// <summary>
        /// Přidej pojisštěnce do Databaze
        /// </summary>
        private void PridejPojistence()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Vybrali jste volbu přidej pojištěnce");
                Console.WriteLine();
                //načtení a formátování jména
                string jmeno = zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Jméno"));
                //načtení a formátování příjmení
                string prijmeni = zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Příjmení"));
                //načtení data narození
                DateTime datumNarozeni = vstup.VyzadejDatumNarozeni();
                //výpočet věku
                int vek = zpracovaniVstupu.ZpracujVek(datumNarozeni, 110);
                //načtení telefoního čísla
                string telefon = zpracovaniVstupu.ZpracujTelefoniCislo(vstup.VyzadejVstupText("telefonní číslo bez mezer"));


                //pro ověření zadání
                Console.WriteLine($"Zadali jste {jmeno} , {prijmeni}, Věk: {vek}, Telefon :{telefon}");

                //provedení funkce pridej záznam a výpis do konzole.
                if (data.PridejZaznam(jmeno, prijmeni, vek, telefon))
                {
                    Console.WriteLine("Záznam byl Uspěšně přidán.");
                }
                else { Console.WriteLine("Chyba v přidání záznamu, prosím opakuj akci"); }

                Console.WriteLine(navratDoMenu);
                Console.ReadKey();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString()); }
        }
        /// <summary>
        /// Odeber pojištěnce z Databaze
        /// </summary>
        private void OdeberPojistence()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Vybrali jste volbu Odeber pojištěnce");
                //načtení jména
                string jmeno = zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Jméno"));
                //načtení příjmení
                string prijmeni = zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Příjmení"));

                // odebrání podle jména a příjmení
                if (data.OdeberZaznam(jmeno, prijmeni))
                {
                    Console.WriteLine("Záznamy úspěšně odstraněny");
                }
                else { Console.WriteLine("Žádný záznam k odstranění"); }


            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString()); }
            Console.WriteLine(navratDoMenu);
            Console.ReadLine();
        }
        /// <summary>
        /// Zobrazenní všech záznamů
        /// </summary>
        private void ZobrazVsechnyPojistence()
        {
            Console.Clear();
            Console.WriteLine("Vybrali jste volbu Zobraz všechny pojištěnné");
            // zobrazení všech záznamů + optické oděělní pomocí oddělovače
            List<Pojistenec> seznam = data.ZobrazZáznamy();
            //pokud databaze obsahuje nějaky zaznam > vypiš
            if (seznam.Count > 0)
            {
                seznam.ForEach(p => { Console.WriteLine(oddelovac); Console.WriteLine(p); Console.WriteLine(oddelovac); });
            }
            else { Console.WriteLine("Žádný záznam"); }

            //trocha prostoru na obrazovce at se to líp čte
            Console.WriteLine("\n\n");
            Console.WriteLine(navratDoMenu);

            Console.ReadLine();
        }
        /// <summary>
        /// Vyhledej pojištěnce podle Jména nebo Příjmení
        /// Ovládací menu vyhledávání
        /// </summary>
        //možné vylepšení ... 
        private void VyhledejPojistence()
        {
            string volba = "";
            while (volba != "4")
            {
                //výpis obrazovky pro volbu vyhledávání
                Console.Clear();
                Console.WriteLine("Vybrali jste volbu vyhledej pojištěnce");
                Console.WriteLine("1. Podle jména i příjmení");
                Console.WriteLine("2. Podle jména");
                Console.WriteLine("3. Podle příjmení");
                Console.WriteLine("4. Návrat do menu");
                Console.Write("Volba : ");
                //volba v menu
                volba = Console.ReadLine().Trim().ToLower();
                //list pro uloženní a zobrazení výsledků hledání
                List<Pojistenec> vysledekHledani = new List<Pojistenec>();

                switch (volba)
                {
                    case "1":
                        //vyhledá záznamy podle jména a příjmení
                        vysledekHledani = data.NajdiZaznam(zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Jméno")), zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Příjmení")));
                        break;

                    case "2":
                        //vyhledá záznamy podle jména
                        vysledekHledani = data.NajdiZaznam(zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Jméno")), null);
                        break;

                    case "3":
                        //vyhledá záznamy podle příjmení
                        vysledekHledani = data.NajdiZaznam(null, zpracovaniVstupu.NaformatujText(vstup.VyzadejVstupText("Příjmení")));
                        break;

                }
                //výpis výsledků hledání do konzole 
                vysledekHledani.ForEach(x => { Console.WriteLine(oddelovac); Console.WriteLine(x); Console.WriteLine(oddelovac); });
                Console.ReadKey();
            }
        }
    }
}

