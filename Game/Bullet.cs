using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Bullet: GameObject, IDestroy
    {
        //Bullet properties
        private Animation idleAnimation;
        private Character player;
        private Rivalnpc rivalnpc;

        public bool PlayerShoot;
        public bool RivalShoot;

        public Bullet(Vector2 position, Vector2 scale, float angle, float movementSpeed) : base(position, scale, angle)
        {

            _transform = new Transform(position, scale, angle);
            movSpeed = movementSpeed;   
        }

        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Bullet/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;
        }

        public override void Update()
        {
            player = GameManager.player;
            rivalnpc = GameManager.rivalnpc;

            if (PlayerShoot)
            {
                MoveUp();
            }

            if (RivalShoot)
            {
                MoveDown();
            }

            if (_transform.Position.X >= 720 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));

            currentAnimation.Update();
            if (CheckCollisionBullets(player))
            {
                player.Reset();
            }
            if (CheckCollisionBullets(rivalnpc))
            {
                rivalnpc.Reset();
            }

            CheckCollision();
        }
        public void MoveUp() => _transform.Translate(new Vector2(0, -10f), movSpeed);
        public void MoveDown() => _transform.Translate(new Vector2(0, 10f), movSpeed);

        public void CheckCollision()
        {
            if (Transform.Position.Y < 0)
            {
                Destroy();
            }
        }

        public override void Destroy()
        {
            GameManager.Instance.Level.GameObjects.Remove(this);
        }

        public bool CheckCollisionBullets(GameObject object2)
        {
            bool answer = false;

            for (int i = 0; i < GameManager.Instance.Level.GameObjects.Count; i++)
            {
                GameObject go = GameManager.Instance.Level.GameObjects[i];
                float distanceX = Math.Abs(go.Transform.Position.X - object2.Transform.Position.X);
                float distanceY = Math.Abs(go.Transform.Position.Y - object2.Transform.Position.Y);

                float sumHalfWidths = go.Renderer.Texture.Width / 2 * go.Transform.Scale.X + object2.Renderer.Texture.Width / 2 * object2.Transform.Scale.X;
                float sumHalfHeights = go.Renderer.Texture.Height / 2 * go.Transform.Scale.Y + object2.Renderer.Texture.Height / 2 * object2.Transform.Scale.Y;

                if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
                {
                    answer = true;
                    Destroy();
                }
            }

            return answer;
        }
    }
}


    

