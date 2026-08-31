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
    private AnimatedSprite _mario;

    private Vector2 _marioPosition;

    private Animation[] marioAnimations;

    private IController _keyboardController;

    private IController _mouseController;

    private SpriteFont _font;

    private Vector2 _textPosition;

    private const float MOVEMENT_SPEED = 5.0f;

    public Game1() : base("game", 1280, 720, false)
    {
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();

        _marioPosition = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height) * 0.5f;
        _mario.CenterOrigin();

        _keyboardController = new KeyboardController();
        _mouseController = new MouseController();

        _textPosition = new Vector2(0, Window.ClientBounds.Height - 200);
    }

    protected override void LoadContent()
    {
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/mario-definition.xml");

        marioAnimations = new Animation[4];
        marioAnimations[0] = atlas.GetAnimation("mario-idle-right");
        marioAnimations[1] = atlas.GetAnimation("mario-idle-left");
        marioAnimations[2] = atlas.GetAnimation("mario-walk-right");
        marioAnimations[3] = atlas.GetAnimation("mario-walk-left");

        _mario = atlas.CreateAnimatedSprite("mario-idle-right");
        _mario.CenterOrigin();
        _mario.Scale = new Vector2(4.0f, 4.0f);

         _font = Content.Load<SpriteFont>("fonts/arial");
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _mario.Update(gameTime);
        _keyboardController.Update();
        _mouseController.Update();
        moveMario(gameTime);
    }

    private void moveMario(GameTime gameTime)
    {
        Vector2 direction = _keyboardController.movementDirection;
        float positionSpeed = MOVEMENT_SPEED;
        Animation idleRight = marioAnimations[0];
        Animation idleLeft = marioAnimations[1];
        Animation walkRight = marioAnimations[2];
        Animation walkLeft = marioAnimations[3];

        if(_keyboardController.isRunning)
        {
            positionSpeed *= 1.5f;
            _mario.Speed = 1.5f;
        }
        else
        {
            _mario.Speed = 1.0f;
        }
        _marioPosition += direction * positionSpeed;

        if(direction.X > 0 && _mario.Animation != walkRight)
        {
            _mario.Animation = walkRight;
        }
        else if(direction.X < 0 && _mario.Animation != walkLeft)
        {
            _mario.Animation = walkLeft;
        }
        else if (direction.X == 0 && _mario.Animation == walkRight)
        {
            _mario.Animation = idleRight;
        }
        else if (direction.X == 0 && _mario.Animation == walkLeft)
        {
            _mario.Animation = idleLeft;
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        SpriteBatch.Begin(samplerState : SamplerState.PointClamp);

        SpriteBatch.DrawString(_font, "Use WASD or Arrow Keys to Move Mario\nUse Space to Run\nProgram Made By: Lucas Blauser\nSprites from gameresources.html on Carmen\nESC to Exit", _textPosition, Color.Black);
        _mario.Draw(SpriteBatch, _marioPosition);

        SpriteBatch.End();

        base.Draw(gameTime);
    }

    
}
    
