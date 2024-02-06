using System.Text.Json.Serialization;
using System.Text.Json;

namespace myapp.Models
{
    public class weatherMod
    {
        public float temp { get; set; }
        public float dew { get; set; }
        public float humidity { get; set; }
        public float precip { get; set; }
        public float wgust { get; set; }
        public float wspd { get; set; }
        public float cloudcover { get; set; }
        public float visibility { get; set; }
        public float solarradiation { get; set; }
        public float uvindex { get; set; }

        public override string ToString() => JsonSerializer.Serialize<weatherMod>(this);

    }
}
