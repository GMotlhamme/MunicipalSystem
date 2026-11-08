using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class AVLNode
    {
        public Issue Issue { get; set; }

        public AVLNode? Left { get; set; }
        public AVLNode? Right { get; set; }

        // Used to determine whether the node is balanced
        public int Height { get; set; } = 1;

        public AVLNode(Issue issue)
        {
            Issue = issue;
        }
    }
}
