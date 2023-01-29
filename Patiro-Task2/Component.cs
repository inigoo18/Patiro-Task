using System;
using System.Collections.Generic;
using Patiro_Task2;

namespace Patiro_Task2
{
    class Component
    {
        private readonly Model model;
        private readonly double time;
        private readonly double money;
        private readonly int globalFactor;
        // this list of custom costs specifies which costs will be taken into consideration when computing the cost of the component.
        private readonly List<CustomCost> wantedCosts;

        public Component(double time, double money, string modelID, ModelList ms, List<CustomCost> cs = null)
        {
            this.time = time;
            this.money = money;
            globalFactor = 300;

            // find the actual model object through the modelID.
            model = ms.FindModel(modelID);
            wantedCosts = cs;
        }

        public double ComputeCost()
        {
            int timeFactor;
            if (model == null)
            {
                // if there is no model to be found, we use the global factor...
                timeFactor = globalFactor;
            }
            else
            {
                // ...otherwise use the model's local factor.
                timeFactor = model.GetTimeFactor();
            }

            // we divide by 60 in order to have time in hours instead of minutes.
            double tmp = Math.Round((time / 60) * (timeFactor) + money);
            double finalResult = tmp;

            // for each custom cost that must be considered for the computation...
            foreach (CustomCost c in wantedCosts)
            {
                // if it was specified by the user, we leave it as is
                CustomCost usedComponent = c;
                if (!c.GetOverride())
                {
                    // if it was not specified by the user, we must take it from the model...
                    if (model != null)
                    {
                        // we try to get it from the model object, if it can't then the global values must be considered.
                        usedComponent = model.GetCustomCost(c.GetName());
                        if (usedComponent == null)
                        {
                            usedComponent = c;
                        }
                    }
                }
                // we apply the modification for each custom cost.
                finalResult += usedComponent.ApplyCost(tmp);
            }

            return finalResult;
        }
    }
}
