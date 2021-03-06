/* 
Copyright (c) 2011 BinaryConstruct
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
 */

using System.Collections.ObjectModel;
using System.Linq;
using BCCL.IssueTracking.IssueTracker.Types;
using BCCL.MvvmLight;
using BCCL.Sql;

namespace BCCL.IssueTracking.IssueTracker
{
    public class IssueManager : ObservableObject
    {
        private readonly string _databaseConnection;
        private readonly ISqlService _database;
        public IssueManager(string databaseConnection, string user, string pass)
        {
            _databaseConnection = string.Format("Data Source={0}", databaseConnection);
            _database = new SqLiteService(_databaseConnection);
        }

        private readonly ObservableCollection<Issue> _issues = new ObservableCollection<Issue>();
        private readonly ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        private readonly ObservableCollection<User> _users = new ObservableCollection<User>();
         

        public ObservableCollection<User> Users
        {
            get { return _users; }
        } 

        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
        } 

        public ObservableCollection<Issue> Issues
        {
            get { return _issues; }
        }

        private void AddNewIssue(Issue issue)
        {
            int number = Issues.Where(x => x.Project == issue.Project).Max(x => x.IssueNumber) + 1;
        }
    }
}