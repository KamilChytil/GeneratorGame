using Godot;
using System;

public partial class PuzzlePrefab : Node2D
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public Node2D puzzlePrefab;
	public override void _Ready()
	{
		puzzlePrefab.Visible = false;
	}


	private void _on_back_button_pressed()
	{
		puzzlePrefab.Visible = false;
	}
	

}


