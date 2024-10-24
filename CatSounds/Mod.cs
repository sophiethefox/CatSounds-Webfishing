using GDWeave;

namespace CatSounds;

public class Mod : IMod {
    public Config Config;
    public Mod(IModInterface modInterface) {
        this.Config = modInterface.ReadConfig<Config>();
        if (Config.CatMeow) modInterface.RegisterScriptMod(new BarkPatch());
        if (Config.CatGrowl) modInterface.RegisterScriptMod(new GrowlPatch());
        if (Config.CatWhine) modInterface.RegisterScriptMod(new WhinePatch());
    }

    public void Dispose() {
    }
}
