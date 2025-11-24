if (instance_exists(owner))
{
    ds_map_replace(data, "Bodypart_Damage", math_round(1.1 * owner.STR * owner.Weapon_Damage / 100));
}

event_inherited();
with (o_skill_aoe_zone)
{
    if (main_owner == other.owner)
    {
        var _target = scr_tile_get_instance(x, y);
        
        if (instance_is(_target, 3533))
        {
            if (scr_instance_exists_in_list(5608, _target.buffs) || scr_instance_exists_in_list(5612, _target.buffs))
            {
                other.MPcost *= 0.6;
                break;
            }
        }
    }
}

event_inherited();
