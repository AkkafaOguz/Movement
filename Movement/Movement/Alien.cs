using System.Collections.Generic;
using System;

namespace Movement
{
    public class Alien : Movement
    {
        public List<int[]> GenerateRootCoordinates()
        {
            List<int[]> coordinates = new List<int[]>();
            var coordinatesNum = _movementCoordinates.Count / 2;
            
            for (int i = 0; i < coordinatesNum; i++)
            {
                coordinates.Add(new int[] { _movementCoordinates[i++], _movementCoordinates[i++] });
            }
            foreach (var x in coordinates)
            {
                Console.WriteLine("[" + string.Join(",", x) + "]");
            }

            return coordinates;
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