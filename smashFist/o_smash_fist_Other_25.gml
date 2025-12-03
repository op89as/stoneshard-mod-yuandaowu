var _dmg = (10 + (1.5 * owner.STR * owner.Weapon_Damage / 100)) * scr_inner_energy_surges();
var _hit_chance = 50 + (2 * owner.PRC);
var _crt = 0.2 * owner.PRR * scr_inner_energy_surges();
with (owner)
{
    scr_damage_chance_reset();
    Blunt_Damage = _dmg;
    Hit_Chance = _hit_chance;
    CRT = _crt;
    if (instance_exists(other.target) && object_is_ancestor(other.target.object_index, o_unit))
    {
        var _target = other.target;
        var _obj_id = asset_get_index("o_b_inner_force");
        var _inner_force = scr_instance_exists_in_list(_obj_id)
        if(!_inner_force)
        {
            scr_effect_create(_obj_id, 10, id, id);
            with (_obj_id)
            {
                stage = 3;
            }
        }
        else
        {
            with (_inner_force)
            {
                stage += 3;
                duration = 10;
            }
        }
    }
    var _inner_force_level = scr_get_inner_force_level();
    if(_inner_force_level > 1)
    {
        Armor_Piercing += _inner_force_level * 15;
    }
}
