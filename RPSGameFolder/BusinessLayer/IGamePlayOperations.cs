using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IGPOps
    {
        List<string> AskForName_And_ReturnListofNames();
    }
}