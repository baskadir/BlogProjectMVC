#pragma checksum "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4a6c5c01f319419fe94ba53bcf4d710fc85a9b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_AddTopicForUser), @"mvc.1.0.view", @"/Views/User/AddTopicForUser.cshtml")]
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
#line 3 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\_ViewImports.cshtml"
using MVCBlogProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\_ViewImports.cshtml"
using DataAccess.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4a6c5c01f319419fe94ba53bcf4d710fc85a9b0", @"/Views/User/AddTopicForUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d52d52b9d2df14bd77b969d5f962dd30282d104", @"/Views/_ViewImports.cshtml")]
    public class Views_User_AddTopicForUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
  
    ViewData["Title"] = "AddTopicForUser";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container my-5 pt-3\">\r\n    <div class=\"row text-center\">\r\n        <div class=\"d-flex flex-column col-6 offset-3\">\r\n            <h3>Devam etmeden ??nce ilgilendi??iniz konular?? se??in</h3>\r\n            <ul class=\"d-flex flex-wrap flex-row\">\r\n");
#nullable restore
#line 12 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
                 foreach (Topic item in ViewBag.Topics)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-inline-item m-3\">\r\n                        <input class=\"btn-check\" type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 518, "\"", 541, 2);
            WriteAttributeValue("", 523, "chk", 523, 3, true);
#nullable restore
#line 15 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
WriteAttributeValue("", 526, item.TopicID, 526, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"topic\"");
            BeginWriteAttribute("value", " value=\"", 555, "\"", 576, 1);
#nullable restore
#line 15 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
WriteAttributeValue("", 563, item.TopicID, 563, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" />\r\n                        <label class=\"btn btn-outline-primary\"");
            BeginWriteAttribute("for", " for=\"", 663, "\"", 687, 2);
            WriteAttributeValue("", 669, "chk", 669, 3, true);
#nullable restore
#line 16 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
WriteAttributeValue("", 672, item.TopicID, 672, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
                                                                                   Write(item.TopicName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </li>\r\n");
#nullable restore
#line 18 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\User\AddTopicForUser.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </ul>
            <button type=""button"" class=""btn btn-outline-dark"" id=""btnAddTopic"">
                <svg xmlns=""http://www.w3.org/2000/svg"" width=""25"" height=""25"" fill=""currentColor"" class=""bi bi-forward-fill"" viewBox=""1 1 16 16"">
                    <path d=""m9.77 12.11 4.012-2.953a.647.647 0 0 0 0-1.114L9.771 5.09a.644.644 0 0 0-.971.557V6.65H2v3.9h6.8v1.003c0 .505.545.808.97.557z""></path>
                </svg>
                ??leri
            </button>
        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#btnAddTopic"").click(function () {
            var array = $.map($('input[name=""topic""]:checked'), function (c) { return c.value; })
            $.ajax({
                type: ""POST"",
                url: ""/User/AddTopicForUser"",
                data: { ids: array },
                success: function (response) {
                    window.location.href = response.redirectToUrl;
                }
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
