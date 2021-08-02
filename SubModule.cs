using System;
using System.Xml;

using HarmonyLib;

using MCM.Abstractions.Settings.Base.Global;

using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace FlyingHigh
{
  public class SubModule : MBSubModuleBase
  {
    [HarmonyPatch(typeof(Monster), "Deserialize")]
    public static void DeserializePostfix(MBObjectManager objectManager, XmlNode node, ref float ___JumpAcceleration, ref float ___JumpSpeedLimit)
    {
      Harmony.DEBUG = true;

      Debug.Print("");
      FileLog.Log("");

      ___JumpAcceleration = GlobalSettings<FlyingHighSettings>.Instance.JumpAcceleration;
      Debug.Print("JumpAcceleration set to " + GlobalSettings<FlyingHighSettings>.Instance.JumpAcceleration);
      FileLog.Log("JumpAcceleration set to " + GlobalSettings<FlyingHighSettings>.Instance.JumpAcceleration);
      ___JumpSpeedLimit = GlobalSettings<FlyingHighSettings>.Instance.JumpSpeedLimit;

      Harmony.DEBUG = false;
    }

    [HarmonyPatch(typeof(Mission), "ComputeBlowMagnitudeFromFall")]
    public static void Postfix(ref AttackCollisionData acd,
      bool hasVictimMountAgent,
      float victimAgentScale,
      float victimAgentWeight,
      float victimAgentTotalEncumbrance,
      bool isVictimAgentHuman,
      out float baseMagnitude,
      out float specialMagnitude)
    {
      Harmony.DEBUG = true;

      // original code
      float num1 = victimAgentScale;
      float num2 = victimAgentWeight * num1 * num1;
      float num3 = (float)Math.Sqrt(1.0 + (double)victimAgentTotalEncumbrance / (double)num2);
      float num4 = -acd.VictimAgentCurVelocity.z;
      if (hasVictimMountAgent)
      {
        float managedParameter = ManagedParameters.Instance.GetManagedParameter(ManagedParametersEnum.FallSpeedReductionMultiplierForRiderDamage);
        num4 *= managedParameter;
      }
      float num5 = !isVictimAgentHuman ? 1.41f : 1f;
      float managedParameter1 = ManagedParameters.Instance.GetManagedParameter(ManagedParametersEnum.FallDamageMultiplier);
      float managedParameter2 = ManagedParameters.Instance.GetManagedParameter(ManagedParametersEnum.FallDamageAbsorbtion);
      baseMagnitude = (num4 * num4 * managedParameter1 - managedParameter2) * num3 * num5;
      baseMagnitude = MBMath.ClampFloat(baseMagnitude, 0.0f, 499.9f);
      specialMagnitude = baseMagnitude;

      // mod code
      baseMagnitude *= GlobalSettings<FlyingHighSettings>.Instance.DamageFromFallPercentage;
      specialMagnitude *= GlobalSettings<FlyingHighSettings>.Instance.DamageFromFallPercentage;

      Debug.Print("Set fall damage to " + baseMagnitude + ".");
      FileLog.Log("Set fall damage to " + baseMagnitude + ".");
      Debug.Print(baseMagnitude + " * " + GlobalSettings<FlyingHighSettings>.Instance.DamageFromFallPercentage + " = " + baseMagnitude);
      FileLog.Log(baseMagnitude + " * " + GlobalSettings<FlyingHighSettings>.Instance.DamageFromFallPercentage + " = " + baseMagnitude);

      Harmony.DEBUG = false;
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      base.OnBeforeInitialModuleScreenSetAsRoot();
      new Harmony("com.FlyingHigh.akdombrowski").PatchAll();
      InformationManager.DisplayMessage(new InformationMessage("Loaded 'FlyingHigh'.", Color.FromUint(4282569842U)));
    }
  }
}