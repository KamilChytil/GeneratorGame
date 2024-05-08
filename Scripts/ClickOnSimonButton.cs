using Godot;
using System;
using System.Collections.Generic;

public partial class ClickOnSimonButton : Puzzle
{
	// Called when the node enters the scene tree for the first time.

	private List<TextureButton> textureButtonList = new List<TextureButton>();

	private int presedCount = 0;

	public override void _Ready()
	{
		int childCount = GetChildCount();
		for(int i = 0; i < childCount; i++)
		{

			if (GetChild(i) is TextureButton button)
			{
				textureButtonList.Add(button);
				button.Pressed += () => DisableTextureButtons(button); 
			}

		}

		//      var button = new Button();
		//button.Text = "Click me";
		//textureButton.Pressed += ButtonPressed;
		//AddChild(textureButton);


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void DisableTextureButtons(TextureButton pressedButton)
	{
		for (int i = 0; i<textureButtonList.Count;i++)
		{
			if (pressedButton.Name == textureButtonList[i].Name)
			{
				textureButtonList[i].Disabled = true;
				SolvePuzzleCombination(1);

			}
		}
	}


	public override void SolvePuzzleCombination(int playerInput)
	{
		presedCount += playerInput;
		if( presedCount >= textureButtonList.Count)
		{
			PuzzlesShowInstances.i.simonPuzzleNode.Visible = false;
			PuzzlesData.i.buttonsOpenPuzzle[6].Visible = false;
			presedCount = 0;

			for (int i = 0; i < textureButtonList.Count; i++)
			{
			  
				textureButtonList[i].Disabled = false;

			}
		}
	}

}
