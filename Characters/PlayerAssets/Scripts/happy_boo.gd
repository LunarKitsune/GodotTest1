extends CharacterBody2D

@export var playerName:String
@export var speed:float
@export var hitpoints:int
@export var hitpointsMax:int
@export var isInvincible:bool

var animatorNode

func _ready():
	animatorNode = get_node("HappyBoo")
	#get_node("HPLabel").Text = 
	
func _process(delta):	
	if(velocity.length() > 0.0 || velocity.length() < 0.0):
		animatorNode.AnimateBody("walk", false, "")
	else:
		animatorNode.AnimateBody("idle", false, "")

func _physics_process(delta):
	GetInput()
	move_and_slide()

#=====Custom Functions=====#
func GetInput():
	var inputDirection:Vector2 = Input.get_vector("GD_Left","GD_Right","GD_Up","GD_Down")
	
	velocity = inputDirection * speed
	return velocity
	
	
func TakeDamage(damageTaken):
	hitpoints -= damageTaken
	
	#need to take care of hp label here
	var hpDisplay:Label = get_node("HpLabel")
	Label.text = str(hitpoints)
	
	if(hitpoints <= 0):
		queue_free()
		
func _on_enemy_collision(body:Node2D):
	#if mob
	#takeDamage
	pass
	
