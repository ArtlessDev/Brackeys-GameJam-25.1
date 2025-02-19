﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace BrackeysGameJam25._1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Player pc;
        public KitchenObject[] kitchen, ingredients;
        public List<Customer> customerQueue;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.GlobalContent = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.LoadContent();
            pc = new Player(){
                rectangle = new Rectangle(50, 100, 64, 64)
            };

            customerQueue = new List<Customer>();

            kitchen = [
                new KitchenObject("BACKGROUND", new(0, 0, 1600, 900), Globals.GlobalContent.Load<Texture2D>("./Sprites/BACKGROUND"), false),
                new KitchenObject("FLOOR", new(0, 800, 1600, 100), Globals.GlobalContent.Load<Texture2D>("./Sprites/FLOOR"), false),

                //new KitchenObject("DOOR", new(0, 0, 320, 320), Globals.GlobalContent.Load<Texture2D>("./Sprites/DOOR"), true),
                new KitchenObject("DOOR", new(0, 480, 320, 320), Globals.GlobalContent.Load<Texture2D>("./Sprites/DOOR"), false),

                new KitchenObject("ARROW1", new(1440, 160, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/ARROW"), true),
                new KitchenObject("ARROW2", new(1440, 480, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/ARROW"), false),
            ];
            // TODO: use this.Content to load your game content here

            ingredients = [
                new KitchenObject(Ingredients.Bread.ToString(), new(480, 0, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/BREAD"), true),
                new KitchenObject(Ingredients.Avocado.ToString(), new(640, 0, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/AVOCADO"), true),
                new KitchenObject(Ingredients.Lettuce.ToString(), new(800, 0, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/LETTUCE"), true),
                new KitchenObject(Ingredients.Bacon.ToString(), new(960, 0, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/BACON"), true),
                new KitchenObject(Ingredients.Patty.ToString(), new(1120, 0, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/PATTY"), true),
                
                new KitchenObject(Ingredients.Pickles.ToString(), new(480, 640, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/PICKLES"), false),
                new KitchenObject(Ingredients.Cheese.ToString(), new(640, 640, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/CHEESE"), false),
                new KitchenObject(Ingredients.RedOnion.ToString(), new(800, 640, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/REDONION"), false),
                new KitchenObject(Ingredients.Mayo.ToString(), new(960, 640, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/MAYO"), false),
                new KitchenObject(Ingredients.Tomato.ToString(), new(1120, 640, 160, 160), Globals.GlobalContent.Load<Texture2D>("./Sprites/TOMATO"), false),
            ];
        
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardExtended.Update();
            Globals.keyboardState = KeyboardExtended.GetState();

            //All Updates
            {
                pc.Update(gameTime, ingredients);
                Globals.Update(gameTime);

                foreach (var ingredient in ingredients)
                {
                    ingredient.Update(gameTime);
                }
            }

            if(gameTime.TotalGameTime.Seconds% 6 == 0 && gameTime.TotalGameTime.Milliseconds % 899 == 0)
            {
                Customer tempCustomer = new Customer().GetCustomer();
                Debug.WriteLine(tempCustomer.identifier);
                Globals.customerCounter++;
                customerQueue.Add(tempCustomer);
            }

            // foreach(var customer in customerQueue)
            // {
            //     customer.Update();
            // }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Teal);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //ITEMS
            foreach (var item in kitchen){
                if(item.rectangle.Y <= 390 && !item.identifier.Equals("BACKGROUND"))
                {
                    item.rotation = (float)Math.PI;
                    var origin = new Vector2(item.texture.Width, item.texture.Height);
                    _spriteBatch.Draw(item.texture, new Rectangle(item.rectangle.X, item.rectangle.Y, item.rectangle.Width, item.rectangle.Height), null, item.color, item.rotation, origin, SpriteEffects.None, 0f);
                }
                else
                {
                    item.rotation = 0f;
                    _spriteBatch.Draw(item.texture, item.rectangle, item.color);
                }
            }
            
            foreach (var item in ingredients){
                if(item.rectangle.Y <= 390 && !item.identifier.Equals("BACKGROUND"))
                {
                    item.rotation = (float)Math.PI;
                    var origin = new Vector2(item.texture.Width, item.texture.Height);
                    _spriteBatch.Draw(item.texture, item.rectangle, null, item.color, item.rotation, origin, SpriteEffects.None, 0f);
                }
                else
                {
                    item.rotation = 0f;
                    _spriteBatch.Draw(item.texture, item.rectangle, item.color);
                }
            }

            // //var tempCustomerQueue = customerQueue.Reverse();
            // foreach(var customer in customerQueue)
            // {
            //     //int xPos = customer.rectangle.X - tempCustomerQueue.Distinct 
            //     //_spriteBatch.Draw(customer.texture, new Rectangle(customer.rectangle.X, customer.rectangle.Y, customer.rectangle.Width, customer.rectangle.Height), customer.color);
            //     _spriteBatch.Draw(customer.texture, customer.rectangle, customer.color);
            // }
            

            for(int customerIndex = customerQueue.Count - 1; customerIndex >= 0; customerIndex--)
            {
                int xPos = 150 - (customerIndex * 40);
                Rectangle tempRect = new Rectangle(xPos, 490, customerQueue[customerIndex].rectangle.Width, customerQueue[customerIndex].rectangle.Height);
                _spriteBatch.Draw(customerQueue[customerIndex].texture, tempRect, customerQueue[customerIndex].color);
            }

            _spriteBatch.Draw(pc.texture, pc.rectangle, pc.color);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
