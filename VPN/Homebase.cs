using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;


public class Homebase : Block
{

    public Homebase(float x, float y)
    {
        texture = Raylib.LoadTexture("Homebase.png");
        rect = new Rectangle(x, y, 78, 80);
    }

    public void Reset()
    {
        rect = new Rectangle(-78, 100 - 80, 30, 90);
    }
}
