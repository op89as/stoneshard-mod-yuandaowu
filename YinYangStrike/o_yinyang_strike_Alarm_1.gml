scr_skill_call_buff(o_b_wuji_stance, owner);
if (instance_exists(target) && instance_exists(owner))
{
    
    targetX = target.x;
    targetY = target.y;
    light = instance_create_depth(target.x, target.y, 0, o_spotlight);
    
    with (light)
    {
        blend = make_color_rgb(0, 78, 101);
        alpha = 0.85;
        lumalpha = 0.85;
    }
    
    scr_audio_play_at(choose(1788, 1789));
    var distance = scr_tile_distance(owner, target);
    var _crt = (0.25 * owner.STR) + (0.25 * owner.AGL);
    var _wd = (0.5 * owner.STR) + (0.5 * owner.AGL);
    var _stagger_chance = owner.AGL + owner.STR;
    
    with (owner)
    {
        _yingyang_distance = distance
        if (distance > 2)
        {
            with (target)
            {
                if (scr_chance_value(_stagger_chance))
                {
                    var _stagger = scr_instance_exists_in_list(5604);
                
                    if (!_stagger)
                    {
                        scr_effect_create(5604, 2, id, other.owner);
                    }
                    else
                    {
                        with (_stagger)
                            duration++;
                    }
                }
            }
        }
        CRT += 10;
        var _obj_id = asset_get_index("o_b_inner_force");
        var _inner_force = scr_instance_exists_in_list(_obj_id)
        if(!_inner_force)
        {
            scr_effect_create(_obj_id, 10, id, id, 2);
        }
        else
        {
            with (_inner_force)
            {
                stage += 2;
                duration = 10;
            }
        }
    }
}
