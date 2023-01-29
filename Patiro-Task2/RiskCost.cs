using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task2
{
    class RiskCost : CustomCost
    {
        private RiskType level;
        public enum RiskType { LOW, MEDIUM, HIGH, NONE};

        private Dictionary<RiskType, int> costs;
        private Dictionary<string, RiskType> strToEnum;

        public RiskCost(string str, bool overrid = false)
        {
            RestConstructor(overrid);
            InputValue(str);
        }
        public RiskCost(RiskType level = RiskType.LOW, bool overrid = false)
        {
            this.level = level;
            RestConstructor(overrid);
        }

        private void RestConstructor(bool overrid)
        {
            componentName = "Risk";
            this.overrid = overrid;
            costs = new Dictionary<RiskType, int>
            {
                { RiskType.LOW, 10 },
                { RiskType.MEDIUM, 30 },
                { RiskType.HIGH, 100 },
                { RiskType.NONE, 0 }
            };

            strToEnum = new Dictionary<string, RiskType>
            {
                {"low", RiskType.LOW },
                {"medium", RiskType.MEDIUM },
                {"high", RiskType.HIGH },
                {"none", RiskType.NONE },
            };
        }

        public override double ApplyCost(double realCost)
        {
            return realCost * (costs[level] / 100);
        }

        private void InputValue(string val)
        {
            strToEnum.TryGetValue(val, out RiskType newType);
            level = newType;
        }
    }
}
