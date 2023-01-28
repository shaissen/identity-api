using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public class RefreshTokenElements
    {
        public Guid? RefreshId { get; set; }

        public Guid? UserId { get; set; }

        public string Token { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DateGenerated { get; set; }

        public RefreshTokenElements()
        {
            RefreshId = null;
            UserId = null;
            Token = string.Empty;
            IsActive = null;
            DateGenerated = null;

        }
    }
}
