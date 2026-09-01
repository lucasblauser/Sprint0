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
    private IPlayer mario;

    private AnimatedSprite marioSprite;

    private Animation[] marioAnimations;

    private IPlayer luigi;

    private AnimatedSprite luigiSprite;

    private Animation[] luigiAnimations;

    private IController keyboardController;

    private IController mouseController;

    private SpriteFont font;

    private const float MOVEMENT_SPEED = 300.0f; // pixels / second

    public Game1() : base("game", 1280, 720, false)
    {
        
    }

    protected override void Initialize()
    {
        base.Initialize();

        keyboardController = new KeyboardController();
        mouseController = new MouseController();
        Vector2 marioStartPosition = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height) * 0.5f;
        Vector2 luigiStartPosition = marioStartPosition + new Vector2(100, 0);

        mario = new PlatformPlayer(keyboardController, marioStartPosition, marioSprite, marioAnimations, MOVEMENT_SPEED);
        luigi = new PlatformPlayer(mouseController, luigiStartPosition, luigiSprite, luigiAnimations, MOVEMENT_SPEED);
    }

    protected override void LoadContent()
    {
        TextureAtlas marioAtlas = TextureAtlas.FromFile(Content, "images/mario-definition.xml");
        TextureAtlas luigiAtlas = TextureAtlas.FromFile(Content, "images/luigi-definition.xml");

        marioAnimations = new Animation[4];
        marioAnimations[0] = marioAtlas.GetAnimation("mario-idle-right");
        marioAnimations[1] = marioAtlas.GetAnimation("mario-idle-left");
        marioAnimations[2] = marioAtlas.GetAnimation("mario-walk-right");
        marioAnimations[3] = marioAtlas.GetAnimation("mario-walk-left");

        luigiAnimations = new Animation[4];
        luigiAnimations[0] = luigiAtlas.GetAnimation("luigi-idle-right");
        luigiAnimations[1] = luigiAtlas.GetAnimation("luigi-idle-left");
        luigiAnimations[2] = luigiAtlas.GetAnimation("luigi-walk-right");
        luigiAnimations[3] = luigiAtlas.GetAnimation("luigi-walk-left");

        marioSprite = marioAtlas.CreateAnimatedSprite("mario-idle-right");
        marioSprite.CenterOrigin();
        marioSprite.Scale = new Vector2(4.0f, 4.0f);

        luigiSprite = luigiAtlas.CreateAnimatedSprite("luigi-idle-left");
        luigiSprite.CenterOrigin();
        luigiSprite.Scale = new Vector2(4.0f, 4.0f);

         font = Content.Load<SpriteFont>("fonts/arial");
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update();
        mouseController.Update();
        mario.Update(gameTime);
        luigi.Update(gameTime);
        marioSprite.Update(gameTime);
        luigiSprite.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(samplerState : SamplerState.PointClamp);

        SpriteBatch.DrawString(font, "Use WASD or Arrow Keys to Move Mario\nUse Space to Run", Vector2.Zero, Color.Red);
        SpriteBatch.DrawString(font, "Use Mouse Buttons to Move Luigi\nPress Down Scroll Wheel to Run", new Vector2(0, 100), Color.Green);
        SpriteBatch.DrawString(font, "Press ESC to Exit\nCode Made By: Lucas Blauser\nSprites from Carmen and Modified by Me", new Vector2(0, Window.ClientBounds.Height - 130), Color.Black);
        marioSprite.Draw(SpriteBatch, mario.position);
        luigiSprite.Draw(SpriteBatch, luigi.position);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
    
