using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Customer : IObject
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Texture2D texture { get; set; }
    public Color color { get; set; }
    public int patience { get; set; }
    public float patienceCounter { get; set; }
    public string[] customerOrder { get; set;}

    public Customer()
    {

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public void Update()
    {
        
    }

    public Customer GetCustomer()
    {
        int rand = Random.Shared.Next(0,4);

        int ingredientCount = Random.Shared.Next(1,7);

        if (Globals.customerCounter < 3)
            rand = Random.Shared.Next(2,4);

        switch (rand)
        {
            case 0:
                return GetRedCustomer(ingredientCount);
            case 1:
                return GetOrangeCustomer(ingredientCount);
            case 2:
                return GetYellowCustomer(ingredientCount);
            case 3:
            default:
                return GetGreenCustomer(ingredientCount);
        }
    }

    public Customer GetGreenCustomer(int ingredientCount)
    {
        string[] ingredients = new string[ingredientCount];
        for(var i = 0; i < ingredientCount; i++)
        {
            var tempIngredient = (Ingredients)(Random.Shared.Next(0,10));
            ingredients[i] = tempIngredient.ToString();

        }

        return new Customer()
        {
            identifier = "Green",
            patience = 30,
            texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/GreenAlien"),
            rectangle = new Rectangle(150, 490, 160, 160),
            color = Color.White,
            customerOrder = ingredients,
        };
    }
    public Customer GetYellowCustomer(int ingredientCount)
    {
        string[] ingredients = new string[ingredientCount];
        for(var i = 0; i < ingredientCount; i++)
        {
            var tempIngredient = (Ingredients)(Random.Shared.Next(0,10));
            ingredients[i] = tempIngredient.ToString(); 


        }

        return new Customer()
        {
            identifier = "Yellow",
            patience = 30,
            texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/YellowAlien"),
            rectangle = new Rectangle(150, 490, 160, 160) ,
            color = Color.White,
            customerOrder = ingredients,
        };
    }
    public Customer GetOrangeCustomer(int ingredientCount)
    {
        string[] ingredients = new string[ingredientCount];
        for(var i = 0; i < ingredientCount; i++)
        {
            var tempIngredient = (Ingredients)(Random.Shared.Next(0,10));
            ingredients[i] = tempIngredient.ToString(); 


        }

        return new Customer()
        {
            identifier = "Orange",
            patience = 25,
            texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/OrangeAlien"),
            rectangle = new Rectangle(150, 490, 160, 160) ,
            color = Color.White,
            customerOrder = ingredients

        };
    }
    public Customer GetRedCustomer(int ingredientCount)
    {
        string[] ingredients = new string[ingredientCount];
        for(var i = 0; i < ingredientCount; i++)
        {
            var tempIngredient = (Ingredients)(Random.Shared.Next(0,10));
            ingredients[i] = tempIngredient.ToString(); 


        }
        
        return new Customer()
        {
            identifier = "Red",
            patience = 15,
            texture = Globals.GlobalContent.Load<Texture2D>("./Sprites/RedAlien"),
            rectangle = new Rectangle(150, 490, 160, 160) ,
            color = Color.White,
            customerOrder = ingredients

        };
    }

    
}