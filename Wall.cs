using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcEngine
{
    public class Wall : CollisionObject
    {
        public Wall(Vector2 Position, Vector2 Scale, float Rotation)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Rotation = Rotation;
        }

        public override void InitObject()
        {
            DrawColor = Color.Black;
        }

        public override void LoadObjectContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>("Wall");
        }
    }
}
