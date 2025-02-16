using System.Data.Common;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : IObject 
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Texture2D texture { get; set; }
    public Color color{ get; set; }

    public Player()
    {
        identifier = "blokkit";
        texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/blokkit");
        rectangle = new Rectangle(0, 0, 64, 64);
        color = Color.White;
    }

    public void Movement()
    {
        if(Globals.keyboardState.WasKeyPressed(Keys.Left))
        {
        Debug.WriteLine("in movemment");
            rectangle = new Rectangle(rectangle.X-64, rectangle.Y, 64, 64);
        }
        else if(Globals.keyboardState.WasKeyPressed(Keys.Right))
        {
        Debug.WriteLine("in movemment");
            rectangle = new Rectangle(rectangle.X+64, rectangle.Y, 64, 64);
        }
        else if(Globals.keyboardState.WasKeyPressed(Keys.Up))
        {
        Debug.WriteLine("in movemment");
            rectangle = new Rectangle(rectangle.X, rectangle.Y-64, 64, 64);
        }
        else if(Globals.keyboardState.WasKeyPressed(Keys.Down))
        {
        Debug.WriteLine("in movemment");
            rectangle = new Rectangle(rectangle.X, rectangle.Y+64, 64, 64);
        }
    }

    public void Update(GameTime gameTime)
    {
        Movement();
    }
}