using System;
using Raylib_cs;

public class Block
{

    public Rectangle rect;

    protected Texture2D texture;

    public void Draw()
    {
        Raylib.DrawTexture(texture, (int)rect.x, (int)rect.y, Color.WHITE);
    }
}