event_inherited();
skill = "Cloud_Dispelling_Palm";
info = ds_list_find_value(global.skill_info_text, 25);
ds_list_add(attribute, ds_map_find_value(global.attribute, "STR"), ds_map_find_value(global.attribute, "AGL"), ds_map_find_value(global.attribute, "PRC"));
scr_skill_atr("Cloud_Dispelling_Palm");
startcast_sprite_tag = "s_hellbreathcast_";
click_snd = 1776;
target_group = 3534;
main_spell = o_cloud_dispelling_palm