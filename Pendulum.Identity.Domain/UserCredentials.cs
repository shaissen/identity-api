using Pendulum.Identity.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain
{
    public class UserCredentials : AuditableEntity
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }

        public string Firstname { get; set; }

        public string? Middlename { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public DateTime? Birthday { get; set; }

        public string Gender { get; set; }

        public string ProfilePhoto { get; set; }

        public UserCredentials()
        {
            Username = string.Empty;
            Password = string.Empty;
            EmailAddress = null;
            ContactNumber = string.Empty;
            Firstname = string.Empty;
            Middlename = string.Empty;
            Lastname = string.Empty;
            Address = string.Empty;
            Birthday = null;
            Gender = string.Empty;
            ProfilePhoto = string.Empty;
        }
    }
}
