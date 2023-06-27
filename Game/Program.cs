using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Game", 730, 1080);
            GameManager.Instance.Initialization();

            while (true)
            {
                GameManager.Instance.Update();
                GameManager.Instance.Render();
                //Engine.Debug(level.scoreArg);
            }
        }
    }

}