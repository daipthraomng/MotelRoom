#pragma checksum "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\Home\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64efb169cd35eb582b890d882292f867a4c8541c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Detail), @"mvc.1.0.view", @"/Views/Home/Detail.cshtml")]
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
#nullable restore
#line 1 "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\_ViewImports.cshtml"
using MotelRoom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\_ViewImports.cshtml"
using MotelRoom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64efb169cd35eb582b890d882292f867a4c8541c", @"/Views/Home/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4d604988adc505340b5a6f0ff97646b364f212", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Motel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card text-center\">\r\n    <h4>");
#nullable restore
#line 4 "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\Home\Detail.cshtml"
   Write(Model.MotelID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <h4>");
#nullable restore
#line 5 "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\Home\Detail.cshtml"
   Write(Model.MotelContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <h4>");
#nullable restore
#line 6 "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\Home\Detail.cshtml"
   Write(Model.MotelLocation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <h4>");
#nullable restore
#line 7 "F:\HocTap\WEB\BTL\MotelRoom\MotelRoom\MotelRoom\Views\Home\Detail.cshtml"
   Write(Model.MotelPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Motel> Html { get; private set; }
    }
}
#pragma warning restore 1591
