using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritanceTask
{
    public static class IEnumerableExtensions
    {
        // yield
        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, int, bool> meth)
        {
            foreach (var item in collection.Select((value,i) => new { i, value }))
            {                
                if (meth(item.value, item.i))
                    yield return item.value;
            }
        }

    }
}
