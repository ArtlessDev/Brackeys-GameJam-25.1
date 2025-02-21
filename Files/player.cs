using System.Collections.Generic;
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
    public List<string> ingredientStack;

    public SpriteEffects flipper;

    public Player()
    {
        identifier = "blokkit";
        texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/blokkit");
        rectangle = new Rectangle(0, 0, 64, 64);
        color = Color.White;
        ingredientStack = new List<string>();
        flipper = SpriteEffects.None;
    }

    public void Movement()
    {
        if(Globals.keyboardState.IsKeyDown(Keys.Left))
        {
            flipper = SpriteEffects.FlipHorizontally;
            rectangle = new Rectangle(rectangle.X-5, rectangle.Y, 64, 64);
        }
        else if(Globals.keyboardState.IsKeyDown(Keys.Right))
        {
            rectangle = new Rectangle(rectangle.X+5, rectangle.Y, 64, 64);
        }
    }

    public void Update(GameTime gameTime, KitchenObject[] ingredients)
    {
        Movement();
        if (rectangle.Y < 750){
            rectangle = new Rectangle(rectangle.X, rectangle.Y+10, 64, 64);
        }


        foreach(KitchenObject ingredient in ingredients)
        {
            if(ingredient.rectangle.Intersects(rectangle)
            && Globals.keyboardState.WasKeyPressed(Keys.Space))
            {
                //Debug.WriteLine(ingredient.identifier);
                Globals.pickupInstance.Play();
                ingredientStack.Add(ingredient.identifier);
            }
            if(ingredient.rectangle.Intersects(rectangle)
            && Globals.keyboardState.WasKeyPressed(Keys.Tab))
            {
                //Debug.WriteLine(ingredient.identifier);
                Globals.pickupInstance.Play();
                ingredientStack.Remove(ingredient.identifier);
                Debug.WriteLine(ingredientStack.Count);
            }
        }
    }


}