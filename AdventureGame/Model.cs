using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame_demo1
{
    public class Model
    {
        public Spiller spiller;
        public Rom[] rom;
        public Dør[] dører;
        public string content;
        public string items;
        public bool åpenDør;




        public Model()
        {
            spiller = new Spiller();
        // Lager alle de ulike rom som objekt av klassen Rom
        // Samler alle i rommene i en liste, kaller denne listen for rom.



        //rom:
        //    [
        //        { navn: 'A', innhold:['rød nøkkel'], start: true },
        //        { navn: 'B', innhold:['grønn nøkkel'] },
        //        { navn: 'C', innhold:['hvit nøkkel'] },
        //        { navn: 'D', innhold:['blå nøkkel'] },
        //        { navn: 'E', innhold:['grå nøkkel'] },
        //        { navn: 'F', innhold:[], vunnet: true },
        //    ],


            Rom romA = new Rom() { navn = "A", innhold = new[] { "rød nøkkel" }, start = true };
            Rom romB = new Rom() { navn = "B", innhold = new[] { "grønn nøkkel" } };
            Rom romC = new Rom() { navn = "C", innhold = new[] { "hvit nøkkel" } };
            Rom romD = new Rom() { navn = "D", innhold = new[] { "blå nøkkel" } };
            Rom romE = new Rom() { navn = "E", innhold = new[] { "grå nøkkel" } };
            Rom romF = new Rom() { navn = "F", innhold = new[] { "" }, vunnet = true };


            rom = new[] { romA, romB, romC, romD, romE, romF };

            // Lager alle de ulike dørene som objekter av klassen Dør.
            // Legger dem til slutt i liste over dører, i listen dører

            Dør dør1 = new Dør() { r1 = romA, r2 = romB, farge = "rød", åpen = false };
            Dør dør2 = new Dør() { r1 = romD, r2 = romA, farge = "grønn", åpen = false };
            Dør dør3 = new Dør() { r1 = romC, r2 = romB, farge = "grå", åpen = false };
            Dør dør4 = new Dør() { r1 = romE, r2 = romB, farge = "blå", åpen = false };
            Dør dør5 = new Dør() { r1 = romF, r2 = romE, farge = "hvit", åpen = false };

            dører = new[] { dør1, dør2, dør3, dør4, dør5 };

            spiller.rom = rom.Where(r => r.start == true).ToArray()[0];
            this.spiller.rom = spiller.rom;
            this.spiller.har = spiller.har;

            //public string inventory()
            //{
            //    string items = "";

            //    if (har.Count == 0)
            //    {
            //        items = "ingenting";
            //    }

            //    else
            //    {
            //        foreach (var ting in har)
            //        {
            //            items += $"{ting}\n";
            //        }
            //    }
            //    return items;
            //}

        }


        public string roomContent() {

            if (spiller.rom.innhold.Length == 0)
            {
               items =  "Ingenting";
            }

            foreach (var ting in this.spiller.rom.innhold)
            {
                items += $"{ting}";
            }

            return items;
        }

        public string inventory()
        {
            if (spiller.har.Count == 0) {
                items = "Ingenting";
            }

            else { 
                foreach(var item in spiller.har)
                {
                    items += $"\n{item}\n";
                }
            }

            return items;
        }

        public Tuple<List<Rom>, List<Dør>> doors()
        {
            //var romnavn = convert.tostring(spiller.rom.navn);
            var aTup = new Tuple<List<Rom>, List<Dør>>(null,null);
           

            var romNavn = spiller.rom;

            string aString = "";
            List<Dør> aDør = new();
            List<Rom> aRom = new();

            var doorsInRoom = dører.Where(d => d.r1 == spiller.rom || d.r2 == spiller.rom).ToArray();
           
            foreach (var dør in doorsInRoom)
            {
                if (dør.r1 != spiller.rom)
                {
                    var romNavn1 = dør.r1;
                    aDør.Add(dører.Where(d => d.r1 == dør.r1).ToArray()[0]);
                    aRom.Add(romNavn1);
                }

                if (dør.r2 != spiller.rom)
                {
                    var rom2 = dør.r2;
                    aDør.Add(dører.Where(d => d.r2 == dør.r2).ToArray()[0]);
                    aRom.Add(rom2);
                }
            }
            aTup = Tuple.Create(aRom, aDør);
            return aTup;
        }
    }
}