if (is_open && !scr_is_weapon_type_any_hand("all") && instance_exists(owner))
{
        var _count = 0;
        var _obj_id = asset_get_index("o_skill_category_yuandaowu");
        with (_obj_id)
        {
            var _size = array_length(skill);
            for (var i = 0; i < _size; i++)
            {
                if (skill[i].is_open)
                    _count++;
            }
        }
        ds_map_replace(data, "Weapon_Damage", 3 * _count);
        ds_map_replace(data, "Hit_Chance", 1 * _count);
        ds_map_replace(data, "Fortitude", 1 * _count);
        ds_map_replace(data, "Bleeding_Resistance", 1 * _count);
        ds_map_replace(data, "Stun_Resistance", 1 * _count);
        ds_map_replace(data, "Knockback_Resistance", 1 * _count);
}
    

event_inherited();
