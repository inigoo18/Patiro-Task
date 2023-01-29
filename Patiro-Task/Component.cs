using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task
{
    class Component
    {
        private readonly Model model;
        private readonly double time;
        private readonly double money;
        private readonly int globalFactor;

        public Component(double time, double money, string modelID, ModelList ms)
        {
            this.time = time;
            this.money = money;
            globalFactor = 300;

            model = ms.FindModel(modelID);
        }

        public double ComputeCost()
        {
            int timeFactor;
            if (model == null)
            {
                timeFactor = globalFactor;
            }
            else
            {
                timeFactor = model.GetTimeFactor();
            }
            return Math.Round(time * (timeFactor / 60) + money);
        }
    }
}
