using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public enum GameState
    {
        MainMenu,
        WinScreen,
        DefeatScreen,
        Level
    }

    public class GameManager
    {
        private static Time time;

        public static Character player;

        public static Rivalnpc rivalnpc;

        public static Ball ball;

        public static Colider colider;

        public static Bullet bullet;

        private static StaticRenderer staticRenderer;

        public static Character Player => player;

        public static Rivalnpc Rivalnpc => rivalnpc;

        public static Ball Ball => ball;

        public static Colider Colider => colider;
        public static Bullet Bullet => bullet;

        public static StaticRenderer StaticRenderer => staticRenderer;

        public Level Level { get; private set; }

        private static GameManager instance;

        public float scorePlayer;
        public float scoreNPC;

        public const string DEFEAT_PATH = "Textures/Screens/Player2Wins.png";
        public const string VICTORY_PATH = "Textures/Screens/Player1Wins.png";
        public const string MAINMENU_PATH = "Textures/Screens/MainMenu.png";


        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public GameState CurrentState { get; private set; }

        public void Initialization()
        {
            ChangeGameState(GameState.MainMenu);
            player = new Character(new Vector2(360, 923), new Vector2(0.22f, 0.22f), 0, 125);
            rivalnpc = new Rivalnpc(new Vector2(360, 153), new Vector2(0.22f, 0.22f), 0, 125);
            ball = new Ball(new Vector2(370, 540), new Vector2(0.1f, 0.1f), 0);
            colider = new Colider();
            Level = new Level();
            staticRenderer = new StaticRenderer();
            Level.Start();
            time.Start();

        }

        public void Update()
        {
            Level.ArgenWin += Player1Win;
            Level.FranceWin += Player2Win;

            if (Engine.GetKey(Keys.SPACE))
            {
                ChangeGameState(GameState.Level);
            }
            if (Engine.GetKey(Keys.ESCAPE))
            {
                ChangeGameState(GameState.MainMenu);
                scorePlayer = 0; scoreNPC = 0;
            }

            Level.Update();
            time.Update();
        }

        public void Render()
        {
            Engine.Clear();
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    Engine.Draw(MAINMENU_PATH, 0, 0);
                    break;
                case GameState.WinScreen:
                    Engine.Draw(VICTORY_PATH, 0, 0);
                    break;
                case GameState.DefeatScreen:
                    Engine.Draw(DEFEAT_PATH, 0, 0);
                    break;
                case GameState.Level:
                    LevelShow();
                    break;
            }
            Engine.Show();           
        }

        public void ChangeGameState(GameState newState)
        {
            CurrentState = newState;
        }

        private void LevelShow()
        {
            Level.Render();
        }

        private void Player1Win()
        {
            ChangeGameState(GameState.WinScreen);
            scorePlayer = 0;
        }

        private void Player2Win()
        {
            ChangeGameState(GameState.DefeatScreen);
            scoreNPC = 0;
        }
    }
}
