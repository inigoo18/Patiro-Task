using Patiro_Task2;
using System;
using System.Collections.Generic;

namespace Patiro_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthArgs = args.Length;
            Dictionary<string, CustomComponent> overrideDict = new Dictionary<string, CustomComponent>();

            for (int i = 3; i < lengthArgs; i++)
            {
                string[] words = args[i].Split(':');
                CustomComponent newComp = ParseComponent(words[0], words[1]);
                overrideDict.Add(words[0], newComp);
            }

            RiskComponent rc = new RiskComponent(RiskComponent.RiskType.HIGH);
            InconvenienceComponent ic = new InconvenienceComponent(InconvenienceComponent.InconvenienceType.MEDIUM);
            List<CustomComponent> cs = new List<CustomComponent>
            {
                rc,
                ic
            };

            Model m1 = new Model("model1234", 500, cs);
            Model m2 = new Model("model5678", 200);
            ModelList ms = new ModelList();
            ms.AddModel(m1);
            ms.AddModel(m2);

            CustomComponent wrc;
            if (!overrideDict.TryGetValue("Risk", out wrc))
            {
                wrc = new RiskComponent();
            }

            CustomComponent wic;
            if (!overrideDict.TryGetValue("Inconvenience", out wic))
            {
                wic = new InconvenienceComponent();
            }

            List<CustomComponent> wcs = new List<CustomComponent>
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

        static CustomComponent ParseComponent(string name, string val)
        {
            if (name == "Risk")
            {
                RiskComponent rc = new RiskComponent(val, true);
                return rc;
            }
            else if (name == "Inconvenience")
            {
                InconvenienceComponent ic = new InconvenienceComponent(val, true);
                return ic;
            }
            else
            {
                return null;

            }
        }
    }
}
