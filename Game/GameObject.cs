using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject: Players
    {
        protected Animation currentAnimation;

        public GameObject(Vector2 position, Vector2 scale, float angle)
        {
            _transform = new Transform(position, scale, angle);
            CreateAnimations();
            _renderer = new Renderer(currentAnimation, scale);
        }

        protected abstract void CreateAnimations();

        public virtual void GetDamage(int damage)
        {

        }
        public virtual void Destroy()
        {

        }
    }
}
