#pragma checksum "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0ed9c8896696adc7f0ddaffe07ced6ac6c65957"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CategoryList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CategoryList/Default.cshtml")]
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
#line 1 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\_ViewImports.cshtml"
using MvcWebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\_ViewImports.cshtml"
using MvcWebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\_ViewImports.cshtml"
using MvcWebUI.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0ed9c8896696adc7f0ddaffe07ced6ac6c65957", @"/Views/Shared/Components/CategoryList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14f332c955b912d51c6f00c5e5afb629219ad09b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoryList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml"
  
    ViewData["Title"] = "Title";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Kategori Listesi</h1>\r\n\r\n<div class=\"list-group\">\r\n    <a href=\"/product/index\" class=\"list-group-item\">Tümünü Gör</a>\r\n");
#nullable restore
#line 11 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml"
     foreach (var category in Model.Categories)
    {

        var css = "list-group-item";

        if(category.CategoryID==Model.CurrentCategory)
        {
            css += " active";
        }


#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=\"", 418, "\"", 469, 2);
            WriteAttributeValue("", 425, "/product/index?category=", 425, 24, true);
#nullable restore
#line 21 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 449, category.CategoryID, 449, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 470, "\"", 482, 1);
#nullable restore
#line 21 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 478, css, 478, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml"
                                                                   Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 22 "C:\Users\Bulanik\Desktop\Project\Yempazari_Project\MvcWebUI\Views\Shared\Components\CategoryList\Default.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
