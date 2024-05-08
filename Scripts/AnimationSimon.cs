using Godot;
using System;

public partial class AnimationSimon : Node
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public AnimatedSprite2D simonAnimation;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_animated_sprite_2d_animation_looped()
	{
		if (PuzzlesData.i.buttonsOpenPuzzle[6].Visible==true)
		{
			GD.Print("AnimationError");
			simonAnimation.SetFrameAndProgress(0, 1f);
			simonAnimation.Stop();
		}
	}

	private void _on_open_simon_button_hidden()
	{
		if (PuzzlesData.i.buttonsOpenPuzzle[6].Visible == false)
		{
			simonAnimation.Play();
		}
	}
}







