using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

public static class Globals{
    public static ContentManager GlobalContent; 
    public static KeyboardStateExtended keyboardState;
    public static SoundEffectInstance soundEffectInstance;
    public static SoundEffect soundEffect;
    
    public static void LoadContent()
    {
        soundEffect = GlobalContent.Load<SoundEffect>("./Audio/diner_music");
        soundEffectInstance = soundEffect.CreateInstance();
        soundEffectInstance.IsLooped = true;
    }
    public static void Update(GameTime gameTime)
    {
        soundEffectInstance.Play();
    }
}

    