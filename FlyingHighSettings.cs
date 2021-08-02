using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace FlyingHigh
{
  internal class FlyingHighSettings : AttributeGlobalSettings<FlyingHighSettings>
  {
    public FlyingHighSettings()
    {
      this.DamageFromFallPercentage = 0;
      this.JumpAcceleration = 1000;
    }

    [SettingPropertyGroup("{=MCM_001_Settings_Header}General Mod Settings")]
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Damage From Fall Percentage", 0, 100, "0%", HintText = "{=MCM_001_Settings_Info_001}Controls the percent damage taken from a fall. (Default = 0%, no damage from falling)", RequireRestart = false)]
    public float DamageFromFallPercentage
    {
      get; set;
    }

    public override string DisplayName => "FlyingHigh";

    public virtual string FolderName => "FlyingHigh";

    public virtual string FormatType
    {
      get;
    }

    public override string Id => "FlyingHigh V1.0.0";

    [SettingPropertyGroup("{=MCM_001_Settings_Header}General Mod Settings")]
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Jump Acceleration", 0, 100, "0", HintText = "{=MCM_001_Settings_Info_001}Controls the acceleration of a jump. (Default = 10)", RequireRestart = false)]
    public float JumpAcceleration
    {
      get; set;
    }

    [SettingPropertyGroup("{=MCM_001_Settings_Header}General Mod Settings")]
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Jump Speed Limit", 0, 1000, "0", HintText = "{=MCM_001_Settings_Info_001}Controls the how fast you go when jumping. (Default = 10, decent speed)", RequireRestart = false)]
    public float JumpSpeedLimit
    {
      get; set;
    }
  }
}