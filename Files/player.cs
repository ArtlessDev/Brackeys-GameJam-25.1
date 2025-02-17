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
        if(Globals.keyboardState.IsKeyDown(Keys.Left))
        {
            rectangle = new Rectangle(rectangle.X-5, rectangle.Y, 64, 64);
        }
        else if(Globals.keyboardState.IsKeyDown(Keys.Right))
        {
            rectangle = new Rectangle(rectangle.X+5, rectangle.Y, 64, 64);
        }
        // else if(Globals.keyboardState.WasKeyPressed(Keys.Up))
        // {
        //     rectangle = new Rectangle(rectangle.X, rectangle.Y-1, 64, 64);
        // }
        // else if(Globals.keyboardState.WasKeyPressed(Keys.Down))
        // {
        //     rectangle = new Rectangle(rectangle.X, rectangle.Y+1, 64, 64);
        // }
    }

    public void Update(GameTime gameTime, KitchenObject[] ingredients)
    {
        Movement();
        if (rectangle.Y < 750){
            rectangle = new Rectangle(rectangle.X, rectangle.Y+10, 64, 64);
        }


        foreach(KitchenObject ingredient in ingredients)
        {
            if(ingredient.rectangle.Intersects(this.rectangle)
            && (int)(gameTime.TotalGameTime.TotalMilliseconds % 1000)  == 0)
            {
                Debug.WriteLine(ingredient.identifier);
            }
        }
    }


}