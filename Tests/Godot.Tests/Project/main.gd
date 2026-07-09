extends Node2D

func _ready() -> void:
	$GDExample.position_changed.connect(_on_position_changed)

func _on_position_changed(new_position: Vector2) -> void:
	prints("New position:", new_position)
