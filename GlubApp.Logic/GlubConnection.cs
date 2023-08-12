using GlubApp.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Logic
{
    public class GlubConnection
    {
        public GlubContext Context { get; set; }

        public GlubConnection(IConfiguration configuration)
        {
            Context = new GlubContext(configuration);
        }
    }
}
