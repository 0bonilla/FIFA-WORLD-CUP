﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Rivalnpc : GameObject, IReset
    {
        //Rival properties
        public int availableShots = 4;
        private Animation idleAnimation;
        public Vector2 InitialPosition = new Vector2(360, 153);

        public Rivalnpc(Vector2 position, Vector2 scale, float angle, float movementSpeed) : base(position, scale, angle)
        {
            _transform = new Transform(position, scale, angle);
            movSpeed = movementSpeed;
            bulletsPool = new NotDynamicBulletPool(availableShots);
        }

        protected override void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 5; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/PlayerFrancia/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
            currentAnimation = idleAnimation;

        }

        public void Initialization()
        {
            bulletsPool = new NotDynamicBulletPool(availableShots);
        }

        public override void Update()
        {
            InputReading();
        }
        private Transform InputReading()
        {
            if (Engine.GetKey(Keys.UP)) MoveUp();
            if (Engine.GetKey(Keys.DOWN)) MoveDown();
            if (Engine.GetKey(Keys.LEFT)) MoveLeft();
            if (Engine.GetKey(Keys.RIGHT)) MoveRight();
            if (Engine.GetKey(Keys.L)) Shoot();
            return _transform;
        }

        public void MoveUp() => _transform.Translate(new Vector2(0, -1.5f), movSpeed);
        public void MoveDown() => _transform.Translate(new Vector2(0, 1.5f), movSpeed);
        public void MoveLeft() => _transform.Translate(new Vector2(-1.5f, 0), movSpeed);
        public void MoveRight() => _transform.Translate(new Vector2(1.5f, 0), movSpeed);

        private void Shoot()
        {
            DateTime currentTime = DateTime.Now;
            if ((currentTime - timeLastShoot).TotalSeconds >= timeBetweenShoots)
            {
                Bullet bullet = bulletsPool.GetBullet();

                if (bullet != null)
                {
                    bullet.RivalShoot = true;
                    bullet.Transform.SetPositon(new Vector2(Transform.Position.X, Transform.Position.Y + 100));
                    GameManager.Instance.Level.GameObjects.Add(bullet);
                }
                timeLastShoot = currentTime;
            }
        }

        public void Reset()
        {
            _transform.SetPositon(new Vector2(360, 540));
        }
    }

 
}
