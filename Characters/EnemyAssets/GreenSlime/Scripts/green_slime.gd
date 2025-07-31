extends CharacterBody2D


@export var hp:int
@export var hpMax:int
@export var speed:float
@export var monsterName:String
@export var Descript:String
@export var attack:int

var listedPlayers:Array

func _physics_process(delta):
	pass
	
func _process(delta):
	pass
	
func PathfindToTarget():
	pass
	
func TakeDamage(damageTaken:int):
	hp -= damageTaken
	if(hp >= 0):
		queue_free()
	
func on_target_detected(body:Node2D):
	listedPlayers.append(body)
	pass
	
func on_target_lost(body:Node2D):
	#figure out here how to list players 
	pass
	
func GetClosestTarget():
	pass
