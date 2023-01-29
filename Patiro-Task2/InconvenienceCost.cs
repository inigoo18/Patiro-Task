using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task2
{
    class InconvenienceCost : CustomCost
    {
        private InconvenienceType level;
        public enum InconvenienceType { LOW, MEDIUM, HIGH, NONE };

        private Dictionary<InconvenienceType, int> costs;
        private Dictionary<string, InconvenienceType> strToEnum;

        public InconvenienceCost(string str, bool overrid = false)
        {
            RestConstructor(overrid);
            InputValue(str);
        }
        public InconvenienceCost(InconvenienceType level = InconvenienceType.LOW, bool overrid = false)
        {
            this.level = level;
            RestConstructor(overrid);
        }

        private void RestConstructor(bool overrid)
        {
            componentName = "Inconvenience";
            this.overrid = overrid;
            costs = new Dictionary<InconvenienceType, int>
            {
                { InconvenienceType.LOW, 10 },
                { InconvenienceType.MEDIUM, 30 },
                { InconvenienceType.HIGH, 100 },
                { InconvenienceType.NONE, 0 }
            };

            strToEnum = new Dictionary<string, InconvenienceType>
            {
                {"low", InconvenienceType.LOW },
                {"medium", InconvenienceType.MEDIUM },
                {"high", InconvenienceType.HIGH },
                {"none", InconvenienceType.NONE },
            };
        }

        public override double ApplyCost(double realCost)
        {
            return realCost * (costs[level] / 100);
        }

        private void InputValue(string val)
        {
            strToEnum.TryGetValue(val, out InconvenienceType newType);
            level = newType;
        }
    }
}
