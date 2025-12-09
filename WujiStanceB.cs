using ModShardLauncher;
using ModShardLauncher.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using UndertaleModLib.Models;

namespace FristMod
{
    [SupportedOSPlatform("windows")]
    public partial class MyFristMod : Mod
    {
        public void AddBuffWujiStance()
        {
            UndertaleGameObject o_b_wuji_stance= Msl.AddObject(
                name: "o_b_wuji_stance",
                parentName: "o_buff_stance",
                spriteName: "s_b_wuji_stance",
                isVisible: true,
                isPersistent: false,
                isAwake: true
            );
            Msl.GetSprite("s_b_wuji_stance").OriginX = 13;
            Msl.GetSprite("s_b_wuji_stance").OriginY = 13;
            Msl.InjectTableModifiersLocalization(
                new LocalizationModifier(
                    id: "o_b_wuji_stance",
                    name: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, "Wuji Stance"},
                        {ModLanguage.Chinese, "无极式"}
                    },
                    description: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, @"Triggers ~lg~“Wuji Stance”~/~ for ~w~10~/~ turns: ##Increases Armor Penetration by ~lg~+5%~/~, Limb Damage by ~lg~+10%~/~, Pain Resistance by ~lg~+5%~/~, and Critical Hit Chance by ~lg~+3%~/~.##Effects of the same ~lg~Stance~/~ cannot be active simultaneously.Triggers ~lg~“Wuji Stance”~/~ for ~w~10~/~ turns: ##Increases Armor Penetration by ~lg~+5%~/~, Limb Damage by ~lg~+10%~/~, Pain Resistance by ~lg~+5%~/~, and Critical Hit Chance by ~lg~+3%~/~.##Effects of the same ~lg~Stance~/~ cannot be active simultaneously."},
                        {ModLanguage.Chinese, @"触发~w~10~/~个回合的~lg~“无极式”~/~：##护甲穿透~lg~+5%~/~#肢体伤害~lg~+10%~/~#疼痛抗性~lg~+5%~/~#暴击几率~lg~+3%~/~##运用同一能力树的攻击技能会令这个效果叠加1层（最多叠到~w~四~/~层）##最多持续~w~10~/~个回合。##~lg~站姿~/~效果无法多个同时生效。"}
                    }
                )
            );
            o_b_wuji_stance.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: ModFiles.GetCode("o_b_wuji_stance_Create_0.gml")),
                new MslEvent(eventType: EventType.Alarm, subtype: 2, code: ModFiles.GetCode("o_b_wuji_stance_Alarm_2.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 14, code: ModFiles.GetCode("o_b_wuji_stance_Other_14.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 15, code: ModFiles.GetCode("o_b_wuji_stance_Other_15.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 16, code: ModFiles.GetCode("o_b_wuji_stance_Other_16.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 20, code: ModFiles.GetCode("o_b_wuji_stance_Other_20.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 21, code: ModFiles.GetCode("o_b_wuji_stance_Other_21.gml"))
                );
        }
    }
}
