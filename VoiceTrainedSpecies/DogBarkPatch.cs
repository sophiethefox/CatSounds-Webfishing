using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace VoiceTrainedSpecies;

public class DogBarkPatch : IScriptMod
{
    public bool ShouldRun(string path) => path == "res://Scenes/Entities/Player/player.gdc";
    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
    {
        foreach (var token in tokens)
        {
            if (token is ConstantToken { Value: StringVariant { Value: "bark_cat" } } identifierToken)
            {
                identifierToken.Value = new StringVariant("bark_dog");
            }
            yield return token;
        }
    }
}

