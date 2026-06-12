extends Node

func _ready() -> void:
	var object := GDExample.new()
	assert(object)
	assert(object.amplitude == 10.0)
	assert(object.speed == 1.0)
	object.amplitude *= 2.0
	assert(object.amplitude == 20.0)
	object.speed *= 2.0
	assert(object.speed == 2.0)
	object.position = Vector2(560.0, 320.0)
	object.texture = ResourceLoader.load("res://icon.svg")
	add_child(object)
