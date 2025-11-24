if (instance_exists(owner))
{
    ds_map_replace(data, "Bodypart_Damage", math_round(1.1 * owner.STR * owner.Weapon_Damage / 100));
}

event_inherited();
