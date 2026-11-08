using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class ServiceRequestHeap
    {
        private readonly PriorityQueue<Issue, int> priorityQueue = new();

        // Add a request according to its priority
        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            priorityQueue.Enqueue(issue, (int)issue.Priority);
        }

        // View the highest-priority request without removing it
        public Issue? Peek()
        {
            return priorityQueue.Count > 0
                ? priorityQueue.Peek()
                : null;
        }

        // Remove the highest-priority request
        public Issue? RemoveHighestPriority()
        {
            return priorityQueue.Count > 0
                ? priorityQueue.Dequeue()
                : null;
        }

        public int Count => priorityQueue.Count;
    }
}
