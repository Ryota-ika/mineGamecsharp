using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineGameCsharp
{
    class Mine
    {
        Random rand = new Random();
        public int mine_pos_x = 0;
        public int mine_pos_y = 0;

        public void RandomPosition()
        {
            mine_pos_x = rand.Next(10);
            mine_pos_y = rand.Next(10);
        }

    }
}
