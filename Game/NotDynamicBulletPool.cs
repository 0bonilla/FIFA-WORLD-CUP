using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class NotDynamicBulletPool
   {
        private List<Bullet> bulletsInUse = new List<Bullet>();
        private List<Bullet> bulletsAvaivables = new List<Bullet>();

        public NotDynamicBulletPool (int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                Bullet bullet = new Bullet(new Vector2(0, 0), new Vector2(0.1469f, 0.1469f), 0, 50);
                bulletsAvaivables.Add(bullet);
            }
        }

    public Bullet GetBullet()
    {
        Bullet bulletToReturn = null;

        if(bulletsAvaivables.Count > 0)
        {
                bulletToReturn = bulletsAvaivables[0];
                bulletsAvaivables.RemoveAt(0);
                bulletsInUse.Add(bulletToReturn);
        }
            return bulletToReturn;

    }

        private void RecycleBullet(Bullet bullet)
        {
            if (bulletsInUse.Contains(bullet))
            {
                bulletsInUse.Remove(bullet);
                bulletsAvaivables.Add(bullet);
            }
        }
        public void Reset()
        {
            
        }

    }


}
