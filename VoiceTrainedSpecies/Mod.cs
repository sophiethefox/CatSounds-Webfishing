using GDWeave;

namespace VoiceTrainedSpecies;

public class Mod : IMod
{
    public Config Config;
    public Mod(IModInterface modInterface)
    {
        this.Config = modInterface.ReadConfig<Config>();
        modInterface.RegisterScriptMod(new PlayerPatch(Config));
    }

    public void Dispose()
    {
    }
}
