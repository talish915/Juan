#pragma checksum "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8307cac7d2679b7439749fa4ec743ef1fbe57373"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
#line 2 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\_ViewImports.cshtml"
using Juan_Back_End_Final.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\_ViewImports.cshtml"
using Juan_Back_End_Final.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\_ViewImports.cshtml"
using Juan_Back_End_Final.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\_ViewImports.cshtml"
using Juan_Back_End_Final.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\_ViewImports.cshtml"
using Juan_Back_End_Final.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8307cac7d2679b7439749fa4ec743ef1fbe57373", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5c25bb8bd7f57d987b8bac5de609f5f9d41e937", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MemberProfileVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    int orderCount = 0;
    int orderItemCount = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--====== Breadcrumb Part Start ======-->

<div class=""breadcrumb-area"">
    <div class=""container-fluid custom-container"">
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
                <li class=""breadcrumb-item active"">My Account</li>
            </ol>
        </nav>
    </div> <!-- container -->
</div>

<!--====== Breadcrumb Part Ends ======-->
<!--====== My Account Part Start ======-->

<section class=""my-account-area pt-10"">
    <div class=""container-fluid custom-container"">
        <div class=""row"">
            <div class=""col-xl-3 col-md-4"">
                <div class=""my-account-menu mt-30"">
                    <ul class=""nav account-menu-list flex-column nav-pills"" id=""pills-tab"" role=""tablist"">
                        <li>
                            <a id=""pills-order-tab"" data-toggle=""pill"" href=""#pills-order"" role=""tab"" aria-controls=""pills-order"" aria-selected=""fal");
            WriteLiteral("se\"><i class=\"far fa-shopping-cart\"></i> Order</a>\r\n                        </li>\r\n                        <li>\r\n                            <a id=\"pills-account-tab\" data-toggle=\"pill\" href=\"#pills-account\" role=\"tab\" aria-controls=\"pills-account\"");
            BeginWriteAttribute("aria-selected", " aria-selected=\"", 1395, "\"", 1511, 1);
