using System.Text.Json.Serialization;

namespace VoiceTrainedSpecies;

public class Config
{
    [JsonInclude] public string Species = "set following to cat/dog";
    [JsonInclude] public string BarkSpecies = "dog";
    [JsonInclude] public string GrowlSpecies = "dog";
    [JsonInclude] public string WhineSpecies = "dog";
}
