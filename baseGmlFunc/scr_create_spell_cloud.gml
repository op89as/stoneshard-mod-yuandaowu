function scr_create_spell_cloud(arg0, arg1)
{
        if (scr_pat_prototype(arg0, arg1) && !scr_tile_get_instance(arg0, arg1))
            return -4;
        
        with (instance_create_depth(arg0, arg1, 0, spell))
        {
            damage = other.damage;
            direction = point_direction(x, y, other.point.x, other.point.y);
            name = other.name;
            owner = other.owner;
            target = other.point;
            is_crit = other.is_crit;
            return id;
        }
};