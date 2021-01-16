using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ArcEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public List<CollisionObject> objects = new List<CollisionObject>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            CreateLevel();
            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            InitObjects();
            LoadObjectContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdateObjects(gameTime, objects);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            RenderObjects();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        void CreateLevel()
        {
            objects.Add(new TopDownController(new Vector2(100, 100), new Vector2(1, 1), 0f, 10f, 1, 1, 4));
            objects.Add(new Wall(new Vector2(0,400), new Vector2(300,700), 0f));
        }

        void InitObjects()
        {
            for(int i = 0; i < objects.Count; i++)
            {
                objects[i].InitObject();
            }
        }

        void LoadObjectContent()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].LoadObjectContent(Content);
            }
        }

        void UpdateObjects(GameTime gameTime, List<CollisionObject> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].UpdateObject(gameTime, objects);
            }
        }

        void RenderObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].RenderObject(_spriteBatch);
            }
        }
    }
}
