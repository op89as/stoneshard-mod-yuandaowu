using ModShardLauncher;
using ModShardLauncher.Mods;
using System.Runtime.Versioning;
using UndertaleModLib.Models;
using static ModShardLauncher.Msl;

namespace FristMod
{
    [SupportedOSPlatform("windows")]
    public partial class MyFristMod : Mod
    {
        public void AddMicrocosmicOrbit()
        {
            GameTools.AdjustSkillIcon("s_passive_microcosmic_orbit");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new("Microcosmic_Orbit", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "Microcosmic Orbit" },
                    { ModLanguage.Chinese, "内息周天" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, string.Join("##", "For each ability learned in ~w~yuandao·wu~/~, increases Weapon Damage by ~lg~+3%~/~, Accuracy by ~lg~+1%~/~, Tenacity by ~lg~+1%~/~, Bleeding Resistance by ~lg~+1%~/~, Control Resistance by ~lg~+1%~/~, and Displacement Resistance by ~lg~+1%~/~.")  },
                    {
                        ModLanguage.Chinese, string.Join("##", "~w~元道·武~/~每习得一项能力，兵器伤害~lg~+3%~/~、准度~lg~+1%~/~、坚忍~lg~+1%~/~、出血抗性~lg~+1%~/~、控制抗性~lg~+1%~/~、位移抗性~lg~+1%~/~。")
                    }
                })
            });

            UndertaleGameObject oInnerEnergySuges = Msl.AddObject("o_pass_skill_microcosmic_orbit", "s_passive_microcosmic_orbit", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);
            GameObjectUtils.ApplyEvent(oInnerEnergySuges, new MslEvent[2]
            {
                new(ModFiles.GetCode("o_microcosmic_orbit_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_microcosmic_orbit_Other_17.gml"), EventType.Other, 17),
            });
        }
    }
}
