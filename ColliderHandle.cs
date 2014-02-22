using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
    public class ColliderHandle : GameComponent
    {
        private List<ICollidable> CollidableObjects;

        public ColliderHandle(Game game)
            : base(game)
        {
            CollidableObjects = new List<ICollidable>();
        }

        public void AddCollidable()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            CleanList();
            CheckCollisions();
            base.Update(gameTime);
        }

        private void CleanList()
        {
            foreach(ICollidable collidable in CollidableObjects)
            {
                if(collidable == null)
                {
                    CollidableObjects.Remove(collidable);
                }
            }
        }

        private void CheckCollisions()
        {
            foreach(ICollidable currentCollidable in CollidableObjects)
            {
                foreach(ICollidable collidable in CollidableObjects)
                {
                    if(collidable != currentCollidable)
                    {
                        bool isColliding = false;
                        Rectangle currenCollidableRec = currentCollidable.GetBounds();
                        collidable.GetBounds().Intersects(ref currenCollidableRec, out isColliding);

                        if(isColliding)
                        {
                            currentCollidable.OnCollisionEnter.Invoke(collidable, null);
                        }
                    }
                }
            }
        }
    }
}
