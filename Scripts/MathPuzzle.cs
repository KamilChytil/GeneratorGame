using Godot;
using System;
using System.Collections.Generic;

public partial class MathPuzzle :  Puzzle
{
	// Called when the node enters the scene tree for the first time.

	public static MathPuzzle iMathPuzzle;

	private Random random = new Random();

	[Export]
	public Label textMathPuzzle;




	public override void _Ready()
	{
		iMathPuzzle = this;
	}


	public override void CreatePuzzleCombination()
	{
		GenerateNumber(ref PuzzlesData.i.mathNumber1);
		GenerateNumber(ref PuzzlesData.i.mathNumber2);
		GenerateNumber(ref PuzzlesData.i.mathNumber3);

		do
		{
			GenerateNumber(ref PuzzlesData.i.mathNumber1);
			GenerateNumber(ref PuzzlesData.i.mathNumber2);
			GenerateNumber(ref PuzzlesData.i.mathNumber3);

			float tempResult = (float)(PuzzlesData.i.mathNumber1 - PuzzlesData.i.mathNumber3) / PuzzlesData.i.mathNumber2;
			PuzzlesData.i.mathNumberPlayerFound = tempResult;
			//GD.Print("PuzzlesData.i.mathNumberPlayerFound:" + PuzzlesData.i.mathNumberPlayerFound);

		} while (PuzzlesData.i.mathNumber1 <= PuzzlesData.i.mathNumber3 || PuzzlesData.i.mathNumber2 > 5 || (PuzzlesData.i.mathNumber1 - PuzzlesData.i.mathNumber3) <= PuzzlesData.i.mathNumber2 || PuzzlesData.i.mathNumberPlayerFound % 1 != 0 || PuzzlesData.i.mathNumberPlayerFound > 4);
				
		textMathPuzzle.Text = PuzzlesData.i.mathNumber1.ToString() + " - ? * " + PuzzlesData.i.mathNumber2.ToString() + " = " + PuzzlesData.i.mathNumber3.ToString();
		PuzzlesData.i.isMathCombinationGenerate = true;

	}



	private void GenerateNumber(ref int number)
	{

		number = random.Next(1, 10);

	}


	private void _on_button_math_2_pressed()
	{
		SolvePuzzleCombination(2);
	}


	private void _on_button_math_4_pressed()
	{
		SolvePuzzleCombination(4);
	}


	private void _on_button_math_1_pressed()
	{
		SolvePuzzleCombination(1);
	}


	private void _on_button_math_3_pressed()
	{
		SolvePuzzleCombination(3);
	}



	public override void SolvePuzzleCombination(int playerPickNumber)
	{
		if (PuzzlesData.i.mathNumberPlayerFound == playerPickNumber)
		{
			PuzzlesData.i.isMathCombinationGenerate = false;
			PuzzlesCloseInstances.i.mathPuzzleNode.Visible = false;
			PuzzlesData.i.isMathPuzzleSolved = true;
			PuzzlesData.i.buttonsOpenPuzzle[0].Visible = false;
			
		}
		else
		{
			PuzzlesData.i.isMathCombinationGenerate = true;


			PuzzlesCloseInstances.i.mathPuzzleNode.Visible = false;

		}

	}


}




