using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace VoiceTrainedSpecies;

public class PlayerPatch(Config config) : IScriptMod
{
    private readonly Config _config = config;

    public bool ShouldRun(string path) => path == "res://Scenes/Entities/Player/player.gdc";
    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
    {
        //  var type = 0
        var typeMatch = new MultiTokenWaiter([
            t => t.Type is TokenType.PrVar,
            t => t is IdentifierToken { Name: "type" },
            t => t.Type is TokenType.OpAssign,
            t => t is ConstantToken { Value: IntVariant { Value: 0 } },
        ]);


        foreach (var token in tokens)
        {
            yield return token;

            if (typeMatch.Check(token))
            {

                var barkSpecies = _config.BarkSpecies.ToLower();
                var growlSpecies = _config.GrowlSpecies.ToLower();
                var whineSpecies = _config.WhineSpecies.ToLower();
                var validSpecies = new[] { "dog", "cat" };

                // ensure that the species is either cat or dog
                if(!validSpecies.Contains(barkSpecies))
                {
                    barkSpecies = "dog";
                }
                if (!validSpecies.Contains(growlSpecies))
                {
                    growlSpecies = "dog";
                }
                if (!validSpecies.Contains(whineSpecies))
                {
                    whineSpecies = "dog";
                }


                /*
                 * bark_id = ["bark_dog", "growl_dog", "whine_dog"]
                 */
                yield return new Token(TokenType.Newline, 1);
                yield return new IdentifierToken("bark_id");
                yield return new Token(TokenType.OpAssign);
                yield return new Token(TokenType.BracketOpen);
                yield return new ConstantToken(new StringVariant($"bark_{barkSpecies}"));
                yield return new Token(TokenType.Comma);
                yield return new ConstantToken(new StringVariant($"growl_{growlSpecies}"));
                yield return new Token(TokenType.Comma);
                yield return new ConstantToken(new StringVariant($"whine_{whineSpecies}"));
                yield return new Token(TokenType.BracketClose);
                yield return new Token(TokenType.Newline, 1);
            }

        }
    }
}
