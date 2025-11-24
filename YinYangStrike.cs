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
        public void AddYinYangStrike()
        {
            GameTools.AdjustSkillIcon("s_skills_yinyang_strike");
            Msl.InjectTableSkillsLocalization(new LocalizationSkill[]
            {
                new("YinYang_Strike", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "YinYang Strike" },
                    { ModLanguage.Chinese, "阴阳突" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, string.Join("##", "Deals ~w~/Damage/ points of blunt damage~/~, with a ~w~/Stagger_Chance/% chance to stagger~/~.\", \"and gains ~w~4~/~ stacks of ~r~Internal Force~/~.")  },
                    { 
                        ModLanguage.Chinese, string.Join("##", "向目标冲刺，根据冲刺的距离释放阳突还是阴突，如果突袭距离大于~w~二~/~则为阴，如果小于等于~w~二~/~则为阳。##阴造成~w~/*Damage*/点钝击伤害~/~，并且有~w~/*Stagger_Chance*/%~/~概率令目标获得失衡。##阳造成~w~/*More_Damage*/点钝击伤害~/~。##不论阴阳都会获得~w~2~/~层内劲，与~w~/*CRT*/暴击率~/~") 
                    }
                })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("YinYang_Strike", new[]
                {
                    new Dictionary<ModLanguage, string>
                    {
                        [ModLanguage.English] = "Attack and defense, a single motion!",
                        [ModLanguage.Chinese] = "动如阴阳，进退如一！"
                    }
                })
            });
            Msl.InjectTableSpeechesLocalization(new[]
            {
                new LocalizationSpeech("MC_YinYang_Strike", new[]
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
                id: "YinYang_Strike",
                Object: "o_yinyang_strike",
                Target: SkillsStatsTarget.TargetObject,
                Range: "4",
                KD: 10, 
                MP: 25, 
                Reserv: 0, 
                Duration: 1, 
                AOE_Lenght: 0, 
                AOE_Width: 0,
                is_movement:  true,
                Pattern: SkillsStatsPattern.normal,
                Validators: SkillsStatsValidator.none,
                Class: SkillsStatsClass.skill,
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
                Maneuver: true, 
                Spell: false
            );
            UndertaleGameObject oYinYangStrike = Msl.AddObject("o_yinyang_strike", "", "o_moving_skill", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oYinYangStrikeTrail = Msl.AddObject("o_yinyang_strike_trail", "", "c_lightingmaterial", false, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillYinYangStrike = Msl.AddObject("o_skill_yinyang_strike", "s_skills_yinyang_strike", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            UndertaleGameObject oSkillSYinYangStrikeIco = Msl.AddObject("o_skill_yinyang_strike_ico", "s_skills_yinyang_strike", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            GameObjectUtils.ApplyEvent(oYinYangStrikeTrail, new MslEvent[2]
            {
                new(ModFiles.GetCode("o_yinyang_strike_trail_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_yinyang_strike_trail_Step_0.gml"), EventType.Step, 0),
            });
            GameObjectUtils.ApplyEvent(oYinYangStrike, new MslEvent[6]
            {
                new(ModFiles.GetCode("o_yinyang_strike_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_yinyang_strike_Destroy_0.gml"), EventType.Destroy, 0),
                new(ModFiles.GetCode("o_yinyang_strike_Alarm_0.gml"), EventType.Alarm, 0),
                new(ModFiles.GetCode("o_yinyang_strike_Alarm_1.gml"), EventType.Alarm, 1),
                new(ModFiles.GetCode("o_yinyang_strike_Other_25.gml"), EventType.Other, 25),
                new(ModFiles.GetCode("o_yinyang_strike_Draw_0.gml"), EventType.Draw, 0),
            });
            //Msl.Save(Msl.Peek(Msl.LoadGML("gml_Object_o_yinyang_strike_Alarm_0")));
            GameObjectUtils.ApplyEvent(oSkillYinYangStrike, new MslEvent[3]
            {
                new(ModFiles.GetCode("o_skill_yinyang_strike_Create_0.gml"), EventType.Create, 0),
                new(ModFiles.GetCode("o_skill_yinyang_strike_Other_14.gml"), EventType.Other, 14),
                new(ModFiles.GetCode("o_skill_yinyang_strike_Other_17.gml"), EventType.Other, 17),
            });
            GameObjectUtils.ApplyEvent(oSkillSYinYangStrikeIco, new MslEvent[1]
            {
                new(ModFiles.GetCode("o_skill_yinyang_strike_ico_Create_0.gml"), EventType.Create, 0),
            });
        }
    }
}
