using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace SimonSays.API.Core;

public class SayModel
{
    [Required]
    public string Id { get; set; }
    [Required]
    public List<int> Says { get; set; }
    [JsonIgnore]
    public DateTime LastUpdate { get; set; }
    [JsonIgnore]
    [DefaultValue(5)]
    public int MinutesUntilRemove { get; } = 5;
    [JsonIgnore]
    [DefaultValue(4)]
    public int MaxValue { get; } = 4;

    [JsonIgnore]
    Random rnd = new Random();

    public SayModel(int minutesUntilRemove, int maxValue)
    {
        Id = Guid.NewGuid().ToString() + "-" + Stopwatch.GetTimestamp().ToString();
        LastUpdate = DateTime.Now;
        Says = new List<int>();
        MinutesUntilRemove = minutesUntilRemove;
        MaxValue = maxValue;
        Says.Add(rnd.Next(maxValue) + 1);
    }

    public SayModel()
    {
        Id = Guid.NewGuid().ToString() + "-" + Stopwatch.GetTimestamp().ToString();
        LastUpdate = DateTime.Now;
        Says = new List<int>();
    }
}
