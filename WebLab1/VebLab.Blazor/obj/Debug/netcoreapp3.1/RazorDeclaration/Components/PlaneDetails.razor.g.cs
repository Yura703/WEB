// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VebLab.Blazor.Components
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
#line 1 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Components\PlaneDetails.razor"
using WebLab.Blazor.Data;

#line default
#line hidden
#nullable disable
    public partial class PlaneDetails : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Components\PlaneDetails.razor"
       
    [Parameter]
    public PlaneDetailsViewModel Plane { get; set; }
    [Parameter]
    public EventCallback<PlaneDetailsViewModel> PlaneChanged { get; set; }
    string imageSrc
    {
        get
        {
            //44310
            return $"https://localhost:44392/images/{Plane.Image}";
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
