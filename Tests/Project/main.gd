extends Node

func _ready() -> void:
	var object: GDExample = $GDExample
	assert(object)
	assert(object.amplitude == 10.0)
	assert(object.speed == 1.0)
	object.amplitude *= 2.0
	assert(object.amplitude == 20.0)
	object.speed *= 2.0
	assert(object.speed == 2.0)
