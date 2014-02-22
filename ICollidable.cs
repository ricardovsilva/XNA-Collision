using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collision
{
    public class CollisionHandler : System.EventArgs
    {

    }

    public interface ICollidable
    {
        Rectangle GetBounds();
        event EventHandler OnCollisionEnter;
    }
}
