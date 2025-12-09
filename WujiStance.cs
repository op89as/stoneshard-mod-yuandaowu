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
        public void AddWujiStance()
        {
            GameTools.AdjustSkillIcon("s_skills_wuji_stance");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new(
                    id: "Wuji_stance",
                    name: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, "Wuji Stance"},
                        {ModLanguage.Chinese, "无极式"}
                    },
                    description: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, @"Triggers ~lg~“Wuji Stance”~/~ for ~w~10~/~ turns: ##Increases Armor Penetration by ~lg~+5%~/~, Limb Damage by ~lg~+10%~/~, Pain Resistance by ~lg~+5%~/~, and Critical Hit Chance by ~lg~+3%~/~.##Effects of the same ~lg~Stance~/~ cannot be active simultaneously."},
                        {ModLanguage.Chinese, @"触发~w~10~/~个回合的~lg~“无极式”~/~：##护甲穿透~lg~+5%~/~#肢体伤害~lg~+10%~/~#疼痛抗性~lg~+5%~/~#暴击几率~lg~+3%~/~。##~lg~站姿~/~效果无法多个同时生效。"}
                 })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("Wuji_stance", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "wuji!",
                        [ModLanguage.Chinese] = "无极!"
                    }
                })
            });
            Msl.InjectTableSkillsStats(
                hook: SkillsStatsHook.ATHLETICS,
                id: "Wuji_stance",
                Object: "o_b_wuji_stance",
                Target: SkillsStatsTarget.NoTarget,
                Range: "0",
                KD: 12,
                MP: 10,
                Reserv: 0,
                Duration: 10,
                AOE_Lenght: 0,
                AOE_Width: 0,
                is_movement: false,
                Pattern: SkillsStatsPattern.normal,
                Validators: SkillsStatsValidator.AVOID_TILEMARKS,
                Class: SkillsStatsClass.skill,
                Bonus_Range: false,
                Starcast: null,
                Branch: "yuandaowu",
                is_knockback: false,
                Crime: false,
                metacategory: SkillsStatsMetacategory.utility,
                FMB: 0,
                AP: "0",
                Attack: false,
                Stance: true,
                Charge: false,
                Maneuver: false,
                Spell: false
            );
            UndertaleGameObject oSkillWujiStance= Msl.AddObject("o_skill_wuji_stance", "s_skills_wuji_stance", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillWujiStanceico = Msl.AddObject("o_skill_wuji_stance_ico", "s_skills_wuji_stance", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);

            GameObjectUtils.ApplyEvent(oSkillWujiStance, new MslEvent[3]
            {
                new(ModFiles.GetCode("o_skill_wuji_stance_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_skill_wuji_stance_Other_14.gml"), EventType.Other, 14),
                new(ModFiles.GetCode("o_skill_wuji_stance_Other_17.gml"), EventType.Other, 17),
            });
            GameObjectUtils.ApplyEvent(oSkillWujiStanceico, new MslEvent[1]
            {
                new(ModFiles.GetCode("o_skill_wuji_stance_ico_Create_0.gml"), EventType.Create, 0),
            });
        }
    }
}
