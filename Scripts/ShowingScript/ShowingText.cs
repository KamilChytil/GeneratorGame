using Godot;
using System;

public partial class ShowingText : Node
{

	[Export]
	public Label monitorTextShowing;
	[Export]
	public Timer panelTextTimer;

	[Export]
	public string[] textShowOnMonitor;

	private int printTextIndex = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		panelTextTimer.Start();
	}

	private void _on_timer_timeout()
	{

			monitorTextShowing.Text += textShowOnMonitor[printTextIndex] + "\n";
			printTextIndex++;
			if (printTextIndex >= textShowOnMonitor.Length)
			{
				printTextIndex = 0;
				monitorTextShowing.Text = "";
			}
		
	}



}





