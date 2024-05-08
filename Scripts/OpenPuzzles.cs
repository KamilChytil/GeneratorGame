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


	private void _on_open_progress_bar_button_pressed()
	{
		if(PuzzlesShowInstances.i.progressBarNode.Visible == false)
		{
			PuzzlesShowInstances.i.progressBarNode.Visible = true;
		}
		else
		{
			PuzzlesShowInstances.i.progressBarNode.Visible = false;

		}
	}

	private void _on_open_simon_button_pressed()
	{
		if (PuzzlesShowInstances.i.simonPuzzleNode.Visible == false)
		{
			PuzzlesShowInstances.i.simonPuzzleNode.Visible = true;
		}
		else
		{
			PuzzlesShowInstances.i.simonPuzzleNode.Visible = false;

		}
	}


}










