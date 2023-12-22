using System;
using System.Collections.Generic;

namespace Movement
{
    public class Movement : Map
    {
        private readonly List<int> _movementCoordinates = new List<int>();

        public List<int> GetMovementCoordinatesFromUser()
        {
            Console.WriteLine("Please enter movement coordinates in the order X - Y. When you're done please enter 'DONE'!");
            var input = "";

            while (!input.Equals("DONE"))
            { 
                try
                {
                    input = Console.ReadLine()?.ToUpper();
                    if (IsCoordinateValueValid(input)) 
                        _movementCoordinates.Add(Math.Abs(Convert.ToInt32(input)));
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
            return _movementCoordinates;
        }

        private bool IsCoordinateValueValid(string input)
        {
            var item = Math.Abs(Convert.ToInt32(input));
            var isValueValid = true;

            var widthOfMap = Width;
            var heightOfMap = Height;
            
            var sizeOfList = _movementCoordinates.Count;
            
            if (sizeOfList % 2 != 0 && item > widthOfMap)
            {
                Console.WriteLine("Movement coordinate (X) can not be bigger than width: {0}", widthOfMap);
                isValueValid = false;
            }

            if (sizeOfList % 2 == 0 && item > heightOfMap)
            {
                Console.WriteLine("Movement coordinate (Y) can not be bigger than height: {0}", heightOfMap);
                isValueValid = false;
            }

            return isValueValid;
        }

        public int GetLifeFormFromUser()
        {
            Console.WriteLine("Please enter a life form: \nPress '1' for Human \nPress '2' for Alien");
            var input = "";
            var inputNumber = 0;

            while (!input.Equals("1") && !input.Equals("2"))
            {
                try
                {
                    input = Console.ReadLine();
                    inputNumber = Convert.ToInt32(input);

                    if (inputNumber != 1 && inputNumber != 2)
                        Console.WriteLine("Please enter a valid value ('1' OR '2')");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric value ('1' OR '2')");
                }
            }

            return inputNumber;
        }

        public void ReportPathAndActualCoordinate(List<int[]> movementCoordinates)
        {
            Console.WriteLine("Report Path:");

            foreach (var x in movementCoordinates)
            {
                Console.WriteLine("[" + string.Join(",", x) + "]");
            }

            Console.WriteLine("Report Actual Coordinate");
            Console.WriteLine("[" + string.Join(",", movementCoordinates[movementCoordinates.Count - 1]) + "]");

        }


    }
}