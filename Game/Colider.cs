using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Colider
    {
        public Vector2 distance;

        public bool CheckCollisionPlayer(GameObject object1, float radiusA, GameObject object2, float radiusB)
        {
            bool answer = false;

            float distanceX = Math.Abs(object1.Transform.Position.X - object2.Transform.Position.X);
            float distanceY = Math.Abs(object1.Transform.Position.Y - object2.Transform.Position.Y);

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            if (totalDistance < radiusA + radiusB)
            {
                object1.Transform.Translate(new Vector2(-distanceX, -distanceY), 10);
                object2.Transform.Translate(new Vector2(distanceX, distanceY), 10);

                answer = true;
            }

            return answer;
        }

        public bool CheckCollisionBall(GameObject object1, float radiusA, GameObject object2, float radiusB)
        {
            bool answer = false;

            float distanceX = object1.Transform.Position.X - object2.Transform.Position.X;
            float distanceY = object1.Transform.Position.Y - object2.Transform.Position.Y;

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            if (totalDistance < radiusA + radiusB)
            {
                object1.Transform.Translate(new Vector2(distanceX, distanceY), 10);
                answer = true;
            }

            return answer;
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
                }
            }

            return answer;
        }


        
    }
}
