using GDWeave;

namespace VoiceTrainedSpecies;

public class Mod : IMod
{
    public Config Config;
    public Mod(IModInterface modInterface)
    {
        this.Config = modInterface.ReadConfig<Config>();

        if(Config.GrowlSpecies == "dog")
        {
            modInterface.RegisterScriptMod(new DogGrowlPatch());
        } else
        {
            modInterface.RegisterScriptMod(new CatGrowlPatch());

        }

        if (Config.BarkSpecies == "dog")
        {
            modInterface.RegisterScriptMod(new DogBarkPatch());
        }
        else
        {
            modInterface.RegisterScriptMod(new CatBarkPatch());

        }

        if (Config.WhineSpecies == "dog")
        {
            modInterface.RegisterScriptMod(new DogWhinePatch());
        }
        else
        {
            modInterface.RegisterScriptMod(new CatWhinePatch());

        }
    }

    public void Dispose()
    {
    }
}
