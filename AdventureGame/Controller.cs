using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace AdventureGame_demo1
{
    public class Controller
    {
        public Model model;
        public Spiller spiller;
        public Rom rom;
        public Rom startRom;
        public string innholdIRommet;
       
        public bool kanÅpneDør;
        public bool åpneDør;
        public string headerText;
        //public string r;
        //public Controller()
        //{
        //    show();
        //}

        public void initModel()
        {
            model = new Model();
            spiller = new Spiller();
            //updateView = new UpdateView();


            var rom = model.rom.Where(r => r.start == true).ToArray()[0];
            spiller.rom = rom;
            model.spiller.har = spiller.har;
            model.spiller.rom = spiller.rom;
            show();
        }

        public void updateModel()
        {
            
            spiller.rom = model.rom.Where(r => r.navn == "B").ToArray()[0];

            var nøkkel = "rød nøkkel";

            



            spiller.har.Add(nøkkel);
            spiller.inventory();



            model.spiller.har = spiller.har;
            model.spiller.rom = spiller.rom;
            //model.spiller.rom.innhold = spiller.rom.innhold;
            show();
        }


        //public void hentRom(Rom rom) {}

        //public void hentDør(Dør dør) {/*}*/
        public void show()
        { 
            headerText = model.spiller.rom.vunnet
                ? "Gratulerer - du har fullført spillet! :-)"
                : $"Du er i rom: {model.spiller.rom.navn}";

            Console.WriteLine(headerText);

            Console.Write($"I rommet ser du: ");
            if (model.spiller.rom.innhold[0] == "rød nøkkel")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (model.spiller.rom.innhold[0] == "grønn nøkkel")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write($"{model.spiller.rom.innhold[0]}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Du har: {model.spiller.inventory()}");

            Console.WriteLine("\nDører: ");
            Console.WriteLine("-----------");
            for (var i = 0; i < 2; i++)
            {
                Console.WriteLine($"Dør {model.doors().Item1[i].navn} kan åpnes med {model.doors().Item2[i].farge}");
            }
        }

        public Process getProcess()
        {
            Process aProcess = Process.GetCurrentProcess();
            return aProcess;
        }

        public void killProcess()
        {
            Process aProcess = getProcess();
            aProcess.Kill();
            //aProcess.CloseMainWindow();
            //aProcess.Close();

        }

        public void playerInteraction()
        {
            Console.WriteLine($"\nPlukk opp {model.spiller.rom.innhold[0]} nøkkel.");
            Console.WriteLine("Tast p for å plukke opp");
            var keyP = Console.ReadLine().ToLower();

            if (keyP == "p")
            {
                plukkOpp(model.spiller.rom.innhold[0]);
            }

            Console.WriteLine($"\n Låse opp dør (tast l)");
            var keyL = Console.ReadLine().ToUpper();
            if (keyL == "l")
            {
                åpneDørTilRom();
            }

            Console.WriteLine("\nGå gjennom dør (tast g)");
            var keyG = Console.ReadLine().ToLower();
            if (keyG == "g")
            {
                gåTil("B");
                Console.Clear();
                show();
            }

            Console.WriteLine("\nFor å avsluttte, tast x");
            var keyX = Console.ReadLine().ToLower();

            string[] dotStringArray = new string[] { "...", "..", "." };
            Console.WriteLine("Avslutter om 3 sekunder");

            if (keyX == "x")
            {               

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(dotStringArray[i]);
                    Thread.Sleep(1000);

                }
                killProcess();
            }
        }
        
                public void åpneDørTilRom() { 
        
            foreach (var dør in model.doors().Item2.ToArray()) {
                        if (kanÅpne(dør))
                {
                    låseOpp(dør.farge);
                }
             }           
        }

            public bool kanÅpne(Dør dør) {
            var aDør = model.dører.Where(d => d == dør).ToArray()[0];
            if (spiller.har.Contains(aDør.farge + " nøkkel")) {
                kanÅpneDør = true;
            }
            return kanÅpneDør;
        }    

        

        public string plukkOpp(string ting) {

            if (spiller.har.Count == 0)
            {
                spiller.har.Add(ting);
            }

            else
            {
                if (!spiller.har.Contains(ting))
                {
                    spiller.har.Add(ting);
                }
            }
            model.spiller.har = spiller.har;

            return spiller.inventory();
        }
            

        public void låseOpp(string dørFarge) {
            var aDør = model.dører.Where(d => d.farge == dørFarge).ToArray()[0];
            aDør.åpen = true;           
        }

        public void gåTil(string rom) {
            var aRom = model.rom.Where(r => r.navn == rom).ToArray()[0];
            spiller.rom = aRom;
            model.spiller.rom = spiller.rom;          
        }

        public void getDør()
        {

        }

        public void getRom()
        {

        }

        }
}
