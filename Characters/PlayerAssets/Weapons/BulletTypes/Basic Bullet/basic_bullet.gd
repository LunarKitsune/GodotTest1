extends Area2D

@export var speed:float = 0.0
@export var damage:int = 0
@export var isPeircing:bool = false

func _ready():
	pass

func _process(delta):
	pass
	
func _physics_process(delta):
	pass
	
#=====Custom Functions=====#
	
func DestroyBullet():
	queue_free()
	


func _on_body_entered(body:Node2D):
	pass # Replace with function body.
	
func _On_Area_Exited(area:Area2D):
	pass

#=====Custom Functions=====#
func PushBullet(delta):
	var direction:Vector2 = Vector2.RIGHT.rotated(rotation)
