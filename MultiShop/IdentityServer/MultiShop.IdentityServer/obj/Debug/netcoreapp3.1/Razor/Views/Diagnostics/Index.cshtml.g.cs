#pragma checksum "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b1b4677fa65f66592b56526da066f8141e3105ddd220ebee44d0c1f2694200f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\_ViewImports.cshtml"
using IdentityServerHost.Quickstart.UI

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b1b4677fa65f66592b56526da066f8141e3105ddd220ebee44d0c1f2694200f3", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"a37bb02fe3277db53ef664b0b2223d70455027585a6423f2ad507316524fd6fa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiagnosticsViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""diagnostics-page"">
    <div class=""lead"">
        <h1>Authentication Cookie</h1>
    </div>

    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Claims</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
#line 16 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                         foreach (var claim in Model.AuthenticateResult.Principal.Claims)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <dt>");
            Write(
#nullable restore
#line 18 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                 claim.Type

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</dt>\r\n                            <dd>");
            Write(
#nullable restore
#line 19 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                 claim.Value

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 20 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"                    </dl>
                </div>
            </div>
        </div>
        
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Properties</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
#line 33 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                         foreach (var prop in Model.AuthenticateResult.Properties.Items)
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <dt>");
            Write(
#nullable restore
#line 35 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                 prop.Key

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</dt>\r\n                            <dd>");
            Write(
#nullable restore
#line 36 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                 prop.Value

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 37 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable

#nullable restore
#line 38 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                         if (Model.Clients.Any())
                        {

#line default
#line hidden
#nullable disable

            WriteLiteral("                            <dt>Clients</dt>\r\n                            <dd>\r\n");
#nullable restore
#line 42 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                              
                                var clients = Model.Clients.ToArray();
                                for(var i = 0; i < clients.Length; i++)
                                {
                                    

#line default
#line hidden
#nullable disable

            Write(
#nullable restore
#line 46 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                           clients[i]

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 46 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                                            
                                    if (i < clients.Length - 1)
                                    {
                                        

#line default
#line hidden
#nullable disable

            WriteLiteral(", ");
#nullable restore
#line 49 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                                                       
                                    }
                                }
                            

#line default
#line hidden
#nullable disable

            WriteLiteral("                            </dd>\r\n");
#nullable restore
#line 54 "C:\Users\s.idrisov\Desktop\MultiSohp\MultiShop\IdentityServer\MultiShop.IdentityServer\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable

            WriteLiteral("                    </dl>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiagnosticsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
