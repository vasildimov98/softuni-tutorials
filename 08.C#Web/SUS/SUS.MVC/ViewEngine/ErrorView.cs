﻿namespace SUS.MVC.ViewEngine
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class ErrorView : IView
    {
        private readonly IEnumerable<string> errors;
        private readonly string csharpCode;

        public ErrorView(IEnumerable<string> errors, string csharpCode)
        {
            this.errors = errors;
            this.csharpCode = csharpCode;
        }

        public string GetCleanHtml(object viewModel)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<h1>You have {this.errors.Count()} errors during compilation</h1><ul>");

            foreach (var error in this.errors)
            {
                sb.AppendLine($"<li>{error}</li>");
            }

            sb.AppendLine($"</ul><pre>{this.csharpCode}</pre>");

            return sb.ToString().TrimEnd();
        }
    }
}