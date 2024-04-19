using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node2D
{
	// Called when the node enters the scene tree for the first time.


	[Export]
	public Timer timer;

	private float remainingTime = 300;

	private float timerWhenPuzzleHappend = 5;

	private Random random = new Random();

	private List<bool> arrayPuzzlesSolved = new List<bool>();
	public override void _Ready()
	{

		arrayPuzzlesSolved.Add(PuzzlesData.i.isLightPuzzleSolved);
		arrayPuzzlesSolved.Add(PuzzlesData.i.isMathPuzzleSolved);

		timer.Start();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_timer_timeout()
	{

		if (remainingTime > 0)
		{
			remainingTime -= 1;
			timerWhenPuzzleHappend -= 1;

			if (timerWhenPuzzleHappend <= 0)
			{
				timerWhenPuzzleHappend = 5;

				int choosePuzzle;
				int allPuzzleOn = 0;

				do
				{
					

					choosePuzzle = random.Next(0, arrayPuzzlesSolved.Count);

					if (!PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible)
					{
						PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible = true;
						//CreateCombination(choosePuzzle);

						GD.Print(choosePuzzle + "choosePuzzle");
					}

					for (int i = 0; i < arrayPuzzlesSolved.Count; i++)
					{
						if (PuzzlesData.i.buttonsOpenPuzzle[i].Visible)
						{
							allPuzzleOn++;
							GD.Print(allPuzzleOn + "allPuzzleOn");
						}
					}

					if (allPuzzleOn == arrayPuzzlesSolved.Count)
					{
						GD.Print("Break");
						break;
					}
				} while (PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible == false);



			}

			UpdateTimerDisplay();

			if (remainingTime <= 0)
			{
				OnTimerEnd();
			}
		}
	}

	private void UpdateTimerDisplay()
	{

		GD.Print("RemainingTIme: " + remainingTime);
	}

	private void OnTimerEnd()
	{
		GD.Print("No TIme!");
	}


	private void CreateCombination(int index)
	{
		switch(index)
		{
			case 0:
				MathPuzzle.iMathPuzzle.CreatePuzzleCombination();
				break;
			case 1:
				break;
		}
	}

}

