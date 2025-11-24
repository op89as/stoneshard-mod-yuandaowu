if (!instance_exists(owner))
    exit;

category = "noWeapon";
var hit = 0;

if (target.object_index != o_skill_aoe_zone && target.object_index != o_attacked_target)
{
    with (owner)
    {
        hit = scr_skill_attack("noWeapon");
        
        with (other.target)
            diss += 100;
        
        scr_hit_deformation(other.target, 5350);
        scr_atr_calc(id);
    }
    
    with (instance_create_depth(target.x, target.y, 0, o_spellimpact))
        col = 16777215;
}
