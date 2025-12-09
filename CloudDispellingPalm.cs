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
        public void AddCloudDispellingPalm()
        {
            GameTools.AdjustSkillIcon("s_skills_cloud_dispelling_palm");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new("Cloud_Dispelling_Palm", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "Cloud Dispelling Palm" },
                    { ModLanguage.Chinese, "排云掌" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, string.Join("##", "Deals ~w~/*Bodypart_Damage*/ damage to all targets within range. ##Damage increases by 15% for every ~w~1~/~ stack of ~w~Inner Force~/~. Removes all ~w~Inner Force~/~ upon cast.")  },
                    {
                        ModLanguage.Chinese, string.Join("##", "对范围内的所有目标造成~w~/*Bodypart_Damage*/点伤害~/~。##每有~w~1~/~层~w~内劲~/~伤害提升15%，释放后会移除全部~w~内劲~/~。")
                    }
                })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("Cloud_Dispelling_Palm", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "Clouds rise as my power, this palm strikes as my judgment — Shatter!",
                        [ModLanguage.Chinese] = "云起为势，掌出为决——破！"
                    }
                })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("MC_Cloud_Dispelling_Palm", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "Wen!",
                        [ModLanguage.Chinese] = "嗡！"
                    }
                })
            });
            Msl.InjectTableSkillsStats(
                hook: SkillsStatsHook.ATHLETICS,
                id: "Cloud_Dispelling_Palm",
                Object: "o_cloud_dispelling_palm",
                Target: SkillsStatsTarget.TargetArea,
                Range: "5",
                KD: 15,
                MP: 30,
                Reserv: 0,
                Duration: 0,
                AOE_Lenght: 5,
                AOE_Width: 3,
                is_movement: false,
                Pattern: SkillsStatsPattern.pyramid,
                Validators: SkillsStatsValidator.none,
                Class: SkillsStatsClass.attack,
                Bonus_Range: false,
                Starcast: null,
                Branch: "yuandaowu",
                is_knockback: false,
                Crime: false,
                metacategory: SkillsStatsMetacategory.none,
                FMB: 0,
                AP: "0",
                Attack: true,
                Stance: false,
                Charge: false,
                Maneuver: false,
                Spell: false
            );
            UndertaleGameObject oCloudDispellingPalm = Msl.AddObject("o_cloud_dispelling_palm", "s_piercinglunge_hit", "o_aoe_spell_animated", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oCloudDispellingPalmBirth = Msl.AddObject("o_cloud_dispelling_palm_birth", "", "o_spellbirth", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillCloudDispellingPalm = Msl.AddObject("o_skill_cloud_dispelling_palm", "s_skills_cloud_dispelling_palm", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillSCloudDispellingPalmIco = Msl.AddObject("o_skill_cloud_dispelling_palm_ico", "s_skills_cloud_dispelling_palm", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            GameObjectUtils.ApplyEvent(oCloudDispellingPalmBirth, new MslEvent[2]
            {
                new(ModFiles.GetCode("o_cloud_dispelling_palm_birth_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_cloud_dispelling_palm_birth_Other_10.gml"), EventType.Other, 10),
            });
            GameObjectUtils.ApplyEvent(oCloudDispellingPalm, new MslEvent[5]
            {
                new(ModFiles.GetCode("o_cloud_dispelling_palm_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_cloud_dispelling_palm_Alarm_1.gml"), EventType.Alarm, 1),
                new(ModFiles.GetCode("o_cloud_dispelling_palm_Destroy_0.gml"), EventType.Destroy, 0),
                new(ModFiles.GetCode("o_cloud_dispelling_palm_Other_10.gml"), EventType.Other, 10),
                new(ModFiles.GetCode("o_cloud_dispelling_palm_Other_25.gml"), EventType.Other, 25),
            });
            GameObjectUtils.ApplyEvent(oSkillCloudDispellingPalm, new MslEvent[4]
            {
                new(ModFiles.GetCode("o_skill_cloud_dispelling_palm_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_skill_cloud_dispelling_palm_Other_13.gml"), EventType.Other, 13),
                new(ModFiles.GetCode("o_skill_cloud_dispelling_palm_Other_14.gml"), EventType.Other, 14),
                new(ModFiles.GetCode("o_skill_cloud_dispelling_palm_Other_17.gml"), EventType.Other, 17),
            });
            GameObjectUtils.ApplyEvent(oSkillSCloudDispellingPalmIco, new MslEvent[1]
            {
                new(ModFiles.GetCode("o_skill_cloud_dispelling_palm_ico_Create_0.gml"), EventType.Create, 0),
            });
        }
    }
}
