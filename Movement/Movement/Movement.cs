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


        public void GetMovementCoordinatesFromUser()
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

            }
            foreach (var x in _movementCoordinates)
            {
                Console.WriteLine(x);
            }
        }

        private bool IsValueValid(string input)
        {
            var isValueValid = true;
            var widthOfMap = Convert.ToInt32(_map.Width);
            var heightOfMap = Convert.ToInt32(_map.Height);
            
            var sizeOfList = _movementCoordinates.Count;
            var item = Convert.ToInt32(input);

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

        public void GetLifeFormFromUser()
        {
            Console.WriteLine("Please enter a life form: \nPress '1' for Human \nPress '2' for Alien");
            LifeFormOption = Console.ReadLine();
        }



        private int[,] GenerateRootCoordinates(List<int> coordinates, int lifeForm)
        {
            List<int> tempList = coordinates;
            foreach (var a in tempList)
            {
                Console.WriteLine(a);
            }

            var sizeOfArray = tempList.Count / 2;
            var arrayRootCoordinates = new int[sizeOfArray, 2];
            var index = 0;

            while (tempList.Count >= 2)
            {

                if (lifeForm == 1)
                {
                    arrayRootCoordinates[index, 0] = tempList[0];
                    arrayRootCoordinates[index, 1] = tempList[1];
                }
                else
                {
                    arrayRootCoordinates[index, 0] = tempList[1];
                    arrayRootCoordinates[index, 1] = tempList[0];
                }

                tempList.RemoveAt(0);
                tempList.RemoveAt(0);

                index++;
            }


            return arrayRootCoordinates;
        }

        private List<int> CalculateAndReportPath(int[] mapDimensions, int[,] rootCoordinates)
        {
            var pathReport = new int[rootCoordinates.Length, 2];
            var mapWidth = mapDimensions[0];
            var mapHeight = mapDimensions[1];

            var x = 0;
            var y = 0;

            Console.WriteLine("Report Path:");
            for (int i = 0; i < rootCoordinates.Length; i++)
            {
                if (mapWidth > rootCoordinates[i, 0] && mapHeight > rootCoordinates[i, 1])
                {
                    x += rootCoordinates[i, 0];
                    y += rootCoordinates[i, 1];

                    if (y > mapHeight)
                    {
                        y = 0;
                    }
                    if (x > mapWidth)
                    {
                        y = 0;
                    }

                    Console.WriteLine("[{0},{1}]", x, y);
                }
            }
            return null;
        }

    }
}