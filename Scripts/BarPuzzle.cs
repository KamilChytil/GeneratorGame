using Godot;
using System;

public partial class BarPuzzle : Puzzle
{

	private int[] possibleValues = { 20,30, 40, 60, 70,80 };
	private Random random = new Random();

	[Export]
	public ProgressBar[] inSceneBars = new ProgressBar[5];

	public static BarPuzzle i;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		i = this;
		SetProgressBarIntoNormal();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public override void CreatePuzzleCombination()
	{
		for(int i = 0;i< inSceneBars.Length;i++)
		{
			int randomIndex = random.Next(0, possibleValues.Length);
			inSceneBars[i].Value = possibleValues[randomIndex];
			PuzzlesData.i.zoomProgressBars[i].Value = possibleValues[randomIndex];
		}
	}


	private void SetProgressBarIntoNormal()
	{

		for(int i = 0; i < inSceneBars.Length;i++)
		{
			inSceneBars[i].Value = 50;
			PuzzlesData.i.zoomProgressBars[i].Value = 50;
		}

	}

	private void IncreaseProgressBar(int index)
	{
		PuzzlesData.i.zoomProgressBars[index].Value += 10;

	}

	private void DecreaseProgressBar(int index)
	{
		PuzzlesData.i.zoomProgressBars[index].Value -= 10;

	}

	private void _on_texture_button_1_up_pressed()
	{
		IncreaseProgressBar(0);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_1_down_pressed()
	{
		DecreaseProgressBar(0);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_2_up_pressed()
	{
		IncreaseProgressBar(1);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_2_down_pressed()
	{
		DecreaseProgressBar(1);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_3_up_pressed()
	{
		IncreaseProgressBar(2);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_3_down_pressed()
	{
		DecreaseProgressBar(2);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_4_up_pressed()
	{
		IncreaseProgressBar(3);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_4_down_pressed()
	{
		DecreaseProgressBar(3);
		SolvePuzzleCombination(3);

	}


	private void _on_texture_button_5_up_pressed()
	{
		IncreaseProgressBar(4);
		SolvePuzzleCombination(4);

	}


	private void _on_texture_button_5_down_pressed()
	{
		DecreaseProgressBar(4);
		SolvePuzzleCombination(4);

	}



	public override void SolvePuzzleCombination(int playerInput)
	{
		int countHowMuchCorrect = 0;
		for(int i = 0; i < inSceneBars.Length;i++ )
		{
			if(PuzzlesData.i.zoomProgressBars[i].Value == 50)
			{
				countHowMuchCorrect++;
				if(countHowMuchCorrect == 5)
				{
					PuzzlesShowInstances.i.progressBarNode.Visible = false;
					PuzzlesData.i.buttonsOpenPuzzle[5].Visible = false;
					SetProgressBarIntoNormal();
				}
			}			
		}

	}

}




