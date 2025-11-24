function scr_inner_energy_surges()
{
    var _pass_skill_dmg = 1;
    var _inner_balance = asset_get_index("o_pass_skill_inner_energy_surges");
    if (scr_passive_skill_is_open(_inner_balance, owner))
    {
        _pass_skill_dmg = 1.5;
    }
        
    return _pass_skill_dmg;
}
