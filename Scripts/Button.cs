using Godot;
using System;
using System.Reflection.Metadata;

public partial class Button : Node2D
{

	public override void _Ready()
	{


    }
	private void _on_button_pressed()
	{
		if(PuzzlesCloseInstances.iPuzzlesCloseInstances.mathPuzzleNode.Visible == false)
		{
			PuzzlesCloseInstances.iPuzzlesCloseInstances.mathPuzzleNode.Visible = true;
			if(PuzzlesData.iPuzzleData.isMathCombinationGenerate == false)
			{
					
				
				MathPuzzle.iMathPuzzle.CreatePuzzleCombination();

			}

		}
		else
		{
			PuzzlesCloseInstances.iPuzzlesCloseInstances.mathPuzzleNode.Visible = false;

		}
	}

	private void _on_button_3_pressed()
	{
		//if (node2d2.Visible == false)
		//{
		//	node2d2.Visible = true;


		//}
		//else
		//{
		//	node2d2.Visible = false;

		//}
	}


}



