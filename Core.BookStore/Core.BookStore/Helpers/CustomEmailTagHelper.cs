using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Core.BookStore.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string MyEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Attributes.Add("Id", "myemail");
            output.Content.SetContent("Email");
        }
    }
}
