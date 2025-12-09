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
        public void AddSmashFist()
        {
            GameTools.AdjustSkillIcon("s_skills_smash_fist");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new("Smash_Fist", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "Smash Fist" },
                    { ModLanguage.Chinese, "崩拳" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, string.Join("##", "Deals ~w~/*Damage*/ points of Blunt damage~/~ to the target and grants ~w~3~/~ stacks of ~r~Inner Force~/~. ##For every 5 stacks of Inner Force, increases the Stagger probability by ~w~15~/~%. ##After exceeding 5 stacks, for every additional 5 stacks of Inner Force, increases Armor Break by ~w~15~/~%.")  },
                    { ModLanguage.Chinese, string.Join("##", "对目标造成~w~/*Damage*/点钝击伤害~/~。并获得~w~3~/~层~r~内劲~/~。##每有5层内劲就会提升~w~15~/~%的失衡概率。##超过5层之后每有5层内劲会增加~w~15~/~%的护甲破坏。") }
                })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("Smash_Fist", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "Hmph!",
                        [ModLanguage.Chinese] = "哼！"
                    }
                })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("MC_Smash_Fist", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "Wen!",
                        [ModLanguage.Chinese] = "嗡！"
                    }
                })
            });
            Msl.InjectTableSkillsStats(
                SkillsStatsHook.ATHLETICS,
                "Smash_Fist",
                "o_smash_fist",
                SkillsStatsTarget.TargetObject,
                "1",
                2, 5, 0, 1, 0, 0,
                false,
                SkillsStatsPattern.normal,
                SkillsStatsValidator.none,
                SkillsStatsClass.skill,
                false,
                null,
                "yuandaowu",
                false,
                false,
                SkillsStatsMetacategory.none,
                0,
                "0",
                true, false, false, false, false
            );
            UndertaleGameObject oSmashFist = Msl.AddObject("o_smash_fist", "s_powerkick_hit", "o_target_spell", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillSmashFist = Msl.AddObject("o_skill_smash_fist", "s_skills_smash_fist", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillSmashFistIco = Msl.AddObject("o_skill_smash_fist_ico", "s_skills_smash_fist", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);

            GameObjectUtils.ApplyEvent(oSmashFist, new MslEvent[5]
            {
                new(ModFiles.GetCode("o_smash_fist_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_smash_fist_Alarm_0.gml"), EventType.Alarm, 0),
                new(ModFiles.GetCode("o_smash_fist_Alarm_1.gml"), EventType.Alarm, 1),
                new(ModFiles.GetCode("o_smash_fist_Alarm_10.gml"), EventType.Alarm, 10),
                new(ModFiles.GetCode("o_smash_fist_Other_25.gml"), EventType.Other, 25),
            });
            //Msl.Save(Msl.Peek(Msl.LoadGML("gml_Object_o_smash_fist_Alarm_0")));
            GameObjectUtils.ApplyEvent(oSkillSmashFist, new MslEvent[3]
            {
                new(ModFiles.GetCode("o_skill_smash_fist_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_skill_smash_fist_Other_14.gml"), EventType.Other, 14),
                new(ModFiles.GetCode("o_skill_smash_fist_Other_17.gml"), EventType.Other, 17),
            });
            GameObjectUtils.ApplyEvent(oSkillSmashFistIco, new MslEvent[2]
            {
                new(ModFiles.GetCode("o_skill_smash_fist_ico_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_skill_smash_fist_ico_Other_17.gml"), EventType.Other, 17),
            });
        }
    }
}
