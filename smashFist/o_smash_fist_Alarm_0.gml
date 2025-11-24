if (instance_exists(owner) && instance_exists(target))
{
    var _hit = false;
    
    with (owner)
        _hit = scr_skill_attack("noWeapon");
    if (_hit)
    {
        var _inner_force_level = 0;
        with (owner)
        {
            _inner_force_level = scr_get_inner_force_level();
        }
        var _stagger_chance = _inner_force_level * 15 + (1.2 * owner.AGL);
        with (target)
        {
            if (scr_chance_value(_stagger_chance - Knockback_Resistance))
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
                
                scr_skill_call_passive(6268, other.owner);
            }
        }
        
        scr_skill_call_passive(6268, owner, target);
    }
    
    if (owner.attack_result != "miss")
    {
        scr_temp_effect_update(object_index, target, "Stun_Resistance", -(owner.AGL + owner.PRC), 4, 2);
        scr_temp_effect_update(object_index, target, "Knockback_Resistance", -(owner.AGL + owner.PRC), 4, 2);
        scr_temp_effect_update(object_index, target, "Block_Power", (-(3 * owner.STR) * target.Block_PowerMax) / 100, 4, 2);
        scr_temp_effect_update(object_index, target, "Crit_Avoid", -(1.5 * owner.PRC), 4, 2);
    }
}

instance_destroy();
