using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Input;

public static class Globals{
    public static ContentManager GlobalContent; 
    public static KeyboardStateExtended keyboardState;
    public static SoundEffectInstance soundEffectInstance;
    public static SoundEffect soundEffect;
    public static bool gravFlip = true;
    public static int customerCounter = 0;

    
    public static void LoadContent()
    {
        soundEffect = GlobalContent.Load<SoundEffect>("./Audio/diner_music");
        soundEffectInstance = soundEffect.CreateInstance();
        soundEffectInstance.IsLooped = true;

        gameFont = GlobalContent.Load<SpriteFont>("./Audio/PrettyPixelBIG");
    }
    public static void Update(GameTime gameTime)
    {
        soundEffectInstance.Play();

        // if((int)(gameTime.TotalGameTime.Seconds % 10) == 0 && gravFlip)
        // {
        //     Debug.WriteLine()
        //     gravFlip = false;
        // }
        // else if((int)(gameTime.TotalGameTime.Seconds % 10)  != 0  && !gravFlip)
        // {
        //     gravFlip = true;
        // }
    }
}

    