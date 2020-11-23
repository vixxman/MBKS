using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBKS3_16
{
    [Serializable]
    public class Roles
    {
        public int[,] roles = new int[3, 5];

        public Roles()
        {
            for(int i=0; i < 3; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    roles[i, j] = 0;
                }
            }
        }
    }
}
