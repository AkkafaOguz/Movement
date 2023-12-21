using System;
using System.Collections.Generic;

namespace Movement
{
    public class Movement
    {
        private readonly List<int> _movementCoordinates = new List<int>();
        public string LifeFormOption { get; set; }
        private Map _map;
        public Movement(Map map)
        {
            _map = map;
        }
        public Movement()
        { 
        }

        public List<int> GetMovementCoordinatesFromUser()
        {
            Console.WriteLine("Please enter movement coordinates in the order X - Y. When you're done please enter 'DONE'!");

            var input = "";

            while (!input.Equals("DONE"))
            { 
                try
                {
                    input = Console.ReadLine().ToUpper();
                    if (IsValueValid(input)) 
                    _movementCoordinates.Add(Convert.ToInt32(input));
                }
                catch (FormatException)
                {
                    if (!input.Equals("DONE")) 
                        Console.WriteLine("Please enter a valid value");
                }
                finally
                {
                    if (input.Equals("DONE") && _movementCoordinates.Count % 2 != 0)
                    {
                        Console.WriteLine("You should enter coordinates as pair (X,Y). Please enter a value for 'Y'");
                        input = "";
                    }
                }

            }
            foreach (var x in _movementCoordinates)
            {
                Console.WriteLine(x);
            }
            return _movementCoordinates;
        }

        private bool IsValueValid(string input)
        {
            var item = Math.Abs(Convert.ToInt32(input));
            var isValueValid = true;

            var widthOfMap = Convert.ToInt32(_map.Width);
            var heightOfMap = Convert.ToInt32(_map.Height);
            
            var sizeOfList = _movementCoordinates.Count;
            
            if (sizeOfList % 2 != 0 && item > widthOfMap)
            {
                Console.WriteLine("Movement coordinate (Y) can not be bigger than width: {0}", widthOfMap);
                isValueValid = false;
            }

            if (sizeOfList % 2 == 0 && item > heightOfMap)
            {
                Console.WriteLine("Movement coordinate (X) can not be bigger than height: {0}", heightOfMap);
                isValueValid = false;
            }

            return isValueValid;
        }

        public void GetLifeFormFromUser()
        {
            // write code for edge cases
            Console.WriteLine("Please enter a life form: \nPress '1' for Human \nPress '2' for Alien");
            LifeFormOption = Console.ReadLine();
        }

        




    }
}