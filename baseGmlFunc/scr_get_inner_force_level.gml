/// @function scr_get_inner_force_level()
/// @description 获取内力等级（0-4级）
/// @return {real} 内力等级
function scr_get_inner_force_level()
{
    var _obj_id = asset_get_index("o_b_inner_force");
    var _inner_force = scr_instance_exists_in_list(_obj_id);
    
    // 如果没有找到内力对象，返回0级
    if (!_inner_force)
    {
        return 0;
    }
    
    var _stage = _inner_force.stage;
    
    // 如果层数为0，返回0级
    if (_stage <= 0)
    {
        return 0;
    }
    // 1-5层：1级
    else if (_stage <= 5)
    {
        return 1;
    }
    // 6-10层：2级
    else if (_stage <= 10)
    {
        return 2;
    }
    // 11-15层：3级
    else if (_stage <= 15)
    {
        return 3;
    }
    // 15层以上：4级
    else
    {
        return 4;
    }
}