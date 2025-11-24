var _bodyDamage = math_round(1.1 * owner.STR * owner.Weapon_Damage / 100);



with (owner)
{
    var _buff_stage = 0;
    var _obj_id = asset_get_index("o_b_inner_force");
    var _inner_force = scr_instance_exists_in_list(_obj_id)
    if(_inner_force)
        {
            with (_inner_force)
            {
                _buff_stage = stage;
                instance_destroy();
            }
        }
    Blunt_Damage = math_round(_bodyDamage * (1 + _buff_stage * 0.15));
}
