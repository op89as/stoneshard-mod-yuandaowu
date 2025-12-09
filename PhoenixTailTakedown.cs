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
        public void AddPhoenixTailTakedown()
        {
            GameTools.AdjustSkillIcon("s_skills_phoenix_tail_takedown");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new(
                    id: "Phoenix_tail_takedown",
                    name: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, "Phoenix Tail Takedown"},
                        {ModLanguage.Chinese, "揽凤尾"}
                    },
                    description: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, @"Triggers ~lg~“Phoenix Tail Takedown”~/~, effect ends at the start of the next turn: ##Increases Block Power Limit by ~lg~+/*Block_Power*/~/~. ##Increases Block Chance by ~lg~+/*PRR*/%~/~. ##Instantly and ~lg~fully~/~ restores Block Power. ##For each stack of ~w~Inner Force~/~, increases Block Power Limit by an additional ~lg~+/*Block_Power*/~/~ and Block Chance by an additional ~lg~+/*PRR*/%~/~."},
                        {ModLanguage.Chinese, @"触发~lg~“揽凤尾”~/~，效果在下一回合开始时结束：##格挡力量上限~lg~+/*Block_Power*/。~/~#格挡几率~lg~+/*PRR*/%~/~#立刻~lg~完全~/~恢复格挡力量。 ##每有~w~一~/~层~w~内劲~/~，格挡力量上限~lg~+/*Block_Power*/。~/~#格挡几率~lg~+/*PRR*/%~/~。"}
                 })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("Phoenix_tail_takedown", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "Behold, the grace of the falling phoenix!",
                        [ModLanguage.Chinese] = "看好了，这垂凤之姿！"
                    }
                })
            });
            Msl.InjectTableSkillsStats(
                hook: SkillsStatsHook.ATHLETICS,
                id: "Phoenix_tail_takedown",
                Object: "o_b_phoenix_tail_takedown",
                Target: SkillsStatsTarget.NoTarget,
                Range: "1",
                KD: 8,
                MP: 10,
                Reserv: 0,
                Duration: 1,
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
                Stance: false,
                Charge: false,
                Maneuver: true,
                Spell: false
            );
            UndertaleGameObject oSkillPhoenixTailTakedown = Msl.AddObject("o_skill_phoenix_tail_takedown", "s_skills_phoenix_tail_takedown", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillPhoenixTailTakedownIco = Msl.AddObject("o_skill_phoenix_tail_takedown_ico", "s_skills_phoenix_tail_takedown", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);

            GameObjectUtils.ApplyEvent(oSkillPhoenixTailTakedown, new MslEvent[3]
            {
                new(ModFiles.GetCode("o_skill_phoenix_tail_takedown_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_skill_phoenix_tail_takedown_Other_14.gml"), EventType.Other, 14),
                new(ModFiles.GetCode("o_skill_phoenix_tail_takedown_Other_17.gml"), EventType.Other, 17),
            });
            GameObjectUtils.ApplyEvent(oSkillPhoenixTailTakedownIco, new MslEvent[1]
            {
                new(ModFiles.GetCode("o_skill_phoenix_tail_takedown_ico_Create_0.gml"), EventType.Create, 0),
            });
        }
    }
}
