using Godot;
using System;

public partial class OpenPuzzles : Node2D
{

    public override void _Ready()
    {

    }
    private void _on_open_math_button_pressed()
	{
		if (PuzzlesCloseInstances.i.mathPuzzleNode.Visible == false)
		{

			if (PuzzlesData.i.isMathCombinationGenerate == false)
			{

				PuzzlesCloseInstances.i.mathPuzzleNode.Visible = true;
				MathPuzzle.iMathPuzzle.CreatePuzzleCombination();
			}

		}
		else
		{
			PuzzlesCloseInstances.i.mathPuzzleNode.Visible = false;

		}
	}








	private void _on_open_light_button_pressed()
	{

		if (PuzzlesCloseInstances.i.lightPuzzlNode.Visible == false)
		{
			
			if (PuzzlesData.i.isLightPuzzleSolved == false)
			{
				PuzzlesCloseInstances.i.lightPuzzlNode.Visible = true;


			}

		}
		else
		{
			PuzzlesCloseInstances.i.lightPuzzlNode.Visible = false;

		}

	}






}





