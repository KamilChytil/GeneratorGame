using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class LightPuzzle : Puzzle
{

	[Export]
	public Sprite2D[] switchLight = new Sprite2D[5];
	
	[Export]
	public Node2D[] buttonsWorkWithLight = new Node2D[5];

	// Called when the node enters the scene tree for the first time.

	private Random random = new Random();

	public List<int> lightCombination;

	public List<int> playerInputLightCombinationToCompare = new List<int>();


	public override void _Ready()
	{
		playerInputLightCombinationToCompare.Clear();

		for (int i = 0; i < switchLight.Length; i++)
		{
			switchLight[i].Modulate = new Color(1, 1, 1);
		}
	}



	private void _on_light_button_1_pressed()
	{
		if (IsWhite(switchLight[0]))
		{
			ClickOnLightButton(0);


		}
	}


	private void _on_light_button_2_pressed()
	{
		ClickOnLightButton(1);
	}


	private void _on_light_button_3_pressed()
	{
		ClickOnLightButton(2);
	}


	private void _on_light_button_4_pressed()
	{
		ClickOnLightButton(3);
	}


	private void _on_light_button_5_pressed()
	{
		ClickOnLightButton(4);
	}



	private void ClickOnLightButton(int inputNum)
	{

		ChangeColorToYellow(switchLight[inputNum]);

	}


	private void ChangeColorToYellow(Sprite2D light)
	{
		light.Modulate = new Color(1, 1, 0);


	}

	private void ChangeColorToWhite(Sprite2D light)
	{
		light.Modulate = new Color(1, 1, 1);
	}



	private bool IsWhite(Sprite2D sprite)
	{
		return sprite.Modulate.R == 1 && sprite.Modulate.G == 1 && sprite.Modulate.B == 1;
	}

	public override void CreatePuzzleCombination()
	{
		if(PuzzlesData.i.isLeversUp == false)
		{

			lightCombination = new List<int> { 5, 3, 2, 4, 1 };

		}
		else
		{
			lightCombination = new List<int> { 2, 1, 5, 3, 4 };

		}
	}


	public override void SolvePuzzleCombination(int playerInput)
	{
		buttonsWorkWithLight[playerInput].Visible = false;
		playerInputLightCombinationToCompare.Add(playerInput);
		if (playerInputLightCombinationToCompare.Count == 5)
		{
			if(lightCombination.SequenceEqual(playerInputLightCombinationToCompare))
			{
				PuzzlesData.i.isLightPuzzleSolved = true;
				playerInputLightCombinationToCompare.Clear();
			}
			else
			{
				playerInputLightCombinationToCompare.Clear();
			}

		}

	}



}





