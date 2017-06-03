using LPA2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPA2.Infra
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            //system.net.mail -> enviar email
        }
    }
}
