
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebLab.Blazor.Data
{
    public class PlaneListViewModel
    {
        [JsonPropertyName("planeId")]
        public int PlaneId { get; set; } // id 
        [JsonPropertyName("planeName")]
        public string PlaneName { get; set; } // название 
    }
    public class PlaneDetailsViewModel
    {
        [JsonPropertyName("planeName")] public string PlaneName { get; set; } // название блюда
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание 
        [JsonPropertyName("speed")]
        public int Speed { get; set; } 
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}
