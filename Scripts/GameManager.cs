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

	private int[] howMuchPuzzleGenerateDamage = new int[2];

	public override void _Ready()
	{
		timerWhenPuzzleHappend = 5;

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
						StartDamageGenerate(choosePuzzle);
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

			GenerateDamageGeneratePerSecond();

			if (remainingTime == FiveLightAnimation.whenSpeedAnimation && FiveLightAnimation.whenSpeedAnimation >0)
			{
				FiveLightAnimation.SpeedAnimation();
				FiveLightAnimation.whenSpeedAnimation -= 60;
			}

			if(damegeProgressBar.Value  >= 0)
			{
				//damegeProgressBar.Value += PuzzlesData.i.damageGeneratorPerSec;
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



	private void StartDamageGenerate(int choosePuzzle)
	{
			if (choosePuzzle < 3)
			{
				howMuchPuzzleGenerateDamage[choosePuzzle] += 1;

			}
		
	}


	private void GenerateDamageGeneratePerSecond()
	{
		for (int i = 0; i < howMuchPuzzleGenerateDamage.Length; i++)
		{
			if (howMuchPuzzleGenerateDamage[i] > 0)
			{

				howMuchPuzzleGenerateDamage[i] += 2;
				//GD.Print("2222222howMuchPuzzleGenerateDamage[i]" + howMuchPuzzleGenerateDamage[i]);
				//3 5 7 9 
				damegeProgressBar.Value += 3;

				RemoveDamageGenerator(i);

			}


		}
	}


	private void RemoveDamageGenerator(int i)
	{
		if (PuzzlesData.i.buttonsOpenPuzzle[i].Visible == false)
		{
			GD.Print("REmovehowMuchPuzzleGenerateDamage[i]" + howMuchPuzzleGenerateDamage[i]);

			damegeProgressBar.Value -= howMuchPuzzleGenerateDamage[i];
			howMuchPuzzleGenerateDamage[i] -= howMuchPuzzleGenerateDamage[i];


		}
	}


}




