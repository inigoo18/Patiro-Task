using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task2
{
    abstract class CustomCost
    {
        // name of the cost, used to identify the user input such in e.g: "Risk:high"
        protected string componentName;
        // this bool lets us know if the custom cost is initialized by the user or if it
        protected bool overrid;

        // function that will be implemented in the inherited classes to apply an additional cost.
        public abstract double ApplyCost(double realCost);
        public string GetName()
        {
            return componentName;
        }

        public bool GetOverride()
        {
            return overrid;
        }

        // this static function allows us to build classes based on the user input.
        public static CustomCost CostParser(string name, string val)
        {
            if (name == "Risk")
            {
                RiskCost rc = new RiskCost(val, true);
                return rc;
            }
            else if (name == "Inconvenience")
            {
                InconvenienceCost ic = new InconvenienceCost(val, true);
                return ic;
            }
            else
            {
                return null;

            }
        }

    }
}
