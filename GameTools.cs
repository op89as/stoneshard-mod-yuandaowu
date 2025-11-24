using ModShardLauncher;
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
    internal class GameTools
    {
        public static void AdjustSkillIcon(string name)
        {
            UndertaleSprite sprite = Msl.GetSprite(name);
            sprite.CollisionMasks.RemoveAt(0);
            sprite.IsSpecialType = true;
            sprite.SVersion = 3u;
            sprite.OriginX = 12;
            sprite.OriginY = 12;
            sprite.GMS2PlaybackSpeed = 1f;
            sprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
        }
        public static Func<IEnumerable<string>, IEnumerable<string>>  CreateInjectionSkillsTextInfoLocalization(params LocalizationSkill[] skills)
        {
            LocalizationBaseTable localizationBaseTable = new(
            ("skill_info_text_end;", "name")
        );
            return localizationBaseTable.CreateInjectionTable(skills.Select(x => x as ILocalizationElement).ToList());
        }
        public static void InjectTableSkillsTextInfoLocalization(params LocalizationSkill[] skills)
        {
            Localization.InjectTable("gml_GlobalScript_table_skills", CreateInjectionSkillsTextInfoLocalization(skills));
        }
    }
}
