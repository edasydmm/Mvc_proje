using ItServiesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Services
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}
