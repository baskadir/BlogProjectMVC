#pragma checksum "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8676e203516f85a448834e01376202707b2e1a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article_AddArticle), @"mvc.1.0.view", @"/Views/Article/AddArticle.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8676e203516f85a448834e01376202707b2e1a1", @"/Views/Article/AddArticle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d52d52b9d2df14bd77b969d5f962dd30282d104", @"/Views/_ViewImports.cshtml")]
    public class Views_Article_AddArticle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Article>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
  
    ViewData["Title"] = "AddArticle";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container mt-5"">
    <div class=""row"">
        <div class=""col-12 my-5"">
            <h3 class=""text-center"">Makale Ekleme Sayfası</h3>
            <div class=""my-3"">
                <label class=""fw-bold"">Başlık</label>
                <input id=""title"" type=""text"" class=""form-control"">
            </div>
            <div class=""mb-3"">
                <label class=""fw-bold"">İçerik</label>
                <textarea class=""form-control"" id=""content"" rows=""5""></textarea>
            </div>
            <div class=""my-3 p-0"">
                <label class=""fw-bold"">Konular</label>
                <ul class=""d-flex flex-wrap flex-row"">
");
#nullable restore
#line 22 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
                     foreach (Topic item in ViewBag.Topics)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-inline-item m-3\">\r\n                            <input class=\"form-check-input\" type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 949, "\"", 972, 2);
            WriteAttributeValue("", 954, "chk", 954, 3, true);
#nullable restore
#line 25 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
WriteAttributeValue("", 957, item.TopicID, 957, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" name=\"topic\"");
            BeginWriteAttribute("value", " value=\"", 1005, "\"", 1026, 1);
#nullable restore
#line 25 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
WriteAttributeValue("", 1013, item.TopicID, 1013, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 1091, "\"", 1115, 2);
            WriteAttributeValue("", 1097, "chk", 1097, 3, true);
#nullable restore
#line 26 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
WriteAttributeValue("", 1100, item.TopicID, 1100, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
                                                                                Write(item.TopicName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        </li>\r\n");
#nullable restore
#line 28 "C:\Users\kadir\Desktop\MVCBlogProject\MVCBlogProject\Views\Article\AddArticle.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n            <button class=\"btn btn-outline-success\" id=\"btnAddArticle\">Yeni Makale Oluştur</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#btnAddArticle"").click(function () {
            var array = $.map($('input[name=""topic""]:checked'), function (c) { return c.value; })
            var articleData = new Object();
            articleData.title = $(""#title"").val();
            articleData.content = $(""#content"").val();
            $.ajax({
                type: ""POST"",
                url: ""/Article/AddArticle"",
                data: { ids: array, newArticle: articleData },
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Article> Html { get; private set; }
    }
}
#pragma warning restore 1591