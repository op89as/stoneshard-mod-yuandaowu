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
        public void AddBuffInnerForce()
        {
            UndertaleGameObject o_b_inner_force = Msl.AddObject(
                name: "o_b_inner_force",
                parentName: "o_buff_maneuver_stage",
                spriteName: "s_b_inner_force",
                isVisible: true,
                isPersistent: false,
                isAwake: true
            );
            Msl.GetSprite("s_b_inner_force").OriginX = 13;
            Msl.GetSprite("s_b_inner_force").OriginY = 13;
            Msl.InjectTableModifiersLocalization(
                new LocalizationModifier(
                    id: "o_b_inner_force",
                    name: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, "Inner Force"},
                        {ModLanguage.Chinese, "内劲"}
                    },
                    description: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, @"##Increases Weapon Damage by ~lg~+1%~/~, Block Chance by ~lg~+1%~/~, Block Power Limit by ~lg~+1%~/~, and Block Power Recovery by ~lg~+1.5%~/~. ##Using skills from the same Ability Tree stacks or reduces this effect (up to a maximum of ~sy~twenty~/~ stacks). ##Current stacks: ~lg~/*Stage*/~/~."},
                        {ModLanguage.Chinese, @"##兵器伤害~lg~+1%~/~#格挡几率~lg~+1%~/~#格挡力量上限~lg~+1%~/~#格挡力量恢复~lg~+1.5%~/~。##运用同一能力树的技能会令这个效果叠加或减少层数（最多叠到~sy~二十~/~层）##当前~lg~/*Stage*/~/~层"}
                    }
                )
            );
            o_b_inner_force.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: ModFiles.GetCode("o_b_inner_force_Create_0.gml")),
                new MslEvent(eventType: EventType.Alarm, subtype: 2, code: ModFiles.GetCode("o_b_inner_force_Alarm_2.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 14, code: ModFiles.GetCode("o_b_inner_force_Other_14.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 15, code: ModFiles.GetCode("o_b_inner_force_Other_15.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 21, code: ModFiles.GetCode("o_b_inner_force_Other_21.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 25, code: ModFiles.GetCode("o_b_inner_force_Other_25.gml"))
                );
        }
    }
}
