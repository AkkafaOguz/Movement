using System.Collections.Generic;
using System;
using Movement;

namespace Movement
{
    public class Human : Movement
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
                    _movementPath.Add(new int[] { movementCoordinates[0], movementCoordinates[1] });
                    movementCoordinates.RemoveRange(0, 2);
                }
                else
                {
                    var lastRecordedWidthPath = _movementPath[_movementPath.Count-1][0];
                    var lastRecordedHeightPath = _movementPath[_movementPath.Count-1][1];

                    var updatedWidthPath =  lastRecordedWidthPath + movementCoordinates[0];
                    var updatedHeightPath = lastRecordedHeightPath + movementCoordinates[1];

                    if (updatedWidthPath < Width && updatedHeightPath < Height)
                    {
                        _movementPath.Add(new int[] { updatedWidthPath, updatedHeightPath });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                    else if (updatedWidthPath < Width && updatedHeightPath > Height)
                    {
                        _movementPath.Add(new int[] { updatedWidthPath, 0 });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                    else if (updatedWidthPath > Width && updatedHeightPath < Height)
                    {
                        _movementPath.Add(new int[] { 0, updatedHeightPath });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                }
            }

            return _movementPath;
        }
    }
}