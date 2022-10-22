using mineGameCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineGameCsharp
{
    class Player
    {

        public int player_pos_x = 0;
        public int player_pos_y = 0;
        public void Position()
        {
            string PlayerPosition = "p";
            //仮の方法
            PlayerPosition = Console.ReadLine();
            if (PlayerPosition == "s" && this.player_pos_y < 9)
            {
                this.player_pos_y++;
            }
            if (PlayerPosition == "d" && this.player_pos_x < 9)
            {
                this.player_pos_x++;
            }
        }
    }
}
