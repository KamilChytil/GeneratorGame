using Godot;
using System;
using System.Linq;

public partial class ShowingText : Node
{

	[Export]
	public Label monitorTextShowing;
	[Export]
	public Timer panelTextTimer;

	[Export]
	public string[] textShowOnMonitor;

	private int printTextIndex = 0;

	[Export]
	public Node2D visibilytyOfOpenButton;

	[Export]
	public string[] showErrorText;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		panelTextTimer.Start();
	}

	private void _on_timer_timeout()
	{
		if(visibilytyOfOpenButton.Visible == false)
		{
			PrintTextOnPanel(textShowOnMonitor, 0, 1);


        }
		else
		{
			PrintTextOnPanel(showErrorText, 1, 0);

        }
		
	}


	private void PrintTextOnPanel(string[] showingText,int numForColor1,int numForColor2)
	{
		
        monitorTextShowing.Text += showingText[printTextIndex] + "\n";
        monitorTextShowing.Modulate = new Color(numForColor1, numForColor2, 0);
		
        printTextIndex++;
        if (printTextIndex >= showingText.Length)
        {
            printTextIndex = 0;
            monitorTextShowing.Text = "";
        }
    }

}





