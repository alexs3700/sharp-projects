using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventureGame_demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            controller.initModel();
            controller.playerInteraction();
            //controller.UpdateModel();
        }          
    }
}
