extends Node2D



func AnimateBody(animationName:String, queueAnimation:bool = false, queuedAnimation:String = ""):
	%AnimationPlayer.play(animationName)
	if(queueAnimation):
		%AnimationPlayer.Queue(queuedAnimation)
