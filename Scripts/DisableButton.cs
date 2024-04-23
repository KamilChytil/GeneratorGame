using Godot;
using System;

public partial class DisableButton : Node
{


	private int disableTime = 3;


	[Export]
	public Timer timer;


	[Export]
	public Label timerCountDown;


	[Export]
	public BaseButton buttonOpenDisable;

	private bool buttonWasEnabled = true;

	[Export]
	public Node2D disablebuttonNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		disableTime = 3;
		timerCountDown.Text = "Puzzle Lock:" + disableTime.ToString();
		buttonOpenDisable.Disabled = false;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{


	}
	private void _on_disable_math_button_main_visibility_changed()
	{
		if (buttonOpenDisable.Disabled == false && buttonWasEnabled == true)
		{
			timerCountDown.Visible = true;

			timer.Start();
			buttonOpenDisable.Disabled = true;
			buttonWasEnabled = false;

		}
		else if (buttonOpenDisable.Disabled == true && !buttonWasEnabled)
		{
			buttonOpenDisable.Disabled = false;
			buttonWasEnabled = true;
		}

	}


	private void _on_timer_timeout()
	{

		if (disableTime > 1)
		{
			disableTime -= 1;
			timerCountDown.Text = "Puzzle Lock:"+ disableTime.ToString();


		}
		else
		{
			disableTime = 3;

			timerCountDown.Text = "Puzzle Lock:" + disableTime.ToString();
			timer.Stop();
			disablebuttonNode.Visible = false;

		}
	}

}



