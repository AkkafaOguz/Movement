using System.Collections.Generic;
using System;
using Movement;

namespace Movement
{
    public class Human : Movement, IMovement
    {
        
        public void CalculateRoute(List<int> movementCoordinates, int width, int height)
        {
            var coordinatesNum = movementCoordinates.Count / 2;

            for (var i = 0; i < coordinatesNum; i++)
            {
                if (MovementPath.Count == 0)
                {
                    MovementPath.Add(new int[] { movementCoordinates[0], movementCoordinates[1] });
                    movementCoordinates.RemoveRange(0, 2);
                }
                else
                {
                    var lastRecordedWidthPath = MovementPath[MovementPath.Count-1][0];
                    var lastRecordedHeightPath = MovementPath[MovementPath.Count-1][1];

                    var updatedWidthPath =  lastRecordedWidthPath + movementCoordinates[0];
                    var updatedHeightPath = lastRecordedHeightPath + movementCoordinates[1];

                    if (updatedWidthPath <= width && updatedHeightPath <= height)
                    {
                        MovementPath.Add(new int[] { updatedWidthPath, updatedHeightPath });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                    else if (updatedWidthPath <= width && updatedHeightPath > height)
                    {
                        MovementPath.Add(new int[] { updatedWidthPath, 0 });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                    else if (updatedWidthPath > width && updatedHeightPath <= height)
                    {
                        MovementPath.Add(new int[] { 0, updatedHeightPath });
                        movementCoordinates.RemoveRange(0, 2);
                    }
                }
            }
        }
    }
}