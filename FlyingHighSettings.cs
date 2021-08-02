using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace FlyingHigh
{
  internal class FlyingHighSettings : AttributeGlobalSettings<FlyingHighSettings>
  {
    public FlyingHighSettings()
    {
      this.DamageFromFallPercentage = 100;
      this.JumpAcceleration = 4;
      this.JumpSpeedLimit = 0;
    }

    [SettingPropertyGroup("{=MCM_001_Settings_Header}General Mod Settings")]
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Damage From Fall Percentage", 0, 100, "0%", HintText = "{=MCM_001_Settings_Info_001}Controls what percentage of damage is taken from a fall. (Default = 100%, full damage taken from falling)", RequireRestart = false)]
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
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Jump Acceleration", 0, 100, "0", HintText = "{=MCM_001_Settings_Info_001}Controls the acceleration of a jump. (Default = 4)", RequireRestart = false)]
    public float JumpAcceleration
    {
      get; set;
    }

    [SettingPropertyGroup("{=MCM_001_Settings_Header}General Mod Settings")]
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Jump Speed Limit", 0, 1000, "0", HintText = "{=MCM_001_Settings_Info_001}Controls how fast you move when jumping. (Default = 0)", RequireRestart = false)]
    public float JumpSpeedLimit
    {
      get; set;
    }
  }
}