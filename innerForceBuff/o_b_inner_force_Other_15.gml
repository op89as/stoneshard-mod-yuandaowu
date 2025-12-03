event_inherited();

with (target)
{
    ds_map_replace(other.data, "Weapon_Damage", 0.75 * other.stage);
    ds_map_replace(other.data, "PRR", 0.75 * other.stage);
    ds_map_replace(other.data, "Block_Power", 1.75 * other.stage);
    ds_map_replace(other.data, "Block_Recovery", 1.25 * other.stage);
    var _inner_balance = asset_get_index("o_pass_skill_inner_balance");
        if(_inner_balance.is_open)
        {
            ds_map_replace(other.data, "Pain_Change", -0.01);
            ds_map_replace(other.data, "Morale_Change", 0.01);
        }
}
