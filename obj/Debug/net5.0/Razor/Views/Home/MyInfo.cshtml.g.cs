#pragma checksum "C:\Users\CHD\MyBlog\Views\Home\MyInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47a64e4f058b046bcd2c3b4bda270c964636657f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MyInfo), @"mvc.1.0.view", @"/Views/Home/MyInfo.cshtml")]
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
#line 1 "C:\Users\CHD\MyBlog\Views\_ViewImports.cshtml"
using MyBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CHD\MyBlog\Views\_ViewImports.cshtml"
using MyBlog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47a64e4f058b046bcd2c3b4bda270c964636657f", @"/Views/Home/MyInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b889b3f4308041dc292b61010b9c4781c7386c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MyInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/me.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\CHD\MyBlog\Views\Home\MyInfo.cshtml"
  
    ViewData["Title"] = "Tác giả";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid overcover"">
    <div class=""container profile-box"">
        <div class=""row"">
            <div class=""col-md-4 left-co"">
                <div class=""left-side"">
                    <div class=""profile-info"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "47a64e4f058b046bcd2c3b4bda270c964636657f4454", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <h3>Cao Hoang Dieu</h3>
                        <span>Web Developer</span>
                    </div>
                    <h4 class=""ltitle"">Contact</h4>
                    <div class=""contact-box pb0"">
                        <div class=""icon"">
                            <i class=""fas fa-phone""></i>
                        </div>
                        <div class=""detail"">
                           034 786 1843
                        </div>
                    </div>
                    <div class=""contact-box pb0"">
                        <div class=""icon"">
                            <i class=""fas fa-globe-americas""></i>
                        </div>
                        <div class=""detail"">
                            caohoangdie1994@gmail.com
                        </div>
                    </div>
                    <div class=""contact-box"">
                        <div class=""icon"">
                            <i class=""fas fa-map-marker-alt""><");
            WriteLiteral(@"/i>
                        </div>
                        <div class=""detail"">
                            F12/17B Quach Dieu, Vinh Loc A, Binh Chanh, Ho Chi Minh
                        </div>
                    </div>
                    <h4 class=""ltitle"">Hobbies</h4>
                    <ul>
                        <li>Reading</li>
                        <li>Swimming</li>
                        <li>Gym</li>
                        <li>Travel</li>
                        <li>Games</li>
                    </ul>
                </div>
            </div>
            <div class=""col-md-8 rt-div"">
                <div class=""rit-cover"">
                    <div class=""hotkey"">
                        <h1");
            BeginWriteAttribute("class", " class=\"", 2112, "\"", 2120, 0);
            EndWriteAttribute();
            WriteLiteral(@">Cao Hoang Dieu</h1>
                        <small>Web Developer</small>
                    </div>
                    <h2 class=""rit-titl"">Profile</h2>
                    <div class=""about"">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis accumsan purus enim, a vestibulum est tristique sit amet. Suspendisse nibh nisl, imperdiet sit amet mi vitae, elementum elementum nibh. Vivamus vitae eros malesuada, convallis dolor malesuada, lobortis ex. Sed cursus augue risus, ac semper est consectetur vitae. Praesent consequat metus sit amet rhoncus luctus.</p>
                    </div>

                    <h2 class=""rit-titl""><i class=""fas fa-briefcase""></i>Work Experiance</h2>
                    <div class=""work-exp"">
                        <h6>My Project</h6>
                        <ul>
                            <li><i class=""far fa-hand-point-right""></i>https://github.com/chdfrer/MyProject.git</li>
                        </ul>
                    </di");
            WriteLiteral(@"v>
                    <h2 class=""rit-titl""><i class=""fas fa-graduation-cap""></i> Education</h2>
                    <div class=""education"">
                        <ul class=""row no-margin"">
                            <li class=""col-md-6"">
                                <span>2014-2018</span> <br>
                                Ho Chi Minh City University of Technology
                            </li>
                            <li class=""col-md-6"">
                                <span>2020</span> <br>
                                Learn .Net myself
                            </li>
                        </ul>
                    </div>

                    <h2 class=""rit-titl""><i class=""fas fa-users-cog""></i> Skills</h2>
                    <div class=""profess-cover row no-margin"">
                        <div class=""col-md-6"">
                            <div class="" prog-row row"">
                                <div class=""col-sm-6"">
                                    .Net
            WriteLiteral(@"
                                </div>
                                <div class=""col-sm-6"">
                                    <div class=""progress"">
                                        <div class=""progress-bar"" role=""progressbar"" style=""width: 75%"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""row prog-row"">
                                <div class=""col-sm-6"">
                                    ASP.Net
                                </div>
                                <div class=""col-sm-6"">
                                    <div class=""progress"">
                                        <div class=""progress-bar"" role=""progressbar"" style=""width: 65%"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                ");
            WriteLiteral(@"                    </div>
                                </div>
                            </div>
                        </div>

                        <div class=""col-md-6"">
                            <div class=""row prog-row"">
                                <div class=""col-sm-6"">
                                    Git
                                </div>
                                <div class=""col-sm-6"">
                                    <div class=""progress"">
                                        <div class=""progress-bar"" role=""progressbar"" style=""width: 65%"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""row prog-row"">
                                <div class=""col-sm-6"">
                                    Sql Server
");
            WriteLiteral(@"                                </div>
                                <div class=""col-sm-6"">
                                    <div class=""progress"">
                                        <div class=""progress-bar"" role=""progressbar"" style=""width: 55%"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591