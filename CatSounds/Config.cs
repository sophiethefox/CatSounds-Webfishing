using System.Text.Json.Serialization;

namespace CatSounds;

public class Config
{
    [JsonInclude] public bool CatMeow = true;
    [JsonInclude] public bool CatWhine = true;
    [JsonInclude] public bool CatGrowl = true;
}
