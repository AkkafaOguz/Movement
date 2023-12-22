using System.Collections.Generic;
using System;

namespace Movement
{
    public class Alien : Movement
    {
        public List<int[]> GenerateRootCoordinates(List<int> movementCoordinates)
        {
            List<int[]> coordinates = new List<int[]>();
            var coordinatesNum = movementCoordinates.Count / 2;
            foreach (var item in coordinates)
            {
                Console.WriteLine(item);
            }
            for (int i = 0; i < coordinatesNum; i++)
            {
                coordinates.Add(new int[] { movementCoordinates[1], movementCoordinates[0] });
                movementCoordinates.RemoveRange(0, 2);
            }
            foreach (var x in coordinates)
            {
                Console.WriteLine("[" + string.Join(",", x) + "]");
            }

            return coordinates;
        }
    }
}