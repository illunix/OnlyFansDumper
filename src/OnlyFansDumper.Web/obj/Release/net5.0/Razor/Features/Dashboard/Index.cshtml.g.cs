#pragma checksum "C:\Users\cros4\Desktop\OnlyFansDumper\OnlyFansDumper.Web\Features\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25594217d841f813f7a3e29a644adc78f2f03e3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Features_Dashboard_Index), @"mvc.1.0.view", @"/Features/Dashboard/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25594217d841f813f7a3e29a644adc78f2f03e3f", @"/Features/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d20fee4114922cdc0c203f070ba5ef3e8d70f2e", @"/Features/_ViewImports.cshtml")]
    public class Features_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlyFansDumper.Web.Features.Dashboard.Index.Model>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\cros4\Desktop\OnlyFansDumper\OnlyFansDumper.Web\Features\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\" style=\"margin-top: 10px\">\r\n    <div class=\"col-lg-3 col-6\">\r\n        <div class=\"small-box bg-info\">\r\n            <div class=\"inner\">\r\n                <h3>");
#nullable restore
#line 10 "C:\Users\cros4\Desktop\OnlyFansDumper\OnlyFansDumper.Web\Features\Dashboard\Index.cshtml"
               Write(Model.TodayMiners);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                <p>Today Miners</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-3 col-6\">\r\n        <div class=\"small-box bg-green\">\r\n            <div class=\"inner\">\r\n                <h3>");
#nullable restore
#line 19 "C:\Users\cros4\Desktop\OnlyFansDumper\OnlyFansDumper.Web\Features\Dashboard\Index.cshtml"
               Write(Model.TotalMiners);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                <p>Total Miners</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlyFansDumper.Web.Features.Dashboard.Index.Model> Html { get; private set; }
    }
}
#pragma warning restore 1591