using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    public interface IMovement
    {
        void CalculateRoute(List<int> movementCoordinates, int width, int height);
    }
}
