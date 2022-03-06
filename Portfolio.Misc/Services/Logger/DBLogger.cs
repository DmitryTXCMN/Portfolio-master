using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Misc.Services.Logger
{
    public class DBLogger : IResponseLogger
    {
        public void AddLog(string email, string message, string name, string subject)
        {
            ResponseContext responseContext = new ResponseContext();
            responseContext.Responses.Add(new Response
            {
                Email = email,
                Message = message,
                Name = name,
                Subject = subject
            });
            responseContext.SaveChanges();
        }
    }
}
