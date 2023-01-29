using Patiro_Task2;
using System;
using System.Collections.Generic;

namespace Patiro_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthArgs = args.Length;
            Dictionary<string, CustomCost> overrideDict = new Dictionary<string, CustomCost>();

            // for each argument after the first 3, we parse them in order to modify the values of the custom costs.
            for (int i = 3; i < lengthArgs; i++)
            {
                string[] words = args[i].Split(':');
                CustomCost newComp = ParseComponent(words[0], words[1].ToLower());
                // in overrideDict, we can find the custom costs that the user has specified through the command line.
                overrideDict.Add(words[0], newComp);
            }

            // custom costs for model1234
            RiskCost rc = new RiskCost(RiskCost.RiskType.HIGH);
            InconvenienceCost ic = new InconvenienceCost(InconvenienceCost.InconvenienceType.MEDIUM);
            List<CustomCost> cs = new List<CustomCost>
            {
                rc,
                ic
            };

            Model m1 = new Model("model1234", 500, cs);
            Model m2 = new Model("model5678", 200);

            // we create a ModelList object for the Component class to find the necessary model.
            ModelList ms = new ModelList();
            ms.AddModel(m1);
            ms.AddModel(m2);

            // if Risk was not specified by the user, then we need to obtain the global setting for it by initializing the empty constructor.
            if (!overrideDict.TryGetValue("Risk", out CustomCost wrc))
            {
                wrc = new RiskCost();
            }

            if (!overrideDict.TryGetValue("Inconvenience", out CustomCost wic))
            {
                wic = new InconvenienceCost();
            }

            List<CustomCost> wcs = new List<CustomCost>
            {
                wrc,
                wic
            };

            // we create the custom costs list and pass it to the Component constructor. These costs will be taken into account 
            // when calculating the total cost.
            Component comp = new Component(StrToDouble(args[0]), StrToDouble(args[1]), args[2], ms, wcs);
            Console.WriteLine(comp.ComputeCost());

        }

        static double StrToDouble(string str)
        {
            return Convert.ToDouble(str);
        }

        // this function receives user input such as "Risk:high" and assigns the value to the custom cost object.
        static CustomCost ParseComponent(string name, string val)
        {
            return CustomCost.CostParser(name, val);
        }
    }
}
