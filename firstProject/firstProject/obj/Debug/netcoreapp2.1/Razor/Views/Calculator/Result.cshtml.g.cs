#pragma checksum "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9927d95fbe97c495bbe72d6ac16ac1ec57b9ebce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Calculator_Result), @"mvc.1.0.view", @"/Views/Calculator/Result.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Calculator/Result.cshtml", typeof(AspNetCore.Views_Calculator_Result))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9927d95fbe97c495bbe72d6ac16ac1ec57b9ebce", @"/Views/Calculator/Result.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Calculator_Result : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\n\n");
            EndContext();
#line 3 "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml"
  
    ViewData["Title"] = "Sum";

#line default
#line hidden
            BeginContext(38, 24, true);
            WriteLiteral("\n<h1 class=\"title is-1\">");
            EndContext();
            BeginContext(63, 18, false);
#line 7 "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml"
                  Write(ViewData["action"]);

#line default
#line hidden
            EndContext();
            BeginContext(81, 32, true);
            WriteLiteral("</h1>\n<h2 class=\"subtitle is-2\">");
            EndContext();
            BeginContext(114, 23, false);
#line 8 "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml"
                     Write(ViewData["firstNumber"]);

#line default
#line hidden
            EndContext();
            BeginContext(137, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(139, 16, false);
#line 8 "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml"
                                              Write(ViewData["mark"]);

#line default
#line hidden
            EndContext();
            BeginContext(155, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(157, 24, false);
#line 8 "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml"
                                                                Write(ViewData["secondNumber"]);

#line default
#line hidden
            EndContext();
            BeginContext(181, 4, true);
            WriteLiteral("  = ");
            EndContext();
            BeginContext(186, 18, false);
#line 8 "/Users/nurgi17__/Desktop/Study/1 семестр/SWD6(dotNet)/SWD6(dotNET)git/firstProject/firstProject/Views/Calculator/Result.cshtml"
                                                                                             Write(ViewData["result"]);

#line default
#line hidden
            EndContext();
            BeginContext(204, 5, true);
            WriteLiteral("</h2>");
            EndContext();
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
