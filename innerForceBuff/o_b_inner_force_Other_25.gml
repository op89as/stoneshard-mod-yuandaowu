if (instance_exists(owner))
{
    ds_map_replace(text_map, "Stage", stage);
}

event_inherited();
