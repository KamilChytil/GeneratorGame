using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class LightPuzzle : Puzzle
{
	public static LightPuzzle iLightPuzzle;


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
		iLightPuzzle = this;

		playerInputLightCombinationToCompare.Clear();

		for (int i = 0; i < switchLight.Length; i++)
		{
			switchLight[i].Modulate = new Color(1, 1, 1);
		}
	}



	private void _on_light_button_1_pressed()
	{
		ClickOnLightButton(0);
		SolvePuzzleCombination(0);
	}


	private void _on_light_button_2_pressed()
	{
		ClickOnLightButton(1);
		SolvePuzzleCombination(1);

	}


	private void _on_light_button_3_pressed()
	{
		ClickOnLightButton(2);
		SolvePuzzleCombination(2);

	}


	private void _on_light_button_4_pressed()
	{
		ClickOnLightButton(3);
		SolvePuzzleCombination(3);

	}


	private void _on_light_button_5_pressed()
	{
		ClickOnLightButton(4);
		SolvePuzzleCombination(4);

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

		for (int i = 0; i < switchLight.Length;i++)
		{
			ChangeColorToWhite(switchLight[i]);
			buttonsWorkWithLight[i].Visible = true;
		}

		if (PuzzlesData.i.isLeversUp == false)
		{

			lightCombination = new List<int> { 4, 2, 1, 3, 0 };

		}
		else
		{
			lightCombination = new List<int> { 1, 0, 4, 2, 3 };

		}

	}


	public override void SolvePuzzleCombination(int playerInput)
	{
		buttonsWorkWithLight[playerInput].Visible = false;

		playerInputLightCombinationToCompare.Add(playerInput);

		for (int i = 0;i<playerInputLightCombinationToCompare.Count;i++)
		{
			GD.Print(playerInputLightCombinationToCompare[i]);
		}

		if (playerInputLightCombinationToCompare.Count == 5)
		{
			if(lightCombination.SequenceEqual(playerInputLightCombinationToCompare))
			{
				playerInputLightCombinationToCompare.Clear();
				PuzzlesData.i.buttonsOpenPuzzle[1].Visible = false;
				PuzzlesShowInstances.i.lightPuzzlNode.Visible = false;
				LightOffOn.SetLightToYellow();

			}
			else
			{
				playerInputLightCombinationToCompare.Clear();
				PuzzlesData.i.disableButtons[1].Visible = true;
				PuzzlesShowInstances.i.lightPuzzlNode.Visible = false;
				for (int i = 0; i < switchLight.Length; i++)
				{
					buttonsWorkWithLight[i].Visible = true;

					switchLight[i].Modulate = new Color(1, 1, 1);
				}

			}

		}

	}



}





