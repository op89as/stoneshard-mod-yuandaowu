using ModShardLauncher;
using ModShardLauncher.Mods;
using System.Runtime.Versioning;
using System.Xml;
using UndertaleModLib.Models;
using static ModShardLauncher.Msl;
namespace FristMod
{
    [SupportedOSPlatform("windows")]
    public partial class MyFristMod : Mod
    {
        public override string Name => "yuandao·wu";
        public override string Author => "小花菊茶";
        public override string Description => "元道·武";
        public override string Version => "1.0.1";
        public override void PatchMod()
        {
            BaseGmlFuncManagement();
            BuffManagement();
            SkillManagement();
            PatchSkills();
        }
        private void SkillManagement()
        {
            GameTools.InjectTableSkillsTextInfoLocalization(new LocalizationSkill[]
            {
                new("25", new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "- Empty Handed" },
                    { ModLanguage.Chinese, "-需要空手" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "- Empty Handed"  },
                    {
                        ModLanguage.Chinese, "-需要空手"
                    }
                })
            });
            SetNewBlockPowerLogic();
            AddInnerEnergySurges();
            AddInnerBalance();
            AddMicrocosmicOrbit();
            AddSmashFist();
            AddYinYangStrike();
            AddPhoenixTailTakedown();
            AddCloudDispellingPalm();
            AddWujiStance();
            Msl.LoadGML("gml_GlobalScript_scr_skill_tier_init")
                .MatchFrom("global.armor_tier3 = [\"Armor\", 926, 5126]")
                .InsertBelow(@"
                global.yuandaowu_tier1 = [""yuandaowu"", o_skill_smash_fist_ico, o_skill_yinyang_strike_ico, o_pass_skill_inner_balance];
                global.yuandaowu_tier2 = [""yuandaowu"", o_pass_skill_microcosmic_orbit, o_skill_wuji_stance_ico, o_skill_phoenix_tail_takedown_ico];
                global.yuandaowu_tier3 = [""yuandaowu"", o_skill_cloud_dispelling_palm_ico, o_pass_skill_inner_energy_surges];
                ").Save();
            Msl.Save(Msl.ReplaceBy(Msl.MatchFrom(Msl.LoadGML("gml_Object_o_dataLoader_Other_10"), "global.combat_tier1, global.geomancy_tier1"), "scr_classCreate(o_agemon, s_Leosthenes, \"Leosthenes\", \"Male\", \"Human\", \"Nistra\", \"Agemon\", 11, 10, 10, 11, 11, [global.maces_tier1, global.greatmaces_tier1, global.shields_tier1, global.armor_tier1, global.combat_tier1, global.geomancy_tier1, global.yuandaowu_tier1], [o_perk_might_and_magic], (1 << 0), false)"));
            
        }
        //调整空手获得格挡力量的逻辑
        private static void SetNewBlockPowerLogic() 
        {
            Msl.LoadGML("gml_GlobalScript_scr_atr_calc")
                .MatchFrom("Block_Recovery = 0")
                .InsertBelow(@"
                // 新增：单独处理空手但有buff提供格挡属性情况
                var buffPRR = scr_buff_param(""PRR"");
                var buffBlockPower = scr_buff_param(""Block_Power"");
                var buffBlockRecovery = scr_buff_param(""Block_Recovery"");
    
                if (buffPRR > 0 || buffBlockPower > 0 || buffBlockRecovery > 0)
                {
                    // 格挡几率 = 基础PRR计算 + buff提供的PRR
                    PRR = clamp(-15 + (STR * 1.5) + scr_inv_buff_atr(""PRR"") + buffPRR, 0, 100);
        
                    // 格挡力量 = buff提供的格挡力量
                    Block_PowerMax = max(0, buffBlockPower);
                    Block_Power = Block_PowerMax * Block_RecoveryStatus;
        
                    // 格挡恢复 = 基础恢复 + 体力加成 + buff提供的恢复
                    Block_Recovery = clamp(scr_inv_buff_atr(""Block_Recovery"") + 5 + (_bonusVIT * 5) + buffBlockRecovery, 1, 100);
                }
                ")
                .Save();
        }
        private void BuffManagement()
        {
            AddBuffInnerForce();
            AddBuffPhoenixTailTakedown();
            AddBuffWujiStance();
        }
        private void BaseGmlFuncManagement()
        {
            Msl.AddFunction(ModFiles.GetCode("scr_apply_inner_force_effect.gml"), "scr_apply_inner_force_effect");
            Msl.AddFunction(ModFiles.GetCode("scr_get_inner_force_level.gml"), "scr_get_inner_force_level");
            Msl.AddFunction(ModFiles.GetCode("scr_create_spell_cloud.gml"), "scr_create_spell_cloud");
            Msl.AddFunction(ModFiles.GetCode("scr_inner_energy_surges.gml"), "scr_inner_energy_surges");
        }
        //添加技能页面
        private static void PatchSkills()
        {
            Msl.GetSprite("s_base_skill_page").OriginX = 0;
            Msl.GetSprite("s_base_skill_page").OriginY = 0;
            UndertaleGameObject val = Msl.AddObject("o_skill_category_yuandaowu", "", "o_skill_category_utility", true, false, true, CollisionShapeFlags.Box);
            Msl.InjectTableTextTreesLocalization((LocalizationTextTree[])(object)new LocalizationTextTree[1]
            {
                new("yuandaowu", new Dictionary<ModLanguage, string>
                {
                    {
                        ModLanguage.English,
                        "yuandao·wu"
                    },
                    {
                        ModLanguage.Chinese,
                        "元道·武"
                    }
                }, new Dictionary<ModLanguage, string>
                {
                    {
                        (ModLanguage)1,
                        "##~y~Main focus:~/~#~w~Survival~/~, ~w~Support~/~, ~w~Crowd Control~/~"
                    },
                    {
                        (ModLanguage)2,
                        "来自东方的神秘武术，不依赖武器靠双拳制服敌人，因为不使用武器，兵器伤害会被转化为内功。##~y~能力要义：~/~#~w~力量~/~、~w~兵器伤害~/~、~w~生存~/~。##兵器伤害在计算伤害时会参与计算"
                    }
                })
            });
            GameObjectUtils.ApplyEvent(val, (MslEvent[])(object)new MslEvent[1]
            {
                new(@"
                            event_inherited()
                            text = ""yuandaowu""
                            skill = [o_skill_smash_fist_ico, o_skill_yinyang_strike_ico, o_skill_phoenix_tail_takedown_ico, o_skill_cloud_dispelling_palm_ico, o_skill_wuji_stance_ico, o_pass_skill_inner_balance, o_pass_skill_inner_energy_surges, o_pass_skill_microcosmic_orbit]
                            branch_sprite = s_base_skill_page
                            alarm[1] = 2
                        ", EventType.Create, 0u)
            });
            var skills = new GMLGenerator.SkillData[]
            {
                new(55, 31, "o_skill_smash_fist_ico", "_smash_fist"),
                new(55, 81, "o_skill_yinyang_strike_ico", "_yinyang_strike"),
                new(55, 131, "o_pass_skill_inner_balance", "_inner_balance"),
                new(128, 31, "o_pass_skill_microcosmic_orbit", "_microcosmic_orbit"),
                new(128, 81, "o_skill_wuji_stance_ico", "_wuji_stance"),
                new(128, 131, "o_skill_phoenix_tail_takedown_ico", "_phoenix_tail_takedown"),
                new(201, 56, "o_skill_cloud_dispelling_palm_ico", "_cloud_dispelling_palm"),
                new(201, 107, "o_pass_skill_inner_energy_surges", "_inner_energy_surges"),
            };
            var lines = new GMLGenerator.LineData[]
            {
                new(31, 70, "s_skill_line_1", "_line1"),
                new(81, 70, "s_skill_line_1", "_line2"),
                new(131, 70, "s_skill_line_1", "_line3"),
                new(31, 143, "s_skill_line_2", "_line4"),
                new(81, 143, "s_skill_line_4", "_line5"),
                new(131, 143, "s_skill_line_3", "_line6"),
                new(56, 166, "s_skill_line_5", "_line7", true),
                new(106, 166, "s_skill_line_5", "_line8", true),
            };
            var connections = new GMLGenerator.ConnectionConfig[]
            {
                new("_microcosmic_orbit", new[] { "_smash_fist" }, "points"),
                new("_microcosmic_orbit", new[] { "_line1" }, "lines"),
                new("_wuji_stance", new[] { "_yinyang_strike" }, "points"),
                new("_wuji_stance", new[] { "_line2" }, "lines"),
                new("_phoenix_tail_takedown", new[] { "_inner_balance" }, "points"),
                new("_phoenix_tail_takedown", new[] { "_line3" }, "lines"),
                new("_cloud_dispelling_palm", new[] { "_microcosmic_orbit", "_wuji_stance" }, "points"),
                new("_cloud_dispelling_palm", new[] { "_line7" }, "lines"),
                new("_inner_energy_surges", new[] { "_wuji_stance", "_phoenix_tail_takedown" }, "points"),
                new("_inner_energy_surges", new[] { "_line8" }, "lines"),
                new("_line1", new[] { "_smash_fist" }, "points"),
                new("_line2", new[] { "_yinyang_strike" }, "points"),
                new("_line3", new[] { "_inner_balance" }, "points"),
                new("_line4", new[] { "_microcosmic_orbit" }, "points"),
                new("_line5", new[] { "_wuji_stance" }, "points"),
                new("_line6", new[] { "_phoenix_tail_takedown" }, "points"),
                new("_line7", new[] { "_microcosmic_orbit", "_wuji_stance" }, "points"),
                new("_line7", new[] { "_line4", "_line5" }, "lines"),
                new("_line8", new[] { "_wuji_stance", "_phoenix_tail_takedown" }, "points"),
                new("_line8", new[] { "_line5", "_line6" }, "lines"),
            };
            string skillPageAsm = GMLGenerator.GMLCodeCombiner.GenerateCompleteSkillTree(skills, lines, connections);
            Msl.AddNewEvent(val, skillPageAsm, EventType.Other, 24, true);
            Msl.Save(Msl.Peek(Msl.LoadAssemblyAsString("gml_Object_o_skill_category_yuandaowu_Other_24")));
            //Msl.AddNewEvent(val, base.ModFiles.GetCode("o_skill_category_yuandaowu_other_24.asm"), EventType.Other, 24, true);
            Msl.Save(Msl.InsertBelow(Msl.MatchFrom(Msl.LoadGML("gml_Object_o_skillmenu_Create_0"), "var _metaCategoriesArray = "), "array_push(_metaCategoriesArray[0], o_skill_category_yuandaowu)"));
        }
    }
}
