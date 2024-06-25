using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class AwsVariablesDTO
    {
        public string bucketName { get; set; }
        public string AwsKeyID { get; set; }
        public string AwsKeySecret { get; set; }
    }
}
