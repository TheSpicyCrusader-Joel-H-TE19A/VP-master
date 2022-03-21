using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace VPN
{
    public class Level
    {
        string name;
        List<Block> blocks = new List<Block>();
        List<Homebase> homebases = new List<Homebase>();
        // string[] level = {"*                   ",
        //                       "xxxxxxxxxxxxxxxxxxx ",
        //                       "*x   x            x ",
        //                       " x x x x   xxxxxx x ",
        //                       " x x x x   x   x  x ",
        //                       "   x   x  *x*x    x ",
        //                       "xxxxxxxx   xxxxxx x ",
        //                       "*x   x   x        x ",
        //                       " x x x x xxxxxxxxxx ",
        //                       "   x   x            "};
        public Level(string fileName)
        {
            name = fileName;
            string[] level = File.ReadAllLines(fileName);

            for (int y = 0; y < level.Length; y++)
            {
                for (int x = 0; x < level[y].Length; x++)
                {
                    char item = level[y][x];

                    if (item == 'x')
                    {
                        blocks.Add(new Enemy(10 + 90 * x, 10 + 90 * y));
                    }

                    if (item == '*')
                    {
                        blocks.Add(new Homebase(10 + 90 * x, 10 + 90 * y));
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (Block e in blocks)
            {
                e.Draw();
            }
        }

        public string Update(bool playerIsAlive, string scene, Player p, Level currentLevel, Level level1)
        {
            playerIsAlive = true;
            Raylib.ClearBackground(Color.BLUE);
            //commands
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
            {
                return "Deadscreen";
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
            {
                return "Victory";
            }

            //collision 
            foreach (Block e in blocks)
            {
                if (Raylib.CheckCollisionRecs(p.rect, e.rect))
                {
                    if (e is Enemy)
                    {
                        return "Deadscreen";
                    }
                    if (e is Homebase)
                    {
                        return "next";
                    }
                    // else if (e is Homebase && currentLevel == level3)
                    // {
                    //     return "Victory";
                    // }
                }
            }
            return "Arena";
        }





    }
}