using Godot;
using System;
using System.ComponentModel.Design;
using System.Linq;

public partial class Switches : Puzzle
{
	// Called when the node enters the scene tree for the first time.

	private AnimatedSprite2D[] switchesAnim;

	private Random random = new Random();

	[Export]
	public BaseButton[] buttonSwitches;

	private int firstSwitch;
	private int secondSwitch;


	public static Switches iSwitches;

	private int allSwitchUp;
	public override void _Ready()
	{
		allSwitchUp = 0;
		iSwitches = this;

		GenereteStateForSwitch();
		var animationNode = GetChildren();
		if (animationNode != null)
		{
			var sprites = animationNode.OfType<AnimatedSprite2D>().ToArray();
			switchesAnim = sprites;

		}
		else
		{
			GD.PrintErr("Grafika/Animation node was not found.");
		}
		for (int i = 0; i < switchesAnim.Length; i++)
		{
			buttonSwitches[i].Disabled = true;
			GD.PrintErr(PuzzlesData.i.isLeversUp);

           if (PuzzlesData.i.isLeversUp == true)
			{
				switchesAnim[i].SetFrameAndProgress(0, 0f);
			}
			else
			{
				switchesAnim[i].SetFrameAndProgress(1, 0f);

			}
		}

	}



	public  override void CreatePuzzleCombination()
	{
		firstSwitch = random.Next(0, 3);
		do
		{
			secondSwitch = random.Next(0,3);

		}while(firstSwitch == secondSwitch);
		GD.Print("firstSwitch "+ firstSwitch);
		GD.Print("secondSwitch " + secondSwitch);

		if (PuzzlesData.i.isLeversUp == true)
		{
			switchesAnim[firstSwitch].SetFrameAndProgress(1, 0f);
			switchesAnim[firstSwitch].SetFrameAndProgress(1, 0f);



		}
		else
		{
			switchesAnim[firstSwitch].SetFrameAndProgress(0, 0f);
			switchesAnim[secondSwitch].SetFrameAndProgress(0, 0f);
		}

		buttonSwitches[firstSwitch].Disabled = false;
		buttonSwitches[secondSwitch].Disabled = false;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}



	private void _on_switch_1_button_button_down()
	{
		if (switchesAnim[0].Frame == 1)
		{
			switchesAnim[0].SetFrameAndProgress(0, 0f);
			SolvePuzzleCombination(0);
			buttonSwitches[0].Disabled = true;

		}
		else
		{
			switchesAnim[0].SetFrameAndProgress(1, 0f);
			SolvePuzzleCombination(0);
			buttonSwitches[0].Disabled = true;

		}
	}


	private void _on_switch_2_button_button_down()
	{
		if (switchesAnim[1].Frame == 1)
		{
			switchesAnim[1].SetFrameAndProgress(0, 0f);
			SolvePuzzleCombination(1);
			buttonSwitches[1].Disabled = true;

		}
		else
		{
			switchesAnim[1].SetFrameAndProgress(1, 0f);
			SolvePuzzleCombination(1);
			buttonSwitches[1].Disabled = true;

		}
	}


	private void _on_switch_3_button_button_down()
	{
		if (switchesAnim[2].Frame == 1)
		{
			switchesAnim[2].SetFrameAndProgress(0, 0f);
			SolvePuzzleCombination(2);
			buttonSwitches[2].Disabled = true;

		}
		else
		{
			switchesAnim[2].SetFrameAndProgress(1, 0f);
			SolvePuzzleCombination(2);
			buttonSwitches[2].Disabled = true;

		}
	}



	private void GenereteStateForSwitch()
	{
		int numForLeverState = random.Next(0, 2);

		if (numForLeverState == 0)
		{
			PuzzlesData.i.isLeversUp = false;

		}
		else
		{
			PuzzlesData.i.isLeversUp = true;

		}
	}


	public override void SolvePuzzleCombination(int playerInput)
	{

		if(playerInput == firstSwitch || playerInput == secondSwitch)
		{
			allSwitchUp++;
			if(allSwitchUp == 2)
			{
				PuzzlesData.i.buttonsOpenPuzzle[4].Visible = false;
				allSwitchUp = 0;
			}

		}

	}

}






