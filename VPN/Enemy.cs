using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;



public class Enemy : Block
{
    public Enemy(float x, float y)
    {
        rect = new Rectangle(x, y, 78, 80);
        texture = Raylib.LoadTexture("Enemy.png");
    }

    public void Reset()
    {
        rect = new Rectangle(-78, 100 - 80, 78, 80);
    }
}
