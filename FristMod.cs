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
        public override string Name => "MyFirstMod";
        public override string Author => "小花菊茶";
        public override string Description => "元道·武";
        public override string Version => "0.2.3";
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
                    { ModLanguage.English, "- xxx" },
                    { ModLanguage.Chinese, "-需要空手" }
                }, new Dictionary<ModLanguage, string>
                {
                    { ModLanguage.English, "- xxx"  },
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
            Msl.Save(Msl.ReplaceBy(Msl.MatchFrom(Msl.LoadGML("gml_Object_o_dataLoader_Other_10"), "global.combat_tier1, global.geomancy_tier1"), "scr_classCreate(o_agemon, s_Leosthenes, \"Leosthenes\", \"Male\", \"Human\", \"Nistra\", \"Agemon\", 11, 10, 10, 11, 11, [global.maces_tier1, global.greatmaces_tier1, global.shields_tier1, global.armor_tier1, global.combat_tier1, global.geomancy_tier1, [\"yuandaowu\", o_skill_smash_fist_ico, o_skill_yinyang_strike_ico, o_skill_phoenix_tail_takedown_ico, o_skill_cloud_dispelling_palm_ico, o_skill_wuji_stance_ico,o_pass_skill_inner_balance, o_pass_skill_inner_energy_surges, o_pass_skill_microcosmic_orbit ]], [o_perk_might_and_magic], (1 << 0), false)"));

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
            UndertaleGameObject val = Msl.AddObject("o_skill_category_yuandaowu", "", "o_skill_category_utility", true, false, true, (CollisionShapeFlags)0);
            Msl.InjectTableTextTreesLocalization((LocalizationTextTree[])(object)new LocalizationTextTree[1]
            {
                new("yuandaowu", new Dictionary<ModLanguage, string>
                {
                    {
                        ModLanguage.English,
                        "yuandaowu"
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
                new(55, 24, "o_skill_smash_fist_ico", "_smash_fist"),
                new(55, 62, "o_skill_yinyang_strike_ico", "_yinyang_strike"),
                new(55, 100, "o_skill_phoenix_tail_takedown_ico", "_phoenix_tail_takedown"),
                new(55, 138, "o_skill_cloud_dispelling_palm_ico", "_cloud_dispelling_palm"),
                new(111, 24, "o_skill_wuji_stance_ico", "_wuji_stance"),
                new(111, 62, "o_pass_skill_inner_balance", "_inner_balance"),
                new(111, 100, "o_pass_skill_inner_energy_surges", "_inner_energy_surges"),
                new(111, 138, "o_pass_skill_microcosmic_orbit", "_microcosmic_orbit"),
            };
            var lines = new GMLGenerator.LineData[]
            {
                new(62, 70, "s_skill_line_26", "_line1")
            };
            var connections = new GMLGenerator.ConnectionConfig[]
            {
                new("_yinyang_strike", new[] { "_inner_balance" }, "points"),
                new("_yinyang_strike", new[] { "_line1" }, "lines"),
            };
            string skillPageAsm = GMLGenerator.GMLCodeCombiner.GenerateCompleteSkillTree(skills, lines, connections);
            Msl.AddNewEvent(val, skillPageAsm, EventType.Other, 24, true);
            Msl.Save(Msl.Peek(Msl.LoadAssemblyAsString("gml_Object_o_skill_category_yuandaowu_Other_24")));
            //Msl.AddNewEvent(val, base.ModFiles.GetCode("o_skill_category_yuandaowu_other_24.asm"), EventType.Other, 24, true);
            Msl.Save(Msl.InsertBelow(Msl.MatchFrom(Msl.LoadGML("gml_Object_o_skillmenu_Create_0"), "var _metaCategoriesArray = "), "array_push(_metaCategoriesArray[0], o_skill_category_yuandaowu)"));
        }
    }
}
