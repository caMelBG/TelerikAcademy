namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using Models;

    public interface IIssueTrackerData
    {
        User CurrentLoggedUser { get; set; }

        IDictionary<string, User> UserByUsername { get; }

        OrderedDictionary<int, Issue> IssueById { get; }

        MultiDictionary<string, Issue> IssueByUsername { get; }

        MultiDictionary<string, Issue> IssueByTag { get; }

        MultiDictionary<User, Comment> CommnetByUser { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}
