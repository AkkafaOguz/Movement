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

        public Map GetMapDimensionsFromUser()
        {

            Console.WriteLine("Please enter dimensions of map in the order width(w) and height(h)");
            var inputList = new List<int>();

            while (inputList.Count != 2)
            {
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());
                    inputList.Add(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric value");
                }
            }

            Width = inputList[0];
            Height = inputList[1];
            
            Console.WriteLine("Width of the map: {0}", Width);
            Console.WriteLine("Height of the map: {0}", Height);

            return this;
        }
    }
}
