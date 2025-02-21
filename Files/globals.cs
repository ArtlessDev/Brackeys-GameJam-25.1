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
    public static SoundEffectInstance soundEffectInstance, pickupInstance, deliverInstance, incorrectInstance;
    public static SoundEffect soundEffect, pickup, deliver, incorrect;
    public static bool gravFlip = true;
    public static int customerCounter = 0;
    public static SpriteFont gameFont;

    
    public static void LoadContent()
    {
        soundEffect = GlobalContent.Load<SoundEffect>("./Audio/diner_music");
        soundEffectInstance = soundEffect.CreateInstance();
        soundEffectInstance.Volume = .02f;
        soundEffectInstance.IsLooped = true;

        deliver = GlobalContent.Load<SoundEffect>("./Audio/deliver");
        deliverInstance = deliver.CreateInstance();
        deliverInstance.Volume = .15f;
        deliverInstance.IsLooped = false;
        
        pickup = GlobalContent.Load<SoundEffect>("./Audio/pickup");
        pickupInstance = pickup.CreateInstance();
        pickupInstance.Volume = .10f;
        pickupInstance.IsLooped = false;

        incorrect = GlobalContent.Load<SoundEffect>("./Audio/incorrect");
        incorrectInstance = incorrect.CreateInstance();
        incorrectInstance.Volume = .3f;
        incorrectInstance.IsLooped = false;

        gameFont = GlobalContent.Load<SpriteFont>("./Audio/PrettyPixel");
    }

    //THIS IS USELESS BUT I KNOWQ HOW TO PROPERLY IMPLEMENT FOR NEXT TIME
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

    