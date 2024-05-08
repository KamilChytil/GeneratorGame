using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class GameManager : Node2D
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public Timer timer;

	private float remainingTime = 180;

	private float timerWhenPuzzleHappend = 5;

	private Random random = new Random();


	[Export]
	public ProgressBar damegeProgressBar;

	[Export]
	public Label remainingTimeLabel;

	private int reaperDamage;

	private float[] howMuchPuzzleGenerateDamage = new float[7];

	[Export]
	public Timer timerForDamageGenerator;


	[Export]
	public Sprite2D backGroundChangeColor;
	private bool isIncreasing = true;
	private float elapsedTime = 0.0f;

	private bool isTimerStart = false;
	public override void _Ready()
	{

		timerWhenPuzzleHappend = 5;
		isTimerStart = false;

		PuzzlesData.i.tutorialShow.Visible = true;
		
	}


	private void _on_tutorial_paper_hidden()
	{
		if(isTimerStart == false)
		{
			timer.Start();
			timerForDamageGenerator.Start();
			isTimerStart = true;

		}
	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_timer_2_timeout()
	{
		GenerateDamageGeneratePerSecond();

		if(damegeProgressBar.Value >= 70f)
		{
			VarningBackGround();

		}

	}

	private void VarningBackGround()
	{
		if(isIncreasing == true)
		{
			elapsedTime += 0.2f;


		}
		else
		{
			elapsedTime -= 0.2f;

		}

		if (elapsedTime >= 1.0f)
		{
			isIncreasing = false;
		}
		else if (elapsedTime <= 0.0f)
		{
			isIncreasing = true; 
		}

		Color newColor = Color.FromHsv(0, elapsedTime/3, 1f); 

		backGroundChangeColor.Modulate = newColor;


		if (damegeProgressBar.Value < 60f)
		{
			backGroundChangeColor.Modulate = new Color(1f, 1f, 1f);

		}
	}



	public void _on_timer_timeout()
	{

		if (remainingTime > 0)
		{
			remainingTime -= 1;
			timerWhenPuzzleHappend -= 1;




			if (timerWhenPuzzleHappend <= 0)
			{
				SetWhenPuzzleHappend();


				int choosePuzzle;
				bool isPuzzleVisible;
				do
				{
					choosePuzzle = random.Next(0, PuzzlesData.i.buttonsOpenPuzzle.Count());

					isPuzzleVisible = PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible;
					if (!isPuzzleVisible)
					{
						if(choosePuzzle < 2 || choosePuzzle >= 4 && choosePuzzle <6)
						{
							PuzzlesData.i.buttonsOpenPuzzle[choosePuzzle].Visible = true;
							CreateCombination(choosePuzzle);
							//GD.Print(choosePuzzle + " was selected and made visible");
							StartDamageGenerate(choosePuzzle);

						}
						else if(choosePuzzle >= 2 && choosePuzzle <= 3 || choosePuzzle == 6)
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


			if (remainingTime == FiveLightAnimation.whenSpeedAnimation && FiveLightAnimation.whenSpeedAnimation >0)
			{
				FiveLightAnimation.SpeedAnimation();
				FiveLightAnimation.whenSpeedAnimation -= 40;
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
		PuzzlesData.i.winAndLoseNodes[0].Visible = true;
		//GetTree().Paused = true;
	}


	private void CreateCombination(int index)
	{
		switch(index)
		{
			case 0:
				MathPuzzle.iMathPuzzle.CreatePuzzleCombination();

				break;
			case 1:
				LightPuzzle.iLightPuzzle.CreatePuzzleCombination();
				LightOffOn.SetLightToWhite();
				break;
			case 4:
				Switches.iSwitches.CreatePuzzleCombination();

				break;
			case 5:
				BarPuzzle.i.CreatePuzzleCombination();

				break;

		}
	}



	private void StartDamageGenerate(int choosePuzzle)
	{
			
		howMuchPuzzleGenerateDamage[choosePuzzle] += 0.1f;
		damegeProgressBar.Value += 0.1f;

	}


	private void GenerateDamageGeneratePerSecond()
	{
		for (int i = 0; i < howMuchPuzzleGenerateDamage.Length; i++)
		{

			if(i < 2 || i >=4)
			{
				if (howMuchPuzzleGenerateDamage[i] > 0)
				{

					howMuchPuzzleGenerateDamage[i] += 0.2f;
					damegeProgressBar.Value += 0.2f;

					RemoveDamageGenerator(i);

				}

			}
			else if ( i >= 2 && i < 4)

			{
				if (howMuchPuzzleGenerateDamage[i] > 0)
				{

					howMuchPuzzleGenerateDamage[i] += 0.1f;
					damegeProgressBar.Value += 0.1f;

					RemoveDamageGenerator(i);

				}

			}
		}
		if (damegeProgressBar.Value <= 0f)
		{
			damegeProgressBar.Value = 0f;
		}

		if(damegeProgressBar.Value >= 100)
		{

			PuzzlesData.i.winAndLoseNodes[1].Visible = true;
			//GetTree().Paused = true;
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

	private void SetWhenPuzzleHappend()
	{
		if (remainingTime > 130)
		{
			timerWhenPuzzleHappend = 5;

		}
		else if(remainingTime < 130 && remainingTime > 70)
		{
			timerWhenPuzzleHappend = 4;

		}
		else if(remainingTime < 70 && remainingTime >25)
		{
			timerWhenPuzzleHappend = 3;

		}
		else
		{
			timerWhenPuzzleHappend = 2;
		}
	}


}








