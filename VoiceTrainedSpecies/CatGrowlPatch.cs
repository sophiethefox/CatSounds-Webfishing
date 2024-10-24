using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace VoiceTrainedSpecies;

public class CatGrowlPatch : IScriptMod
{
    public bool ShouldRun(string path) => path == "res://Scenes/Entities/Player/player.gdc";

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
    {
        foreach (var token in tokens)
        {
            if (token is ConstantToken { Value: StringVariant { Value: "growl_dog" } } identifierToken)
            {
                identifierToken.Value = new StringVariant("growl_cat");
            }
            yield return token;
        }
    }
}

