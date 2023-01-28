using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public AuditableEntity()
        {
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;
        }
    }
}
