using System;
using System.Collections.Generic;

namespace Movement
{
    public class Movement : Map
    {
        public readonly List<int> _movementCoordinates = new List<int>();
        protected static readonly List<int[]> MovementPath = new List<int[]>();
        private readonly IMovement _move;

        public Movement(object lifeFormFromUser)
        {
            _move = (IMovement)lifeFormFromUser;
        }

        public Movement()
        {

        }

        public Movement GetMovementCoordinatesFromUser()
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

            return this;
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

        public void ReportPathAndActualCoordinate()
        {
            Console.WriteLine("Report Path:");

            foreach (var x in MovementPath)
            {
                Console.WriteLine("[" + string.Join(",", x) + "]");
            }

            Console.WriteLine("Report Actual Coordinate");
            Console.WriteLine("[" + string.Join(",", MovementPath[MovementPath.Count - 1]) + "]");

        }

        public Movement GenerateCoordinates()
        {
            _move.CalculateRoute(_movementCoordinates, Width, Height);

            return this;
        }


    }
}