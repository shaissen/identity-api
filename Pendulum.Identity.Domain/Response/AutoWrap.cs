using AutoWrapper.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Response
{
    public class AutoWrap : ApiResponse, IRequest
    {
        public AutoWrap()
        {
        }   

        public AutoWrap(string message, object? result = null, int statusCode = 200, string version = "1.0.0.0")   
            :base(message, result, statusCode, version)
        {
        }
    }
}
