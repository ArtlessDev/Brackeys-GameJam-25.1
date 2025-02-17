using System.Data.Common;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class KitchenObject : IObject 
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Texture2D texture { get; set; }
    public Color color{ get; set; }
    public float rotation { get; set; }
    public bool isFloating { get; set; }

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


}

public enum Objects{
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