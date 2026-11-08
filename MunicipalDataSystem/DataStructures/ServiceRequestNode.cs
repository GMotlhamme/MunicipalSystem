using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class ServiceRequestNode
    {
        public Issue Issue { get; set; }

        public ServiceRequestNode? Left { get; set; }
        public ServiceRequestNode? Right { get; set; }

        public ServiceRequestNode(Issue issue)
        {
            Issue = issue;
        }
    }
}
