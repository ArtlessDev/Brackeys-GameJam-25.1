using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Customer : IObject
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Texture2D texture { get; set; }
    public Color color { get; set; } = Color.White;
    public int patience { get; set; }

    public Customer(){
        int rand = Random.Shared.Next(0,3);

        if (Globals.customerCounter < 3)
            rand = Random.Shared.Next(2,3);

        GetCustomer(rand);
    }

    public Customer GetCustomer(int rand)
    {
        switch (rand)
        {
            case 0:
                return GetRedCustomer();
            case 1:
                return GetOrangeCustomer();
            case 2:
                return GetYellowCustomer();
            case 3:
            default:
                return GetGreenCustomer();
        }
    }

    Customer GetGreenCustomer()
    {
        return new Customer()
        {
            identifier = "Green",
            patience = 30,

        };
    }
    Customer GetYellowCustomer()
    {
        return new Customer()
        {
            identifier = "Yellow",
            patience = 30,

        };
    }
    Customer GetOrangeCustomer()
    {
        return new Customer()
        {
            identifier = "Orange",
            patience = 25,

        };
    }
    Customer GetRedCustomer()
    {
        return new Customer()
        {
            identifier = "Red",
            patience = 15,

        };
    }
}