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
    public class TopDownController : CollisionObject
    {
        public static Keys UpKey = Keys.W;
        public static Keys DownKey = Keys.S;
        public static Keys LeftKey = Keys.A;
        public static Keys RightKey = Keys.D;

        public static bool DiagonalMovement = false;

        public TopDownController(Vector2 Position, Vector2 Scale, float Rotation, float Speed, float Accel, float Decel, float MaxSpeed)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Rotation = Rotation;
            this.Speed = Speed;
            this.Accel = Accel;
            this.Decel = Decel;
            this.MaxSpeed = MaxSpeed;
        }

        public override void InitObject()
        {
            DrawColor = Color.White;
        }

        public override void LoadObjectContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>("Wall");
        }

        public override void UpdateObject(GameTime gameTime, List<CollisionObject> objects)
        {
            Move();
            foreach (var sprite in objects)
            {
                if (sprite == this)
                    continue;
                
                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                this.Velocity.X = 0;

                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity.Y < 0 & this.IsTouchingBottom(sprite)))
                this.Velocity.Y = 0;
            }

            Position += Velocity;

            Velocity.X = TendToZero(Velocity.X, Decel);
            Velocity.Y = TendToZero(Velocity.Y, Decel);
            base.UpdateObject(gameTime, objects);
        }

        private void Move() {
            if (Keyboard.GetState().IsKeyDown(UpKey)) {
                MoveUp();
            }
            if (Keyboard.GetState().IsKeyDown(DownKey)) {
                MoveDown();
            }
            if (Keyboard.GetState().IsKeyDown(LeftKey)) {
                MoveLeft();
            }
            if (Keyboard.GetState().IsKeyDown(RightKey)) {
                MoveRight();
            }
        }

        protected void MoveRight()
        {
            Velocity.X += Accel + Decel;

            if (Velocity.X > MaxSpeed)
            {
                Velocity.X = MaxSpeed;
            }

            Direction.X = 1;
        }
        protected void MoveLeft()
        {
            Velocity.X -= Accel + Decel;

            if (Velocity.X < -MaxSpeed)
            {
                Velocity.X = -MaxSpeed;
            }

            Direction.X = -1;
        }

        protected void MoveDown()
        {
            Velocity.Y += Accel + Decel;

            if (Velocity.Y > MaxSpeed)
            {
                Velocity.Y = MaxSpeed;
            }
            Direction.Y = -1;
        }
        protected void MoveUp()
        {
            Velocity.Y -= Accel + Decel;

            if (Velocity.Y < -MaxSpeed)
            {
                Velocity.Y = -MaxSpeed;
            }
            Direction.Y = 1;
        }

        public override void RenderObject(SpriteBatch batch)
        {
            base.RenderObject(batch);
        }

        private float TendToZero(float val, float amount)
        {
            if (val > 0f && (val -= amount) < 0f) return 0f;
            if (val < 0f && (val += amount) > 0f) return 0f;
            return val;
        }
    }
}
