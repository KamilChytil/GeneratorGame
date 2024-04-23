using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class GameManager : Node2D
{
	// Called when the node enters the scene tree for the first time.


	[Export]
	public Timer timer;

	private float remainingTime = 300;

	private float timerWhenPuzzleHappend = 5;

	private Random random = new Random();


	[Export]
	public ProgressBar damegeProgressBar;

	[Export]
	public Label remainingTimeLabel;

	private int reaperDamage;
	public override void _Ready()
	{

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
				bool isPuzzleVisible;
				do
				{
					choosePuzzle = random.Next(0, PuzzlesData.i.buttonsOpenPuzzle.Count());

					isPuzzleVisible = PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible;
					if (!isPuzzleVisible)
					{
						PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible = true;
						CreateCombination(choosePuzzle);
						GD.Print(choosePuzzle + " was selected and made visible");
					}

					allPuzzleOn = 0;
					for (int i = 0; i < PuzzlesData.i.buttonsOpenPuzzle.Count(); i++)
					{
						if (PuzzlesData.i.buttonsOpenPuzzle[i].Visible)
						{
							allPuzzleOn++;
						}
					}

					if(allPuzzleOn == PuzzlesData.i.buttonsOpenPuzzle.Count())
					{
						GD.Print("BREAK");

						break;
					}
					GD.Print(allPuzzleOn + " visible puzzles");

				} while (isPuzzleVisible);


			}

			UpdateTimerDisplay();

			if(remainingTime == FiveLightAnimation.whenSpeedAnimation && FiveLightAnimation.whenSpeedAnimation >0)
			{
				FiveLightAnimation.SpeedAnimation();
				FiveLightAnimation.whenSpeedAnimation -= 60;
			}

			if(damegeProgressBar.Value  >= 0)
			{
				damegeProgressBar.Value += PuzzlesData.i.damageGeneratorPerSec;
				//reaperDamage += PuzzlesData.i.damageGeneratorPerSec;

			}
			else if (damegeProgressBar.Value < 0)
			{
				damegeProgressBar.Value = 0;
			}
		

			



			if (remainingTime <= 0)
			{
				OnTimerEnd();
			}
		}
	}

	private void UpdateTimerDisplay()
	{
		int minutes = (int)remainingTime / 60;
		int seconds = (int)remainingTime % 60;
		string formattedTime = $"{minutes}:{seconds:D2}";

		remainingTimeLabel.Text = formattedTime;

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
				PuzzlesData.i.damageGeneratorPerSec += 3;

				break;
			case 1:
				LightPuzzle.iLightPuzzle.CreatePuzzleCombination();
				PuzzlesData.i.damageGeneratorPerSec += 2;
				LightOffOn.SetLightToWhite();
				break;
		}
	}


	public void UnClickebleOpenButton()
	{


	}

}

