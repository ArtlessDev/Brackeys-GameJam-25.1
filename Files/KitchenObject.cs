using System.Data.Common;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

public class KitchenObject : IObject 
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Texture2D texture { get; set; }
    public Color color{ get; set; }
    public float rotation { get; set; }
    public bool? isFloating { get; set; }

    public KitchenObject()
    {
        rectangle = new();
        texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/BACKGROUND");
        identifier = "";
        color = Color.White;
        rotation = 0;
    }

    public KitchenObject(string objName, Rectangle rect, Texture2D txtr, bool floating)
    {
        identifier = objName;
        rectangle = rect;
        texture = txtr;
        color = Color.White;
        rotation = 0;
        isFloating = floating;
    }

    public void ApplyGravity(){
        if (rectangle.Y < 640 && isFloating == false)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y+10, 160, 160);
        }
        else if (rectangle.Y > 0 && isFloating == true)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y-10, 160, 160);
        }
    }

    public void Update(GameTime gameTime)
    {

        ///TGT.Seconds tracks the seconds in the game and i assume resets every minute
        ///TGT.Milliseconds only tracks that of a second so it resets every 1000 milliseconds, duh in hindsight
        ///both are needed to, 1. only have it run every x seconds and only on the millisecond listed 
        if (isFloating == true && gameTime.TotalGameTime.Seconds % 6 == 0 && gameTime.TotalGameTime.Milliseconds % 899 == 0)
        {
            //Debug.WriteLine("change " + gameTime.TotalGameTime.Seconds);
            isFloating = false;
        }
        else if (isFloating == false && gameTime.TotalGameTime.Seconds % 6 == 0 && gameTime.TotalGameTime.Milliseconds % 899 == 0)
        {
            //Debug.WriteLine("change");
            isFloating = true;
        }   
        ApplyGravity();
    }
}

public enum Ingredients{
    Bread,
    RedOnion,
    Tomato,
    Pickles,
    Lettuce,
    Patty,
    Avocado,
    Bacon,
    Cheese,
    Mayo,
}