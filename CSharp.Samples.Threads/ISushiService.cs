using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Samples.Threads
{
    internal interface ISushiService
    {
       Task<List<dishMenus>> GetSushiAsync();
    }
}
