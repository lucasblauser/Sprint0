using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

namespace game;

public class Game1 : Core

{
    private I2DPlatformPlayer mario;

    private I2DPlatformPlayer luigi;

    private IController keyboardController;

    private IController mouseController;


    private SpriteFont font;


    public Game1() : base("Sprint0", 1280, 720, false)
    {
        
    }

    protected override void Initialize()
    {
        keyboardController = new KeyboardController();
        mouseController = new MouseController();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        TextureAtlas marioAtlas = TextureAtlas.FromFile(Content, "images/mario-definition.xml");
        TextureAtlas luigiAtlas = TextureAtlas.FromFile(Content, "images/luigi-definition.xml");

        Vector2 marioStartPosition = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height) * 0.5f;
        Vector2 luigiStartPosition = marioStartPosition + new Vector2(100, 0);

        mario = new Mario(keyboardController, marioStartPosition, marioAtlas);
        luigi = new Luigi(mouseController, luigiStartPosition, luigiAtlas);

        font = Content.Load<SpriteFont>("fonts/arial");
    }

    protected override void Update(GameTime gameTime)
    {
        mario.Update(gameTime);
        luigi.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(samplerState : SamplerState.PointClamp);

        SpriteBatch.DrawString(font, "Use WASD or Arrow Keys to Move Mario\nUse Space to Run", Vector2.Zero, Color.Red);
        SpriteBatch.DrawString(font, "Use Mouse Buttons to Move Luigi\nPress Down Scroll Wheel to Run", new Vector2(0, 100), Color.Green);
        SpriteBatch.DrawString(font, "Press ESC to Exit\nCode Made By: Lucas Blauser\nSprites from Carmen and Modified by Me", new Vector2(0, Window.ClientBounds.Height - 130), Color.Black);
        mario.Draw(SpriteBatch);
        luigi.Draw(SpriteBatch);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
    
