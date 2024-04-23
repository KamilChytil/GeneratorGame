using Godot;
using System;

public partial class OpenPuzzles : Node2D
{

	public override void _Ready()
	{

	}
	private void _on_open_math_button_pressed()
	{
		if (PuzzlesShowInstances.i.mathPuzzleNode.Visible == false)
		{

			PuzzlesShowInstances.i.mathPuzzleNode.Visible = true;
		}
		else
		{
			PuzzlesShowInstances.i.mathPuzzleNode.Visible = false;

		}
	}








	private void _on_open_light_button_pressed()
	{

		if (PuzzlesShowInstances.i.lightPuzzlNode.Visible == false)
		{
			
			PuzzlesShowInstances.i.lightPuzzlNode.Visible = true;



		}
		else
		{
			PuzzlesShowInstances.i.lightPuzzlNode.Visible = false;

		}

	}






}





