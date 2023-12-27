using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    internal class LifeForm
    {
        private readonly List<object> _lifeForms = new List<object>() { new Human(), new Alien() };

        public object GetLifeFormFromUser()
        {
            Console.WriteLine("Please enter a life form: \nPress '0' for Human \nPress '1' for Alien");
            var input = "";
            var inputNumber = 0;

            while (!input.Equals("0") && !input.Equals("1"))
            {
                try
                {
                    input = Console.ReadLine();
                    inputNumber = Convert.ToInt32(input);

                    if (inputNumber != 0 && inputNumber != 1)
                        Console.WriteLine("Please enter a valid value ('0' OR '1')");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric value ('0' OR '1')");
                }
            }

            return _lifeForms[inputNumber];
        }
    }
}
