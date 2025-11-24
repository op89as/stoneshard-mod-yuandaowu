if (!instance_exists(o_player))
    exit;

event_inherited();
if (is_open && !scr_is_weapon_type_any_hand("all") && can_work)
{
    can_work = false;
    scr_restore_hp(owner, (owner.max_hp * math_round(0.3 * owner.Vitality)) / 100, name);
}