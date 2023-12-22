using System.Collections.Generic;
using System;

namespace Movement
{
    public class Alien : Movement
    {
        private readonly List<int[]> _movementPath = new List<int[]>();

        public List<int[]> GenerateRootCoordinates(List<int> movementCoordinates)
        {
            List<int[]> coordinates = new List<int[]>();
            var coordinatesNum = movementCoordinates.Count / 2;

            for (int i = 0; i < coordinatesNum; i++)
            {
                if (_movementPath.Count == 0)
                {
                    _movementPath.Add(new int[] { movementCoordinates[1], movementCoordinates[0] });
                    movementCoordinates.RemoveRange(0, 2);
                }
                else
                {
                    var lastRecordedWidthPath = _movementPath[_movementPath.Count - 1][1];
                    var lastRecordedHeightPath = _movementPath[_movementPath.Count - 1][0];

                    var updatedWidthPath = lastRecordedWidthPath + movementCoordinates[0];
                    var updatedHeightPath = lastRecordedHeightPath + movementCoordinates[1];

                    if (updatedWidthPath <= Width && updatedHeightPath <= Height)
                    {
                        _movementPath.Add(new int[] { updatedHeightPath, updatedWidthPath });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                    else if (updatedWidthPath <= Width && updatedHeightPath > Height)
                    {
                        _movementPath.Add(new int[] { 0, updatedWidthPath });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                    else if (updatedWidthPath > Width && updatedHeightPath <= Height)
                    {
                        _movementPath.Add(new int[] { updatedHeightPath, 0 });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                }
            }

            foreach (var x in _movementPath)
            {
                Console.WriteLine("[" + string.Join(",", x) + "]");
            }

            return coordinates;
        }
    }
}