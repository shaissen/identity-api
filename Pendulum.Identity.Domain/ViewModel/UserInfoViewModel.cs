using Pendulum.Identity.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.ViewModel
{
    public class UserInfoViewModel : AuditableEntity
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string? Middlename { get; set; }

        public string Lastname { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string ProfilePhoto { get; set; }

        public UserInfoViewModel()
        {
            Firstname = string.Empty;
            Middlename= string.Empty;
            Lastname= string.Empty;
            ContactNumber = string.Empty;
            EmailAddress = string.Empty;
            Address = string.Empty;
            Gender = string.Empty;
            ProfilePhoto = string.Empty;
        }



    }
}
