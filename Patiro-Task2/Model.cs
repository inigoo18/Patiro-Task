using Patiro_Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task
{
    class Model
    {
        private readonly string label;
        private readonly int timeFactor;
        private List<CustomComponent> customComponents;

        public Model(string label, int timeFactor, List<CustomComponent> ccs = null)
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

        public CustomComponent GetComponent(string name) {
            foreach (CustomComponent c in customComponents)
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
