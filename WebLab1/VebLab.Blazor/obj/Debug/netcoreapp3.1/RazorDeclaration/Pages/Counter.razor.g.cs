#pragma checksum "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01aff39856acc2c8f297760121954ae48c1bbdae"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VebLab.Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using VebLab.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\GIT\WEB\WebLab1\VebLab.Blazor\_Imports.razor"
using VebLab.Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\Counter.razor"
using VebLab.Blazor.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\Counter.razor"
       
    private int currentCount = 0;
    private CounterModel counterData = new CounterModel();

    private void IncrementCount()
    {
        currentCount++;
    }
    private void ChangeCounter()
    {
        currentCount = counterData.CounterValue;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591