if (instance_exists(owner))
{
    ds_map_replace(data, "Damage", 10 + (1 * owner.STR));
    ds_map_replace(data, "Knockback_Chance", 60 + (2 * owner.STR));
    ds_map_replace(data, "Stun_Resistance", -(owner.AGL + owner.PRC));
    ds_map_replace(data, "Knockback_Resistance", -(owner.AGL + owner.PRC));
    ds_map_replace(data, "Block_Power", -(3 * owner.STR));
    ds_map_replace(data, "Stagger_Chance", 80 + (2 * owner.AGL));
    ds_map_replace(data, "Crit_Avoid", -(1.5 * owner.PRC));
    ds_map_replace(data, "Hit_Chance", 100 + (2 * owner.PRC));
}

event_inherited();
