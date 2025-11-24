if (instance_exists(owner))
{
    var _d = (0.5 * owner.STR) + (0.5 * owner.AGL);
    ds_map_replace(data, "Damage", _d);
    ds_map_replace(data, "More_Damage", _d * 1.5);
    ds_map_replace(data, "CRT", 10);
    ds_map_replace(data, "Stagger_Chance", owner.AGL + owner.STR);
}

event_inherited();