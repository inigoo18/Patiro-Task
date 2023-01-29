using System;

namespace Patiro_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Model m1 = new Model("model1234", 500);
            Model m2 = new Model("model5678", 200);
            ModelList ms = new ModelList();
            ms.AddModel(m1);
            ms.AddModel(m2);
            Component comp = new Component(StrToDouble(args[0]), StrToDouble(args[1]), args[2], ms);
            Console.WriteLine(comp.ComputeCost());

        }

        static double StrToDouble(string str)
        {
            return Convert.ToDouble(str);
        }
    }
}
