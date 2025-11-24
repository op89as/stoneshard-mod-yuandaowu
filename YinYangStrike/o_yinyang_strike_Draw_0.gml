if (alarm[0] <= 0)
{
    index += 0.2;
    
    if (instance_exists(owner))
        draw_sprite_ext(s_heroestrike, index, targetX, targetY, owner.image_xscale, image_yscale, 0, c_white, 1);
}
