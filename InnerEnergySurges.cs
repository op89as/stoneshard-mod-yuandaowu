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
        public void AddInnerEnergySurges()
        {
            GameTools.AdjustSkillIcon("s_passive_inner_energy_surges");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new("Inner_Energy_Surges", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "Inner Energy Surges" },
                    { ModLanguage.Chinese, "气贯周身" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, string.Join("##", "Deals ~w~/Damage/ points of blunt damage~/~, with a ~w~/Stagger_Chance/% chance to stagger~/~.\", \"and gains ~w~4~/~ stacks of ~r~Internal Force~/~.")  },
                    {
                        ModLanguage.Chinese, string.Join("##", "令~w~“崩拳”~/~和~w~“阴阳突”~/~的伤害~lg~+50%~/~、暴击几率提高~lg~一半~/~。##如果~r~“空手”~/~情况下击杀目标，那么立刻恢复生命上限~lg~/*HP*/%~/~的生命")
                    }
                })
            });

            UndertaleGameObject oInnerEnergySuges = Msl.AddObject("o_pass_skill_inner_energy_surges", "s_passive_inner_energy_surges", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);
            GameObjectUtils.ApplyEvent(oInnerEnergySuges, new MslEvent[4]
            {
                new(ModFiles.GetCode("o_inner_energy_surges_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_inner_energy_surges_Other_16.gml"), EventType.Other, 16),
                new(ModFiles.GetCode("o_inner_energy_surges_Other_17.gml"), EventType.Other, 17),
                new(ModFiles.GetCode("o_inner_energy_surges_Other_19.gml"), EventType.Other, 19),
            });
        }
    }
}
