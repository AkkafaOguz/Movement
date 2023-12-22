using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void GetMapDimensionsFromUser()
        {

            Console.WriteLine("Please enter dimensions of map in the order width(w) and height(h)");

            Height = Convert.ToInt32(Console.ReadLine());
            Width = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Width of the map: {0}", Width);
            Console.WriteLine("Height of the map: {0}", Height);
            
            
        }
    }
}
