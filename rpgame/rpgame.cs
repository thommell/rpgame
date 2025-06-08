using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using rpgame.Core.SceneManaging;
using rpgame.Utilities;

namespace rpgame;

public class Rpgame : Game {
    public Rpgame() {
        GameUtility.GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void LoadContent() {
        GameUtility.SpriteBatch = new SpriteBatch(GraphicsDevice);
        SceneManager.Instance.Initialize();
        base.LoadContent();
    }
    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        SceneManager.Instance.Update(gameTime);
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        base.Draw(gameTime);
    }
}