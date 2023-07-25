using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    
        public class Generic<T1, T2>
        {
            public T1 Value { get; private set; }
            public T2 Value2 { get; private set; }

            public Generic(T1 value1, T2 value2)
            {
                Value = value1;
                Value2 = value2;
            }

            public void DisplayValue()
            {
                Engine.Debug("Puntaje ARG: " + Value.ToString() + " Puntaje FRA: " + Value2.ToString());
            }
        }

}
