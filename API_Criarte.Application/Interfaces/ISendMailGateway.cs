using API_Criarte.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface ISendMailGateway
    {
        ApiResponse<string> SendRecoveryMail(string email);
    }
}
