using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ball : GameObject
    {
        //Ball properties

        private Animation idleAnimation;

        public new float _radius = 30;

        public Ball(Vector2 position, Vector2 scale, float angle) : base(position, scale, angle)
        {
            _transform = new Transform(position, scale, angle);

        }

        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Pelota/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }

        public new void Update()
        {
            if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            currentAnimation.Update();
        }
    }
}
