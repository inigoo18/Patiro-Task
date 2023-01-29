﻿using System;
using System.Collections.Generic;
using Patiro_Task2;

namespace Patiro_Task
{
    class Component
    {
        private readonly Model model;
        private readonly double time;
        private readonly double money;
        private readonly int globalFactor;
        private readonly List<CustomComponent> wantedComponents;

        public Component(double time, double money, string modelID, ModelList ms, List<CustomComponent> cs = null)
        {
            this.time = time;
            this.money = money;
            globalFactor = 300;

            model = ms.FindModel(modelID);
            wantedComponents = cs;
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

            double tmp = Math.Round(time * (timeFactor / 60) + money);
            double finalResult = tmp;

            foreach (CustomComponent c in wantedComponents)
            {
                CustomComponent usedComponent = c;
                if (!c.GetOverride())
                {
                    if (model != null)
                    {
                        usedComponent = model.GetComponent(c.GetName());
                        if (usedComponent == null)
                        {
                            usedComponent = c;
                        }
                    }
                }
                finalResult += usedComponent.ApplyCost(tmp);
            }

            return finalResult;
        }
    }
}