#nullable restore
#line 35 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
WriteAttributeValue("", 1411, (TempData["ProfileTab"] != null && TempData["ProfileTab"].ToString() == "Account"?"true":"false"), 1411, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1512, "\"", 1617, 1);
#nullable restore
#line 35 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
WriteAttributeValue("", 1520, (TempData["ProfileTab"] != null && TempData["ProfileTab"].ToString() == "Account"?"active":""), 1520, 97, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"far fa-user\"></i> Account Details</a>\r\n                        </li>\r\n                        <li>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8307cac7d2679b7439749fa4ec743ef1fbe573737329", async() => {
                WriteLiteral("<i class=\"far fa-sign-out-alt\"></i> Logout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </li>
                    </ul>
                </div>
            </div>
            <div class=""col-xl-8 col-md-8"">
                <div class=""tab-content my-account-tab mt-30"" id=""pills-tabContent"">
                    <div class=""tab-pane fade"" id=""pills-order"" role=""tabpanel"" aria-labelledby=""pills-order-tab"">
                        <div class=""my-account-order account-wrapper"">
                            <h4 class=""account-title"">Orders</h4>
                            <div class=""account-table text-center mt-30 table-responsive"">
                                <table class=""table table-condensed table-striped"">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>FullName</th>
                                            <th>Product Count</th>
                                            <th>Total Price</th>
             ");
            WriteLiteral("                               <th>Date</th>\r\n                                            <th>Status</th>\r\n                                        </tr>\r\n                                    </thead>\r\n\r\n                                    <tbody>\r\n");
#nullable restore
#line 62 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                         foreach (var item in Model.Orders)
                                        {
                                            orderCount++;
                                            orderItemCount = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr data-toggle=\"collapse\" data-target=\"#demo");
#nullable restore
#line 66 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                                 Write(orderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"accordion-toggle\">\r\n                                            <td>");
#nullable restore
#line 67 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                           Write(orderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 68 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                           Write(item.AppUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 69 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                           Write(item.OrderItems.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 70 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                           Write(item.OrderItems.Sum(o=>o.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 71 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                           Write(item.CreatedAt?.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 72 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                           Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                            <tr>
                                                <td colspan=""12"" class=""hiddenRow"">
                                                    <div class=""accordian-body collapse""");
            BeginWriteAttribute("id", " id=\"", 4216, "\"", 4238, 2);
            WriteAttributeValue("", 4221, "demo", 4221, 4, true);
#nullable restore
#line 76 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
WriteAttributeValue("", 4225, orderCount, 4225, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                        <table class=""table table-striped"">
                                                            <thead>
                                                                <tr class=""info"">
                                                                    <th>#</th>
                                                                    <th>Product Name</th>
                                                                    <th>Product Count</th>
                                                                    <th>Total Price</th>
                                                                    <th>Price</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
");
#nullable restore
#line 88 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                 foreach (var orderItem in item.OrderItems)
                                                                {
                                                                    orderItemCount++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <tr data-toggle=\"collapse\" class=\"accordion-toggle\">\r\n                                                                    <td>");
#nullable restore
#line 92 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                   Write(orderItemCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 93 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                   Write(orderItem.Product.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 94 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                   Write(orderItem.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 95 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                   Write(orderItem.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 96 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                   Write(orderItem.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                </tr>\r\n");
#nullable restore
#line 98 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
");
#nullable restore
#line 104 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div");
            BeginWriteAttribute("class", " class=\"", 6693, "\"", 6817, 3);
            WriteAttributeValue("", 6701, "tab-pane", 6701, 8, true);
            WriteAttributeValue(" ", 6709, "fade", 6710, 5, true);
#nullable restore
#line 110 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
WriteAttributeValue(" ", 6714, (TempData["ProfileTab"] != null && TempData["ProfileTab"].ToString() == "Account"?"active show":""), 6715, 102, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""pills-account"" role=""tabpanel"" aria-labelledby=""pills-account-tab"">
                        <div class=""my-account-details account-wrapper"">
                            <h4 class=""account-title"">Account Details</h4>

                            <div class=""account-details"">
                                ");
#nullable restore
#line 115 "C:\Users\LENOVO\Desktop\Juan Final\Juan Back-End Final\Views\Account\Profile.cshtml"
                           Write(await Html.PartialAsync("_ProfileFormPartial", Model.Member));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<!--====== My Account Part Ends ======-->
<!--====== Brand Part Start ======-->

<div class=""brand-area pt-80"">
    <div class=""container-fluid custom-container"">
        <div class=""row brand-active"">
            <div class=""col-lg-2"">
                <div class=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-1.jpg"" alt=""brand"">
                    </a>
                </div> <!-- single brand -->
            </div>
            <div class=""col-lg-2"">
                <div class=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-2.jpg"" alt=""brand"">
                    </a>
                </div> <!-- single brand -->
            </div>
            <div class=""col-lg-2"">
                <div c");
            WriteLiteral(@"lass=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-3.jpg"" alt=""brand"">
                    </a>
                </div> <!-- single brand -->
            </div>
            <div class=""col-lg-2"">
                <div class=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-4.jpg"" alt=""brand"">
                    </a>
                </div> <!-- single brand -->
            </div>
            <div class=""col-lg-2"">
                <div class=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-5.jpg"" alt=""brand"">
                    </a>
                </div> <!-- single brand -->
            </div>
            <div class=""col-lg-2"">
                <div class=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-6.jpg"" alt=""brand"">
                    </a>
");
            WriteLiteral(@"                </div> <!-- single brand -->
            </div>
            <div class=""col-lg-2"">
                <div class=""single-brand"">
                    <a href=""#"">
                        <img src=""assets/images/brand/brand-4.jpg"" alt=""brand"">
                    </a>
                </div> <!-- single brand -->
            </div>
        </div> <!-- row -->
    </div> <!-- container -->
</div>

<!--====== Brand Part Ends ======-->
<!--====== Features Banner Part Start ======-->

<section class=""features-banner-area pt-80 pb-100"">
    <div class=""container-fluid custom-container"">
        <div class=""features-banner-wrapper d-flex flex-wrap"">
            <div class=""single-features-banner d-flex"">
                <div class=""banner-icon"">
                    <img src=""assets/images/banner-icon/icon1.png"" alt=""Icon"">
                </div>
                <div class=""banner-content media-body"">
                    <h3 class=""banner-title"">Free Shipping</h3>
                 ");
            WriteLiteral(@"   <p>Free shipping on all US order</p>
                </div>
            </div> <!-- single features banner -->
            <div class=""single-features-banner d-flex"">
                <div class=""banner-icon"">
                    <img src=""assets/images/banner-icon/icon2.png"" alt=""Icon"">
                </div>
                <div class=""banner-content media-body"">
                    <h3 class=""banner-title"">Support 24/7</h3>
                    <p>Contact us 24 hours a day</p>
                </div>
            </div> <!-- single features banner -->
            <div class=""single-features-banner d-flex"">
                <div class=""banner-icon"">
                    <img src=""assets/images/banner-icon/icon3.png"" alt=""Icon"">
                </div>
                <div class=""banner-content media-body"">
                    <h3 class=""banner-title"">100% Money Back</h3>
                    <p>You have 30 days to Return</p>
                </div>
            </div> <!-- single features banne");
            WriteLiteral(@"r -->
            <div class=""single-features-banner d-flex"">
                <div class=""banner-icon"">
                    <img src=""assets/images/banner-icon/icon4.png"" alt=""Icon"">
                </div>
                <div class=""banner-content media-body"">
                    <h3 class=""banner-title"">90 Days Return</h3>
                    <p>If goods have problems</p>
                </div>
            </div> <!-- single features banner -->
            <div class=""single-features-banner d-flex"">
                <div class=""banner-icon"">
                    <img src=""assets/images/banner-icon/icon5.png"" alt=""Icon"">
                </div>
                <div class=""banner-content media-body"">
                    <h3 class=""banner-title"">Payment Secure</h3>
                    <p>We ensure secure payment</p>
                </div>
            </div> <!-- single features banner -->
        </div> <!-- features banner wrapper -->
    </div> <!-- container -->
</section>

<!--====== Fe");
            WriteLiteral(@"atures Banner Part Ends ======-->
<!--====== Newsletter Part Start ======-->

<section class=""newsletter-area pt-100 pb-100 bg_cover"" style=""background-image: url(assets/images/bg-newletter.jpg)"">
    <div class=""container"">
        <div class=""row justify-content-end"">
            <div class=""col-lg-8"">
                <div class=""newsletter-content"">
                    <h2 class=""newsletter-title"">Subscribe our newsletter</h2>
                    <p>allup is a powerful eCommerce HTML Template</p>

                    <div class=""newsletter-forn"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8307cac7d2679b7439749fa4ec743ef1fbe5737325087", async() => {
                WriteLiteral("\r\n                            <input type=\"text\" placeholder=\"Your Email address\">\r\n                            <button class=\"main-btn\">Subscribe</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div> <!-- newsletter content -->\r\n            </div>\r\n        </div> <!-- row -->\r\n    </div> <!-- container -->\r\n</section>\r\n\r\n<!--====== Newsletter Part Ends ======-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MemberProfileVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
