var _is_player = is_player(target);
with (target)
{
    scr_block_restore(0.25);
    var _obj_id = asset_get_index("o_b_inner_force");
    var _inner_force = scr_instance_exists_in_list(_obj_id)
    if(!_inner_force)
    {
        scr_effect_create(_obj_id, 10, id, id, 1);
    }
    else
    {
        with (_inner_force)
        {
            stage += 1;
            duration = 10;
        }
   }
}
