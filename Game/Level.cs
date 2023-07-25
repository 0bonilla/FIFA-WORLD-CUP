using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Level : IScore
    {
        public Character player;

        public Rivalnpc rivalnpc;

        private Ball ball;

        private Colider colider;

        public Bullet bullet;

        public StaticRenderer staticRenderer;

        public int scoreFra;
        public int scoreArg;

        public bool goalScored;
        //private static List<Bullet> bullets = new List<Bullet>();

        public List<GameObject> GameObjects { get; set; } = new List<GameObject>();

        public event Action ArgenWin;
        public event Action FranceWin;

        public void Start()
        {
            player = GameManager.player;
            rivalnpc = GameManager.rivalnpc;
            ball = GameManager.ball;
            colider = GameManager.colider;
            bullet = GameManager.bullet;
            staticRenderer = new StaticRenderer();

            scoreFra = 0;
            scoreArg = 0;
        }
        public  void Update()
        {
            player.Update();
            rivalnpc.Update();

            CheckCollisionPlayers();
            CheckCollisionBall(ball,ball._radius, player, player._radius);
            CheckCollisionBall(ball,ball._radius, rivalnpc, rivalnpc._radius);


            CheckGoalArg(ball.Transform);
            CheckGoalFra(ball.Transform);
            OutOfBounds(ball.Transform);

            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update();
            }
        }
        public void CheckCollisionPlayers()
        {

            if(colider.CheckCollisionPlayer(player, player._radius, rivalnpc, rivalnpc._radius))
            {
                Engine.Debug("Colisión");
            }
            
        }

        public void CheckCollisionBall(GameObject object1, float radiusA, GameObject object2, float radiusB)
        {
            colider.CheckCollisionBall(object1, radiusA, object2, radiusB);
        }

        public void CheckGoalArg(Transform BallTransform)
        {
            if (BallTransform.Position.Y < 30 && BallTransform.Position.X < 494 && BallTransform.Position.X > 230)
            {
                GameManager.Instance.scorePlayer += 1;
                scoreArg += 1;
                SoftReset();
                Score();
            
            }
        }

        public void CheckGoalFra(Transform BallTransform)
        {
            if (BallTransform.Position.Y > 1050 && BallTransform.Position.X < 494 && BallTransform.Position.X > 230)
            {
                GameManager.Instance.scoreNPC += 1;
                scoreFra += 1;
                SoftReset();
                Score();

            }
        }

        public void Score()
        {
            if (scoreFra == 3)
            {
                FranceWin?.Invoke();
                scoreFra = 0;
                scoreArg = 0;
                player.Initialization();
                rivalnpc.Initialization();
                SoftReset();

            }
            if (scoreArg == 3)
            {
                ArgenWin?.Invoke();
                scoreArg = 0;
                scoreFra = 0;
                player.Initialization();
                rivalnpc.Initialization();
                SoftReset();

            }


            Generic<int, int> exampleInt = new Generic<int, int>(scoreArg, scoreFra);
            exampleInt.DisplayValue();
        }

        public void SoftReset()
        {
            ball._transform.SetPositon(new Vector2(370, 540));
            player._transform.SetPositon(new Vector2(360, 945));
            rivalnpc._transform.SetPositon(new Vector2(360, 153));
        }

        private void OutOfBounds(Transform BallTransform)
        {
            if(BallTransform.Position.Y > 1090 || BallTransform.Position.X > 765 || 
                BallTransform.Position.Y < -10 || BallTransform.Position.X < -10)
            {
                ball._transform.SetPositon(new Vector2(370, 540));
            }
        }
        
        public void Render()
        {      
            Engine.Clear();

            staticRenderer.Render();
            rivalnpc.Render();
            player.Render();
            ball.Render();

            staticRenderer.ShowPointArg(scoreArg);
            staticRenderer.ShowPointFra(scoreFra);

            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Render();
            }

            Engine.Show();
        }
        
    }
}
