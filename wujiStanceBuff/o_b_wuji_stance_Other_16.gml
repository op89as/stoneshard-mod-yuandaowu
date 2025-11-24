event_inherited();

if (instance_exists(target))
{
    if (is_player(target))
    {
        if (scr_is_weapon_type_any_hand("all"))
            instance_destroy();
    }
}
