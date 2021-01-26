using MPS.Database;
using MPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Services
{
    public class ConfigurationService
    {
        public Config GetConfig(string Key)
        {
            using (var context =new MPSContext())
            {
                return context.Configurations.Find(Key);
            }

        }

    }
}
