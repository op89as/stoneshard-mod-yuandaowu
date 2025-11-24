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
        public void AddBuffPhoenixTailTakedown()
        {
            UndertaleGameObject o_b_phoenix_tail_takedown = Msl.AddObject(
                name: "o_b_phoenix_tail_takedown",
                parentName: "o_invisible_buff",
                isVisible: true,
                isPersistent: false,
                isAwake: true
            );
            Msl.InjectTableModifiersLocalization(
                new LocalizationModifier(
                    id: "o_b_phoenix_tail_takedown",
                    name: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, "Phoenix Tail Takedown"},
                        {ModLanguage.Chinese, "揽凤尾"}
                    },
                    description: new Dictionary<ModLanguage, string>{
                        {ModLanguage.English, @"Using skills from this same ability tree will cause this effect to stack or be reduced (up to a maximum of ~sy~ twenty ~/~ layers)"},
                        {ModLanguage.Chinese, @"触发~lg~“揽凤尾”~/~，效果在下一回合开始时结束：##方圆~w~2~/~个方格之内每有一个敌人，格挡力量上限便~lg~+/*Block_Power*/。~/~#格挡几率~lg~+/*PRR*/%~/~#立刻~lg~完全~/~恢复格挡力量##~lg~“挡避”~/~生效期间，每挡住一次击打或完全闪避一次，便立刻恢复格挡力量上限~lg~25%~/~的格挡力量，然后令获得~w~一~/~层~w~内劲~/~、反击几率~lg~+10%~/~。#如果格挡完全成功，还恢复少量生命值。"}
                    }
                )
            );
            o_b_phoenix_tail_takedown.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: ModFiles.GetCode("o_b_phoenix_tail_takedown_Create_0.gml")),
                new MslEvent(eventType: EventType.Alarm, subtype: 2, code: ModFiles.GetCode("o_b_phoenix_tail_takedown_Alarm_2.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 14, code: ModFiles.GetCode("o_b_phoenix_tail_takedown_Other_14.gml")),
                new MslEvent(eventType: EventType.Other, subtype: 15, code: ModFiles.GetCode("o_b_phoenix_tail_takedown_Other_15.gml"))
             );
        }
    }
}
