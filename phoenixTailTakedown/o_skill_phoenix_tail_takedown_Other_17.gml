ds_map_replace(data, "Block_Power", math_round(owner.STR * owner.Weapon_Damage / 500));
ds_map_replace(data, "PRR", math_round(owner.STR * owner.Weapon_Damage / 500));
event_inherited();
