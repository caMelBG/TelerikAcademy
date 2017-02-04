namespace BuhtigIssueTracker.Logic
{
    using System;
    using Interfaces;
    using Models;

    public class CommandExecutor
    {
        public CommandExecutor(IIssueTracker tracker)
        {
            this.IssueTracker = tracker;
        }

        public CommandExecutor()
            : this(new IssueTracker())
        {
        }

        private IIssueTracker IssueTracker { get; set; }

        private ICommand Command { get; set; }

        public string DispatchAction(ICommand Command)
        {
            this.Command = Command;
            switch (this.Command.Name)
            {
                case "RegisterUser":
                    return this.RegisterUser();
                case "LoginUser":
                    return this.LoginUser();
                case "CreateIssue":
                    return this.CreateIssue();
                case "RemoveIssue":
                    return this.RemoveIssue();
                case "AddComment":
                    return this.AddComment();
                case "Search":
                    return this.Search();
                case "LogoutUser":
                    return this.IssueTracker.LogoutUser();
                case "MyIssues":
                    return this.IssueTracker.GetMyIssues();
                case "MyComments":
                    return this.IssueTracker.GetMyComments();
                default:
                    return string.Format("Invalid action: {0}", Command.Name);
            }
        }

        private string RegisterUser()
        {
            var username = this.Command.Parameters["username"];
            var password = this.Command.Parameters["password"];
            var confirmPassword = this.Command.Parameters["confirmPassword"];
            return this.IssueTracker.RegisterUser(username, password, confirmPassword);
        }

        private string LoginUser()
        {
            var username = this.Command.Parameters["username"];
            var password = this.Command.Parameters["password"];
            return this.IssueTracker.LoginUser(username, password);
        }

        private string CreateIssue()
        {
            var title = this.Command.Parameters["title"];
            var description = this.Command.Parameters["description"];
            var priority = this.Command.Parameters["priority"];
            var tags = this.Command.Parameters["tags"].Split('|');
            var priorityAsString = (IssuePriority)Enum.Parse(typeof(IssuePriority), priority, true);
            return this.IssueTracker.CreateIssue(title, description, priorityAsString, tags);
        }

        private string RemoveIssue()
        {
            var issueId = int.Parse(this.Command.Parameters["id"]);
            return this.IssueTracker.RemoveIssue(issueId);
        }

        private string AddComment()
        {
            var issueId = int.Parse(this.Command.Parameters["id"]);
            var text = this.Command.Parameters["text"];
            return this.IssueTracker.AddComment(issueId, text);
        }

        private string Search()
        {
            var tags = this.Command.Parameters["tags"].Split('|');
            return this.IssueTracker.SearchForIssues(tags);
        }
    }
}