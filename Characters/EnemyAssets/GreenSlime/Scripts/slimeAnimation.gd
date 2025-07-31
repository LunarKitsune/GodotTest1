extends Node2D

func AnimateBody(animationName:String, queuedAnimation:String ="", queueAnimation:bool = false):
	%EntityAnimationPlayer.play(animationName)
	if(queueAnimation):
		%EntityAnimationPlayer.Queue(queuedAnimation)
		
