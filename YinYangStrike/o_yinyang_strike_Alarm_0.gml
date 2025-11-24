if (instance_exists(owner) && instance_exists(target))
{
    turn_count = scr_tile_distance_min(owner, target);
    xx = scr_round_cell(owner.x);
    yy = scr_round_cell(owner.y);
    
    if (turn_count > 1 && ds_list_empty(owner.lock_turn))
    {
        with (owner)
        {
            scr_movementDust();
            
            if (!scr_one_path_move(other.target, true, id))
                instance_destroy(other.id);
        }
        
        alarm[0] = 3;
    }
    else
    {
        if (turn_count == 1)
        {
            with (owner)
            {
                var hit = scr_skill_attack("noWeapon");
                scr_skill_hit(323);
                
                if (is_player())
                    event_user(5);
            }
        }
        
        event_inherited();
    }
}
else
{
    event_inherited();
}
