#pragma checksum "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a76ea80848f4528f9a9b48acf51612fb534e221"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Shared__SizeIndexPartial), @"mvc.1.0.view", @"/Areas/Manage/Views/Shared/_SizeIndexPartial.cshtml")]
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
#line 2 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\_ViewImports.cshtml"
using Juan_Back_End_Final.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a76ea80848f4528f9a9b48acf51612fb534e221", @"/Areas/Manage/Views/Shared/_SizeIndexPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22ac223d4789fa05c23bea1e80b99fecdd7b787e", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Shared__SizeIndexPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Size>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning w-25"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
   int count = (ViewBag.PageIndex - 1) * 5; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table class=""table table-striped text-center"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Status</th>
            <th scope=""col"">Setting</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 15 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
         foreach (Size size in Model)
        {
            count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <th scope=\"row\">");
#nullable restore
#line 19 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                           Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                <td>");
#nullable restore
#line 20 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
               Write(size.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td");
            BeginWriteAttribute("style", " style=\"", 524, "\"", 571, 2);
            WriteAttributeValue("", 532, "color:", 532, 6, true);
#nullable restore
#line 21 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
WriteAttributeValue("", 538, size.IsDeleted ? "red":"green", 538, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                Write(size.IsDeleted ? "DeActive":"Active");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a76ea80848f4528f9a9b48acf51612fb534e2215987", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                          WriteLiteral(size.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a76ea80848f4528f9a9b48acf51612fb534e2218298", async() => {
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                                                                                                                                                                                                                                                  Write(size.IsDeleted ? "Restore":"Delete");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
AddHtmlAttributeValue("", 773, size.IsDeleted ? "restoreCategory":"deleteCategory", 773, 54, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 836, "btn", 836, 3, true);
            AddHtmlAttributeValue(" ", 839, "w-25", 840, 5, true);
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
AddHtmlAttributeValue(" ", 844, size.IsDeleted ? "btn-primary":"btn-danger", 845, 46, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-status", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                                                                                                         WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                                                                                                                                          WriteLiteral(ViewBag.PageIndex);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                                                                                                                                                                           WriteLiteral(size.IsDeleted ? "Restore":"Delete");

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
                                                                                                                                                                                                                                                                                WriteLiteral(size.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </td>\n            </tr>            \n");
#nullable restore
#line 27 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Areas\Manage\Views\Shared\_SizeIndexPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Size>> Html { get; private set; }
    }
}
#pragma warning restore 1591