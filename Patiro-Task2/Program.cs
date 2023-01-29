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

            for (int i = 3; i < lengthArgs; i++)
            {
                string[] words = args[i].Split(':');
                CustomCost newComp = ParseComponent(words[0], words[1]);
                overrideDict.Add(words[0], newComp);
            }

            RiskCost rc = new RiskCost(RiskCost.RiskType.HIGH);
            InconvenienceCost ic = new InconvenienceCost(InconvenienceCost.InconvenienceType.MEDIUM);
            List<CustomCost> cs = new List<CustomCost>
            {
                rc,
                ic
            };

            Model m1 = new Model("model1234", 500, cs);
            Model m2 = new Model("model5678", 200);
            ModelList ms = new ModelList();
            ms.AddModel(m1);
            ms.AddModel(m2);

            CustomCost wrc;
            if (!overrideDict.TryGetValue("Risk", out wrc))
            {
                wrc = new RiskCost();
            }

            CustomCost wic;
            if (!overrideDict.TryGetValue("Inconvenience", out wic))
            {
                wic = new InconvenienceCost();
            }

            List<CustomCost> wcs = new List<CustomCost>
            {
                wrc,
                wic
            };

            Component comp = new Component(StrToDouble(args[0]), StrToDouble(args[1]), args[2], ms, wcs);
            Console.WriteLine(comp.ComputeCost());

        }

        static double StrToDouble(string str)
        {
            return Convert.ToDouble(str);
        }

        static CustomCost ParseComponent(string name, string val)
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
