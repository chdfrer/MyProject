#pragma checksum "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34d0b7c7684224b41aacd03be992f35f2bc92f20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Views_Manage_Index), @"mvc.1.0.view", @"/Areas/Identity/Views/Manage/Index.cshtml")]
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
#line 1 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using MyBlog.Models.UserModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using MyBlog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using MyBlog.Areas.Identity.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using MyBlog.Areas.Identity.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using MyBlog.Areas.Identity.Models.RoleViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using MyBlog.Areas.Identity.Models.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\CHD\MyBlog\Areas\Identity\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34d0b7c7684224b41aacd03be992f35f2bc92f20", @"/Areas/Identity/Views/Manage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb84499eca40c93a684ec788a0fb5291446d1fca", @"/Areas/Identity/Views/_ViewImports.cshtml")]
    public class Areas_Identity_Views_Manage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetPassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ManageLogins", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddPhoneNumber", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemovePhoneNumber", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisableTwoFactorAuthentication", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EnableTwoFactorAuthentication", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ResetAuthenticatorKey", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GenerateRecoveryCode", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
  
    ViewData["Title"] = "Quản lý tài khoản của bạn";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
Write(await Html.PartialAsync("_StatusMessage"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" 
<div>
    <h4>Cập nhật thông tin tài khoản</h4>
    <hr />
    <dl class=""row"">
        <dt class=""col-sm-4"">Thông tin cơ bản:</dt>
        <dd class=""col-sm-6""> 
            <dl class=""row"">
                 <dt class = ""col-sm-6"">
                    ");
#nullable restore
#line 17 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayNameFor(m => Model.profile.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dt>   \r\n                 <dd class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayFor(m => Model.profile.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dd>\r\n            </dl>\r\n             <dl class=\"row\">\r\n                 <dt class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayNameFor(m => Model.profile.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dt>   \r\n                 <dd class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 28 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayFor(m => Model.profile.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dd>\r\n            </dl>\r\n              <dl class=\"row\">\r\n                 <dt class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 33 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayNameFor(m => Model.profile.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dt>   \r\n                 <dd class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayFor(m => Model.profile.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dd>\r\n            </dl>\r\n               <dl class=\"row\">\r\n                 <dt class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 41 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayNameFor(m => Model.profile.HomeAdress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dt>   \r\n                 <dd class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 44 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayFor(m => Model.profile.HomeAdress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dd>\r\n            </dl>                   \r\n                <dl class=\"row\">\r\n                 <dt class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 49 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayNameFor(m => Model.profile.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dt>   \r\n                 <dd class = \"col-sm-6\">\r\n                    ");
#nullable restore
#line 52 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
               Write(Html.DisplayFor(m => Model.profile.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 </dd>\r\n            </dl>      \r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2013703", async() => {
                WriteLiteral("Sửa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n \r\n        </dd>\r\n\r\n        <dt class=\"col-sm-4\">Mật khẩu:</dt>\r\n        <dd class=\"col-sm-6\">\r\n");
#nullable restore
#line 61 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
             if (Model.HasPassword)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2015290", async() => {
                WriteLiteral("Đổi mật khẩu");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 63 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                                                                                        }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2016968", async() => {
                WriteLiteral("Tạo mật khẩu");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class = \"col-sm-4\">Liên kết tài khoản ngoài:</dt>\r\n        <dd class = \"col-sm-6\">\r\n            Có ");
#nullable restore
#line 71 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
          Write(Model.Logins.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" liên kết. ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2018882", async() => {
                WriteLiteral("Quản lý liên kết ngoài");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-4\">Số điện thoại:</dt>\r\n        <dd class = \"col-sm-6\">\r\n            <p>\r\n                Số điện thoại dùng để xác thực hai yêu tố\r\n            </p>\r\n            ");
#nullable restore
#line 79 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
        Write(Model.PhoneNumber ?? "không có");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 80 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                 if (Model.PhoneNumber != null)
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
            WriteLiteral("\r\n");
            WriteLiteral("&nbsp;&nbsp;");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2021052", async() => {
                WriteLiteral("Thay đổi");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("&nbsp;&nbsp;");
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2022479", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn btn-danger btn-sm\">Loại bỏ số điện thoại</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 87 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;&nbsp;");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2024799", async() => {
                WriteLiteral("Thêm số điện thoại");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 90 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                                                                                                                          
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </dd>

        <dt class=""col-sm-4"">Xác thực hai yếu tố:</dt>
        <dd class = ""col-sm-6"">
            <!--<p>
                There are no two-factor authentication providers configured. See <a href=""http://go.microsoft.com/fwlink/?LinkID=532713"">this article</a>
                for setting up this application to support two-factor authentication.
            </p>-->
");
#nullable restore
#line 100 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
             if (Model.TwoFactor)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2027099", async() => {
                WriteLiteral("\r\n                        (Đang kích hoạt) <button type=\"submit\" class=\"btn btn-danger btn-sm\">Hủy</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 105 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2029491", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn btn-primary btn-sm\">Kích hoạt</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 111 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n        <dt class=\"col-sm-4\">Xác thực ứng dụng:</dt>\r\n        <dd class = \"col-sm-6\">\r\n");
#nullable restore
#line 116 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
             if (Model.AuthenticatorKey == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2032183", async() => {
                WriteLiteral("\r\n                    <button type=\"submit\" class=\"btn btn-sm btn-primary\">Phát sinh mã</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 121 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("Mã xác thực là: ");
#nullable restore
#line 124 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
                                 Write(Model.AuthenticatorKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <p>Nhập mã này khi yêu cầu xác thực 2 yếu tố</p>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34d0b7c7684224b41aacd03be992f35f2bc92f2034889", async() => {
                WriteLiteral("\r\n                   <button type=\"submit\" class=\"btn btn-sm btn-primary\">Phát sinh mã phục hồi</button>\r\n                   <p>Mã phục hồi sử dụng để xác thực hai yếu tố</p>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_14.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 130 "C:\Users\CHD\MyBlog\Areas\Identity\Views\Manage\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n    </dl>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
