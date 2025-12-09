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
        public void AddInnerBalance()
        {
            GameTools.AdjustSkillIcon("s_passive_inner_balance");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new("Inner_Balance", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "Inner Balance" },
                    { ModLanguage.Chinese, "内在平衡" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, string.Join("##", "Adds the effects of \"Pain Change ~lg~-0.01%~/~\" and \"Situational Morale Change ~lg~+0.01%~/~\" to the effectiveness of ~lg~Inner Force~/~. ##Increases Max HP by ~lg~+10~/~.")  },
                    {
                        ModLanguage.Chinese, string.Join("##", "令~lg~内劲~/~的效果增加“疼痛变化~lg~-0.01%~/~”、“情境斗志变化~lg~+0.01%~/~”这两项。##令生命上限~lg~+10~/~。")
                    }
                })
            });

            UndertaleGameObject oInnerBalance = Msl.AddObject("o_pass_skill_inner_balance", "s_passive_inner_balance", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);
            GameObjectUtils.ApplyEvent(oInnerBalance, new MslEvent[2]
            {
                new(ModFiles.GetCode("o_inner_balance_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_inner_balance_Other_17.gml"), EventType.Other, 17),
            });
        }
    }
}
