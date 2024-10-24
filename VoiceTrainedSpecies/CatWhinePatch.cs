using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace VoiceTrainedSpecies;

public class CatWhinePatch : IScriptMod
{
    public bool ShouldRun(string path) => path == "res://Scenes/Entities/Player/player.gdc";

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
    {
        foreach (var token in tokens)
        {
            if (token is ConstantToken { Value: StringVariant { Value: "whine_dog" } } identifierToken)
            {
                identifierToken.Value = new StringVariant("whine_cat");
            }
            yield return token;
        }
    }
}

