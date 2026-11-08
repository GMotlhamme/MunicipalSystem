using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class RedBlackNode
    {
        public Issue Issue { get; set; }

        public RedBlackNode? Left { get; set; }
        public RedBlackNode? Right { get; set; }

        // New nodes are red by default
        public bool IsRed { get; set; } = true;

        public RedBlackNode(Issue issue)
        {
            Issue = issue;
        }
    }
}
