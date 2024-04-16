using Godot;
using System;

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
		GenerateNumber(ref PuzzlesData.iPuzzleData.mathNumber1);
		GenerateNumber(ref PuzzlesData.iPuzzleData.mathNumber2);
		GenerateNumber(ref PuzzlesData.iPuzzleData.mathNumber3);

		do
		{
			GenerateNumber(ref PuzzlesData.iPuzzleData.mathNumber1);
			GenerateNumber(ref PuzzlesData.iPuzzleData.mathNumber2);
			GenerateNumber(ref PuzzlesData.iPuzzleData.mathNumber3);

			float tempResult = (float)(PuzzlesData.iPuzzleData.mathNumber1 - PuzzlesData.iPuzzleData.mathNumber3) / PuzzlesData.iPuzzleData.mathNumber2;
            PuzzlesData.iPuzzleData.mathNumberPlayerFound = tempResult;
			GD.Print("num1:" + PuzzlesData.iPuzzleData.mathNumber1);
			GD.Print("num2:" + PuzzlesData.iPuzzleData.mathNumber2);
			GD.Print("num4:" + PuzzlesData.iPuzzleData.mathNumber3);
			GD.Print("PuzzlesData.iPuzzleData.mathNumberPlayerFound:" + PuzzlesData.iPuzzleData.mathNumberPlayerFound);
		} while (PuzzlesData.iPuzzleData.mathNumber1 <= PuzzlesData.iPuzzleData.mathNumber3 || PuzzlesData.iPuzzleData.mathNumber2 > 5 || (PuzzlesData.iPuzzleData.mathNumber1 - PuzzlesData.iPuzzleData.mathNumber3) <= PuzzlesData.iPuzzleData.mathNumber2 || PuzzlesData.iPuzzleData.mathNumberPlayerFound % 1 != 0);

		textMathPuzzle.Text = PuzzlesData.iPuzzleData.mathNumber1.ToString() + " - ? * " + PuzzlesData.iPuzzleData.mathNumber2.ToString() + " = " + PuzzlesData.iPuzzleData.mathNumber3.ToString();
		PuzzlesData.iPuzzleData.isMathCombinationGenerate = true;

	}

	private void GenerateNumber(ref int number)
	{

		number = random.Next(1, 10);

	}


	private void _on_button_math_2_pressed()
	{
		CheckMathCombination(2);
	}


	private void _on_button_math_4_pressed()
	{
		CheckMathCombination(4);
	}


	private void _on_button_math_1_pressed()
	{
		CheckMathCombination(1);
	}


	private void _on_button_math_3_pressed()
	{
		CheckMathCombination(3);
	}


	private void CheckMathCombination(int playerPickNumber)
	{
		if (PuzzlesData.iPuzzleData.mathNumberPlayerFound == playerPickNumber)
		{
			PuzzlesData.iPuzzleData.isMathCombinationGenerate = false;
			PuzzlesCloseInstances.iPuzzlesCloseInstances.mathPuzzleNode.Visible = false;

		}
		else
		{
			PuzzlesData.iPuzzleData.isMathCombinationGenerate = true;


            PuzzlesCloseInstances.iPuzzlesCloseInstances.mathPuzzleNode.Visible = false;

		}

	}


}




