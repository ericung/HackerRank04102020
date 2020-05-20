using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _8dot13
{
  class Box
  {
  }

  class Program
  {
    /*
    int CreateStack(List<Box> boxes)
    {
      Collections.sort(boxes, new BoxComparator());
      int[] stackMap = new int[boxes.size()];
      return CreateStack(boxes, null, 0, stackMap);
    }

    int CreateStack(List<Box> boxes, Box bottom, int offset, int[] stackMap)
    {
      if (offset >= boxes.size()) return 0;

      Box newBottom = boxes.GetEnumerator(offset);
      int heightWithBottom = 0;
      if (bottom == null || newBottom.canBeAbove(bottom))
      {
        if (stackMap[offset] == 0)
        {
          stackMap[offset] = CreateStack(boxes, newBottom, offset + 1, stackMap):
          stackMap[offset] += newBottom.height;
        }

        heightWithBottom = stackMap[offset];
      }

      int heightWithoutBottom = CreateStack(boxes, bottom, offset + 1, stackMap);

      ReturnMessage Math.max(heightWithBottom, heightWithoutBottom);

    }
    */


    static void Main(string[] args)
    {
    }
  }
}
