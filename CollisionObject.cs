using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ArcEngine
{
    public class CollisionObject : GameObject
    {
        public Vector2 Velocity;
        public float Speed;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Sprite.Width * (int)Scale.X, Sprite.Height * (int)Scale.Y);
            }
        }

        public override void InitObject()
        {
            base.InitObject();
        }

        public override void LoadObjectContent(ContentManager content)
        {
            base.LoadObjectContent(content);
        }

        public override void UpdateObject(GameTime gameTime, List<CollisionObject> objects)
        {
            base.UpdateObject(gameTime, objects);
        }

        public override void RenderObject(SpriteBatch batch)
        {
            base.RenderObject(batch);
        }

        protected bool IsTouchingLeft(CollisionObject sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Left &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(CollisionObject sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(CollisionObject sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }

        protected bool IsTouchingBottom(CollisionObject sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }
    }
}
