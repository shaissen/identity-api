using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public class ConnectionStrings
    {
        public string AdminConnection { get; set; }

        public ConnectionStrings()
        {
            AdminConnection = string.Empty;
        }
    }
}
