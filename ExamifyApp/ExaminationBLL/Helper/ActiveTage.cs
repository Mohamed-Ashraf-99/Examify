using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ExaminationBLL.Helper
{
    [HtmlTargetElement("a", Attributes = "active-when")]
    public class ActiveTage : TagHelper
    {
        public string? ActiveWhen { get; set; }
        [ViewContext]
        [HtmlAttributeNotBound] 
        public ViewContext? ViewContextData { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(ActiveWhen))
                return;
            var currentController = ViewContextData?.RouteData.Values["controller"]?.ToString();
            if (currentController!.Equals(ActiveWhen))
            {
                if (output.Attributes.ContainsName("class"))
                {
                    output.Attributes.SetAttribute("class", $"{output.Attributes["class"].Value} active1");
                }
                else 
                {
                    output.Attributes.SetAttribute("class", $"active1");
                }
            }
        }
    }
}
