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

	private int[] howMuchPuzzleGenerateDamage = new int[6];

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
				bool isPuzzleVisible;
				do
				{
					choosePuzzle = random.Next(0, PuzzlesData.i.buttonsOpenPuzzle.Count());

					isPuzzleVisible = PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible;
					if (!isPuzzleVisible)
					{
						if(choosePuzzle < 2 || choosePuzzle >= 4)
						{
							PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible = true;
							CreateCombination(choosePuzzle);
							//GD.Print(choosePuzzle + " was selected and made visible");
							StartDamageGenerate(choosePuzzle);

						}
						else if(choosePuzzle >= 2 && choosePuzzle <= 3)
						{

                            PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible = true;
                            StartDamageGenerate(choosePuzzle);

                        }
                    }

					int allPuzzleOn = 0;
					for (int i = 0; i < PuzzlesData.i.buttonsOpenPuzzle.Count(); i++)
					{
						if (PuzzlesData.i.buttonsOpenPuzzle[i].Visible)
						{
							allPuzzleOn++;
						}
					}

					if(allPuzzleOn == PuzzlesData.i.buttonsOpenPuzzle.Count())
					{

						break;
					}

				} while (isPuzzleVisible);
				


			}

			UpdateTimerDisplay();

			GenerateDamageGeneratePerSecond();

			if (remainingTime == FiveLightAnimation.whenSpeedAnimation && FiveLightAnimation.whenSpeedAnimation >0)
			{
				FiveLightAnimation.SpeedAnimation();
				FiveLightAnimation.whenSpeedAnimation -= 60;
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
			case 4:
				Switches.iSwitches.CreatePuzzleCombination();
                PuzzlesData.i.damageGeneratorPerSec += 2;

                break;
            case 5:
                BarPuzzle.i.CreatePuzzleCombination();
                PuzzlesData.i.damageGeneratorPerSec += 3;

                break;

        }
	}



	private void StartDamageGenerate(int choosePuzzle)
	{
			
		howMuchPuzzleGenerateDamage[choosePuzzle] += 1;
		damegeProgressBar.Value += 1;

    }


    private void GenerateDamageGeneratePerSecond()
	{
		for (int i = 0; i < howMuchPuzzleGenerateDamage.Length; i++)
		{

			if(i < 2 || i >=4)
			{
				if (howMuchPuzzleGenerateDamage[i] > 0)
				{

					howMuchPuzzleGenerateDamage[i] += 2;
					damegeProgressBar.Value += 2;

					RemoveDamageGenerator(i);

				}

			}
			else if ( i >= 2 && i < 4)

            {
                if (howMuchPuzzleGenerateDamage[i] > 0)
                {

                    howMuchPuzzleGenerateDamage[i] += 1;
                    damegeProgressBar.Value += 1;

                    RemoveDamageGenerator(i);

                }

            }
        }
	}


	private void RemoveDamageGenerator(int i)
	{
		if (PuzzlesData.i.buttonsOpenPuzzle[i].Visible == false)
		{

			damegeProgressBar.Value -= howMuchPuzzleGenerateDamage[i];
			howMuchPuzzleGenerateDamage[i] -= howMuchPuzzleGenerateDamage[i];


		}
	}


}




