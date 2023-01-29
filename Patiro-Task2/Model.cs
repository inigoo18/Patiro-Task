using Patiro_Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task2
{
    class Model
    {
        private readonly string label;
        private readonly int timeFactor;
        private List<CustomCost> customComponents;

        public Model(string label, int timeFactor, List<CustomCost> ccs = null)
        {
            this.label = label;
            this.timeFactor = timeFactor;
            customComponents = ccs;
        }

        public int GetTimeFactor()
        {
            return timeFactor;
        }

        public string GetLabel()
        {
            return label;
        }

        public CustomCost GetComponent(string name) {
            foreach (CustomCost c in customComponents)
            {
                if (c.GetName() == name)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
