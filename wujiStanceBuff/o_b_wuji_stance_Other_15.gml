event_inherited();

with (target)
{
    ds_map_replace(other.data, "CRT", 3 * other.stage);
    ds_map_replace(other.data, "Armor_Piercing", 5 * other.stage);
    ds_map_replace(other.data, "Bodypart_Damage", 10 * other.stage);
    ds_map_replace(other.data, "Pain_Resistance", 5 * other.stage);
}
