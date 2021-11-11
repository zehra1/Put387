using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387
{
    public class SetupService
    {
        public static void Init(Database.Put387DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
