using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.Services
{
    public class IssueService
    {

        //custom methods to carry out specific actions
        private readonly List<Issue> reportedIssues = new List<Issue>();

        public void AddIssue(Issue issue)
        {
            reportedIssues.Add(issue);
        }

        public List<Issue> GetAllIssues()
        {
            return reportedIssues;
        }
    }
}
