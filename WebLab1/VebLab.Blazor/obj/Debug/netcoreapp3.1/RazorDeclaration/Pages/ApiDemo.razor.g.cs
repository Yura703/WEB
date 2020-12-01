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
#line 3 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\ApiDemo.razor"
using WebLab.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\ApiDemo.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\ApiDemo.razor"
using VebLab.Blazor.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/apidemo")]
    public partial class ApiDemo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "E:\GIT\WEB\WebLab1\VebLab.Blazor\Pages\ApiDemo.razor"
       
    [Parameter]
    public IEnumerable<PlaneListViewModel> planes { get; set; }
    string apiBaseAddress = "https://localhost:44392/Api/Planes";
    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, apiBaseAddress);
        var client = clientFactory.CreateClient();
        var response = await client.SendAsync(request);//client.GetAsync(apiBaseAddress);
        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            planes = await JsonSerializer.DeserializeAsync<IEnumerable<PlaneListViewModel>>
            (responseStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
    [Parameter]
    public PlaneDetailsViewModel SelectedPlane { get; set; }
    private async Task ShowDetails(int id)
    {
        var client = clientFactory.CreateClient();
        var response = await client.GetAsync(apiBaseAddress + $"/{id}");
        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            SelectedPlane = await JsonSerializer.DeserializeAsync<PlaneDetailsViewModel>(responseStream);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory clientFactory { get; set; }
    }
}
#pragma warning restore 1591
