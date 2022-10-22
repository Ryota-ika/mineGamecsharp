using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineGameCsharp
{
    class Board
    {
        const int FIELD_HEIGHT = 10;
        const int FIELD_WIDTH = 10;
        public string[,] data = new string[FIELD_WIDTH, FIELD_HEIGHT];
        public bool[,] mine_data = new bool[FIELD_WIDTH, FIELD_HEIGHT];
        public bool[,] goal_data = new bool[9, 9];
        public void SetField()
        {
            for (int i = 0; i < FIELD_WIDTH; i++)
            {
                for (int j = 0; j < FIELD_HEIGHT; j++)
                {
                    data[i, j] = ".";
                }
            }
        }

        public void DrawBoard()
        {
            for (int y = 0; y < FIELD_HEIGHT; y++)
            {
                for (int x = 0; x < FIELD_WIDTH; x++)
                {
                    Console.Write(data[x, y]);
                }
                Console.Write("\n");
            }
        }

        public void SetPlayer(int pos_x, int pos_y)
        {
            data[pos_x, pos_y] = "p";
        }

        public void SetMine(int pos_x, int pos_y)
        {
            mine_data[pos_x, pos_y] = true;
        }
        public void DrawMine()
        {
            for (int i = 0; i < FIELD_WIDTH; i++)
            {
                for (int j = 0; j < FIELD_HEIGHT; j++)
                {
                    if (mine_data[i, j] == true)
                    {
                        data[i, j] = "m";

                    }
                }
            }
        }
        public void MinePosition(Player player)
        {
            List<int> intList = new List<int> { };

            for (int i = 0; i < FIELD_WIDTH; i++)
            {
                for (int j = 0; j < FIELD_HEIGHT; j++)
                {
                    if (mine_data[i, j] == true)
                    {
                        int distance_x = Math.Abs(i - player.player_pos_x);
                        int distance_y = Math.Abs(j - player.player_pos_y);
                        int distance = distance_x + distance_y;
                        intList.Add(distance);
                        //if (distance < 5)
                        //{
                        //    Console.WriteLine("一番近い爆弾の距離は" + distance);
                        //}

                        //if (mindistance > distance)
                        //{
                        //    //mine_list.Add(distance);
                        //    //min_DIstanceを更新
                        //    mindistance = distance;
                        //    Console.WriteLine("一番近い爆弾の距離は"+distance);
                        //}
                    }
                }
            }
            Console.WriteLine("一番近い爆弾の距離は" + intList.Min().ToString());
        }

    }
}
