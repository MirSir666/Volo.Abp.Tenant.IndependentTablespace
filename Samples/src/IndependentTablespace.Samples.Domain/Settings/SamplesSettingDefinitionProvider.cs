using Volo.Abp.Settings;

namespace IndependentTablespace.Samples.Settings;

public class SamplesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SamplesSettings.MySetting1));
    }
}
