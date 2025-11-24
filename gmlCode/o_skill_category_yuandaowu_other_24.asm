:[0]
call.i event_inherited(argc=0)
popz.v
pushi.e 55
conv.i.v
pushi.e 24
conv.i.v
pushi.e o_skill_smash_fist_ico
conv.i.v
push.v self.connectionsRender
push.i gml_Script_ctr_SkillPoint
conv.i.v
call.i @@NewGMLObject@@(argc=5)
:[end]