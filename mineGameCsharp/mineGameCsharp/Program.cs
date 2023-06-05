using System.Diagnostics;
using System;
using System.Drawing;
using mineGameCsharp;
using System.Data;
//using System.Windows.forms;

namespace mineGameCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mG = new Board();
            Player player = new Player();
            Mine mine = new Mine();
            bool end_flg = true;
            //数字を入力してください
            //数字を使って繰り返しの条件
            int mc = 0;
            string mine_count = "";
            bool parse_mine_count = true;
            while (parse_mine_count)
            {
                Console.WriteLine("地雷の数を入力してください。");
                mine_count = Console.ReadLine();
                int.TryParse(mine_count, out mc);
                if (mc != 0)
                {
                    parse_mine_count = false;
                }
            }
            mG.SetField();
            if (mine_count != "")
            {
                //intにしたmine_countを格納
                /*mc = int.Parse( mine_count );*/
                for (int i = 0; i < mc; i++)
                {
                    mine.RandomPosition();
                    if (!(mine.mine_pos_x == 9 && mine.mine_pos_y == 9) || !(mine.mine_pos_x == 0 && mine.mine_pos_y == 0))
                    {
                        mG.SetMine(mine.mine_pos_x, mine.mine_pos_y);
                    }
                }
            }

            //mG内のdataを全て書き出す
            mG.DrawBoard();
            //mG.unit( );

            //mG.MainLoop( );

            //string outChar = "=";
            while (end_flg)
            {
                //キー入力
                //outChar = Console.ReadKey( ).Key.ToString( );
                Console.WriteLine("現在のプレイヤーの位置は" + player.player_pos_x + player.player_pos_y);
                mG.MinePosition(player);
                player.Position();
                //Console.WriteLine( "現在の地雷の位置は" + mine.mine_pos_x + mine.mine_pos_y );
                mG.SetPlayer(player.player_pos_x, player.player_pos_y);
                mG.DrawBoard();
                if (mG.mine_data[player.player_pos_x, player.player_pos_y])
                {
                    Console.WriteLine("地雷を踏みました。");
                    Console.WriteLine("地雷の位置はここでした");
                    mG.DrawMine();
                    mG.DrawBoard();
                    end_flg = false;
                }
                if (player.player_pos_x == 9 && player.player_pos_y == 9
                    /*mG.goal_data[player.player_pos_x,player.player_pos_y]*/ )
                {
                    Console.WriteLine("ゴール！！");
                    Console.WriteLine("地雷の位置はここでした");
                    mG.DrawMine();
                    mG.DrawBoard();
                    end_flg = false;
                }
            }
            //end_flg = CheckKey(outChar);
            //DispMap();
            //DispMessage();
            Console.WriteLine("いずれかのキーを押して終了してください。");
            Console.ReadKey().Key.ToString();
        }

    }
}
