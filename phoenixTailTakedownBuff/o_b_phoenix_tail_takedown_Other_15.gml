if (instance_exists(owner))
{
    var _bp = math_round(owner.STR * owner.Weapon_Damage / 500);
    with (owner)
    {
        var _obj_id = asset_get_index("o_b_inner_force");
        var _inner_force = scr_instance_exists_in_list(_obj_id);
        var _base_rate = 1;
        if(_inner_force)
        {
            with (_inner_force)
            {
                _base_rate = stage + 1;
            }
        }
        ds_map_replace(other.data, "Block_Power", _bp * _base_rate);
        ds_map_replace(other.data, "PRR", _bp * _base_rate);
        scr_block_restore(1);
    }
}
