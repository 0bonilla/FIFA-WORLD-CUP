using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Players
    {

        public Level level;

        public Transform _transform;
        public Renderer _renderer;

        public DateTime timeLastShoot;
        public float timeBetweenShoots = 1f;

        public NotDynamicBulletPool bulletsPool;

        public int availableShots = 7;
        public float movSpeed = 10;
        public float _radius = 47;
        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;

        
        public virtual void Update()
        {
            if (_transform.Position.X >= 1280 + _renderer.Texture.Width)
                _transform.SetPositon(new Vector2(-_renderer.Texture.Width, _transform.Position.Y));
        }

        public void Render()
        {
            _renderer.Render(_transform);
        }

    }
}
