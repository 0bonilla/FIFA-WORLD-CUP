using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class StaticRenderer
    {
        public void Render()
        {
            Engine.Draw("Textures/CanchaSola.png", 0, 0, 1, 1);
            Engine.Draw("Textures/ArcoArriba.png", 230, 20, 1, 1);
            Engine.Draw("Textures/ArcoArriba.png", 480, 1065, 1, 1, 180, 0);

        }

        public void ShowPointArg(int points)
        {
            if (points >= 1)
            {
                Engine.Draw("Textures/Points/ScoreArg.png", 40, 15, 0.1f, 0.1f);
            }
            if (points >= 2)
            {
                Engine.Draw("Textures/Points/ScoreArg.png", 80, 15, 0.1f, 0.1f);
            }

        }

        public void ShowPointFra(int points)
        {
            if (points >= 1)
            {
                Engine.Draw("Textures/Points/ScoreFra.png", 660, 15, 0.1f, 0.1f);
            }
            if (points >= 2)
            {
                Engine.Draw("Textures/Points/ScoreFra.png", 620, 15, 0.1f, 0.1f);
            }
        }
    }
}
