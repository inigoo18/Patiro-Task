using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patiro_Task
{
    namespace Part_1
    {
        class ModelList
        {
            private readonly List<Model> modelList;

            public ModelList()
            {
                modelList = new List<Model>();
            }

            public void AddModel(Model model)
            {
                modelList.Add(model);
            }

            public void DelModel(Model model)
            {
                modelList.Remove(model);
            } 

            public Model FindModel(string modelLabel)
            {
                foreach (Model m in modelList)
                {
                    if (m.GetLabel() == modelLabel)
                    {
                        return m;
                    }
                }
                return null;
            }

        }
    }
}
