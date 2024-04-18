using Godot;
using System;

public partial class BackButtonClick : Node2D
{
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
