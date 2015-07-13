using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support
{
  public static class GenericExtensions
  {
    public static bool IsEqualTo(this string[] a, string[] b)
    {
      if (a.Length != b.Length)
        return false;
      for (int i = 0; i < a.Length; i++)
        if (a[i] != b[i])
          return false;

      return true;
    }
  }
}
