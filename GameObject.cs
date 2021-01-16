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
    public class GameObject
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
        public Color DrawColor;
        public SpriteEffects SpriteEffect;
        public Texture2D Sprite;
        public Vector2 Origin;
        public float LayerDepth;
        public float Decel;
        public float Accel;
        public Vector2 Direction;
        public float MaxSpeed;

        public virtual void InitObject()
        {

        }

        public virtual void LoadObjectContent(ContentManager content)
        {

        }

        public virtual void UpdateObject(GameTime gameTime, List<CollisionObject> objects)
        {

        }

        public virtual void RenderObject(SpriteBatch batch)
        {
            batch.Draw(Sprite, Position, null, DrawColor, Rotation, Origin, Scale, SpriteEffect, LayerDepth);
        }
    }
}
