namespace BuhtigIssueTracker.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IIssueTrackerData dataBase)
        {
            this.DataBase = dataBase as IssueTrackerData;
        }

        public IssueTracker()
            : this(new IssueTrackerData())
        {
        }

        public IssueTrackerData DataBase { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.DataBase.CurrentLoggedUser != null)
            {
                return string.Format("There is already a logged in user");
            }
            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }
            else if (this.DataBase.UserByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.DataBase.UserByUsername.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.DataBase.CurrentLoggedUser != null)
            {
                return string.Format("There is already a logged in user");
            }
            else if (!this.DataBase.UserByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.DataBase.UserByUsername[username];
            if (user.Password != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.DataBase.CurrentLoggedUser = user;
            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.DataBase.CurrentLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            string username = this.DataBase.CurrentLoggedUser.Username;
            this.DataBase.CurrentLoggedUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] arguments)
        {
            if (this.DataBase.CurrentLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(title, description, priority, arguments.Distinct().ToList());
            issue.Id = this.DataBase.NextIssueId;
            this.DataBase.IssueById.Add(issue.Id, issue);
            this.DataBase.NextIssueId++;
            this.DataBase.IssueByUsername[this.DataBase.CurrentLoggedUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.DataBase.IssueByTag[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.DataBase.CurrentLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }
            else if (!this.DataBase.IssueById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.DataBase.IssueById[issueId];
            if (!this.DataBase.IssueByUsername[this.DataBase.CurrentLoggedUser.Username].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}", issueId, this.DataBase.CurrentLoggedUser.Username);
            }

            this.DataBase.IssueByUsername[this.DataBase.CurrentLoggedUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.DataBase.IssueByTag[tag].Remove(issue);
            }

            this.DataBase.IssueById.Remove(issue.Id);
            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int intValue, string stringValue)
        {
            if (this.DataBase.CurrentLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }
            else if (!this.DataBase.IssueById.ContainsKey(intValue))
            {
                return string.Format("There is no issue with ID {0}", intValue);
            }

            var issue = this.DataBase.IssueById[intValue];
            var comment = new Comment(this.DataBase.CurrentLoggedUser, stringValue);
            issue.AddComment(comment);
            this.DataBase.CommnetByUser[this.DataBase.CurrentLoggedUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.DataBase.CurrentLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issues = this.DataBase.IssueByUsername[this.DataBase.CurrentLoggedUser.Username];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                var result = string.Empty;
                foreach (var i in this.DataBase.IssueByUsername)
                {
                    result += i.Value
                        .Select(x => x.Comments.Select(c => c.Text))
                        .ToString();
                }

                return "No issues";
            }

            return string.Join(Environment.NewLine, newIssues
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (this.DataBase.CurrentLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var comments = new List<Comment>();

            this.DataBase.IssueById
                .Select(i => i.Value.Comments)
                .ToList()
                .ForEach(item => comments.AddRange(item));

            var resultComments = comments
                .Where(c => c.Author.Username == this.DataBase.CurrentLoggedUser.Username)
                .ToList();

            var strings = resultComments.Select(x => x.ToString());
            if (!strings.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, strings);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return "There are no tags provided";
            }

            var isuues = new List<Issue>();
            foreach (var tag in tags)
            {
                isuues.AddRange(this.DataBase.IssueByTag[tag]);
            }

            if (!isuues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var uniqueIssues = isuues.Distinct();
            if (!uniqueIssues.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, uniqueIssues
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.Title)
                .Select(x => x.ToString()));
        }
    }
}
