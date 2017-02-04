namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using Interfaces;

    public class IssueTrackerData : IIssueTrackerData
    {
        public IssueTrackerData()
        {
            this.NextIssueId = 1;
            this.UserByUsername = new Dictionary<string, User>();
            this.UserByComment = new Dictionary<Comment, User>();
            this.IssueById = new OrderedDictionary<int, Issue>();
            this.IssueByUsername = new MultiDictionary<string, Issue>(true);
            this.IssueByTag = new MultiDictionary<string, Issue>(true);
            this.CommnetByUser = new MultiDictionary<User, Comment>(true);
        }

        public int NextIssueId { get; set; }
        
        public User CurrentLoggedUser { get; set; }

        public IDictionary<string, User> UserByUsername { get; set; }

        public IDictionary<Comment, User> UserByComment { get; set; }

        public OrderedDictionary<int, Issue> IssueById { get; set; }

        public MultiDictionary<string, Issue> IssueByUsername { get; set; }

        public MultiDictionary<string, Issue> IssueByTag { get; set; }

        public MultiDictionary<User, Comment> CommnetByUser { get; set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.NextIssueId;
            this.IssueById.Add(issue.Id, issue);
            this.NextIssueId++;
            this.IssueByUsername[this.CurrentLoggedUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssueByTag[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssueByUsername[this.CurrentLoggedUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssueByTag[tag].Remove(issue);
            }

            this.IssueById.Remove(issue.Id);
        }
    }
}