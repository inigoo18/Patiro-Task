using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task
{
    namespace Part_1
    {
        class Model
        {
            private readonly string label;
            private readonly int timeFactor;

            public Model(string label, int timeFactor)
            {
                this.label = label;
                this.timeFactor = timeFactor;
            }

            public int GetTimeFactor()
            {
                return timeFactor;
            }

            public string GetLabel()
            {
                return label;
            }
        }
    }
}
