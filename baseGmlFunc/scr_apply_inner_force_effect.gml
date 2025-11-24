/// @function scr_apply_inner_force_effect(instance_id, [stage_increment], [duration_time])
/// @param {instance_id} 目标实例ID
/// @param {stage_increment} 阶段增加值（默认4）
/// @param {_duration_time} 持续时间（默认10）
function scr_apply_inner_force_effect(instance_id = id, _stage_inc = 0, _duration_time = 0) {
    if (!instance_exists(instance_id))
        return false;
    var _owner = instance_id
    if (is_player(instance_id))
        _owner = 5074;

    var _obj_id = asset_get_index("o_b_inner_force");
    var _inner_force = scr_instance_exists_in_list(_obj_id);
    
    if (!_inner_force) {
        scr_effect_create(_obj_id, _duration_time, _owner, _owner, _stage_inc);
    } else {
        with (_inner_force) {
            stage += _stage_inc;
            duration = _duration_time;
        }
    }
}