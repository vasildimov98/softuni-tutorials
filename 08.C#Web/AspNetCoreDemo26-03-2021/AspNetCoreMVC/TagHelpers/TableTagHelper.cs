namespace AspNetCoreMVC.TagHelpers
{
    using System;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("table", Attributes = "bootstrap-table")]
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add(new TagHelperAttribute("class", "table table-bordered table-striped text-center"));
        }
    }
}
