using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

interface IObject {
    public string identifier {get; set;}
    public Rectangle rectangle{get; set;}
    public Texture2D texture{get; set;}
    public Color color{get; set;}
}