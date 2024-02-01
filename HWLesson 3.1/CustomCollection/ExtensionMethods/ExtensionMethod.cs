using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace  ExtensionMethods
{
    public static class ExtensionMethod
    {
      public static void SetDefaultAt(this Collections.CustomCollection<int> collection, int index)
        {    
            collection.SetValue(index, 0);
        }

    public static void SetDefaultAt(this Collections.CustomCollection<double> collection, int index)
        {
            collection.SetValue(index, 0);
        }
    public static void SetDefaultAt(this Collections.CustomCollection<decimal> collection, int index)
        {
            collection.SetValue(index, 0);
        }
    public static void SetDefaultAt(this Collections.CustomCollection<float> collection, int index)
        {
            collection.SetValue(index, 0);
        }

    }
}
