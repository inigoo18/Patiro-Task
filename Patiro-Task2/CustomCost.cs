using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task2
{
    abstract class CustomCost
    {
        protected string componentName;
        protected bool overrid;

        public abstract double ApplyCost(double realCost);
        public string GetName()
        {
            return componentName;
        }

        public bool GetOverride()
        {
            return overrid;
        }

    }
}
