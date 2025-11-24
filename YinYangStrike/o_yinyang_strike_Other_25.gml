var _wd = math_round( owner.Weapon_Damage * (owner.STR + owner.AGL) / 100 *  scr_inner_energy_surges());
var _crt = 0.2 * owner.PRR * scr_inner_energy_surges();
with (owner)
{
    if(_yingyang_distance > 2)
    {
        Blunt_Damage = _wd;
    }else
    {
        Blunt_Damage = _wd * 1.5;
    }
    Hit_Chance += 16;
    CRT = _crt;
}
