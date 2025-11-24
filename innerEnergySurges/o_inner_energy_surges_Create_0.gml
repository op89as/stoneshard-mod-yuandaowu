event_inherited();
info = ds_list_find_value(global.skill_info_text, 25);
scr_skill_atr("Inner_Energy_Surges");
attributes_names_to_open = ["STR", "AGL", "Vitality"];
attributes_value_to_open = 14;
level_to_open = 16;
can_work = true;
ds_list_add(attribute, ds_map_find_value(global.attribute, "Vitality"));
///tier_to_open = global.shields_tier1;