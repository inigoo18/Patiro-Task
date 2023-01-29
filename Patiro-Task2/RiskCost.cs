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
        
        // enum specifying the different value types.
        public enum RiskType { LOW, MEDIUM, HIGH, NONE};

        // this dictionary maps each value in the enum to an integer to assign a cost.
        private Dictionary<RiskType, int> costs;
        // this dictionary maps a string to each enum value so we can interpret the user's parameters.
        private Dictionary<string, RiskType> strToEnum;

        public RiskCost(string str, bool overrid = false)
        {
            RestConstructor(overrid);
            InputValue(str);
        }

        // with this constructor we can set the global factor of the custom cost.
        public RiskCost(RiskType level = RiskType.LOW, bool overrid = false)
        {
            this.level = level;
            RestConstructor(overrid);
        }

        // initializes the dictionaries.
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

        // applies a certain cost to the original cost that was calculated in part 1.
        public override double ApplyCost(double realCost)
        {
            return realCost * (costs[level] / 100);
        }

        // we modify the value of the object when the user specifies a certain value through the command line.
        private void InputValue(string val)
        {
            strToEnum.TryGetValue(val, out RiskType newType);
            level = newType;
        }
    }
}
