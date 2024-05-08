using Godot;
using System;

public partial class WinLoseScript : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_win_button_click_pressed()
	{
		GetTree().Quit();
	}


	private void _on_lose_button_click_pressed()
	{
		GetTree().ReloadCurrentScene();
	}

	private void _on_lose_button_click_2_pressed()
	{
		GetTree().Quit();
	}


}






