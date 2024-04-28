using Godot;
using System;

public partial class ErrorWinMac : Node
{
	private void _on_win_button_pressed()
	{
		PuzzlesData.i.buttonsOpenPuzzle[2].Visible = false;
	}


	private void _on_mac_button_pressed()
	{
		PuzzlesData.i.buttonsOpenPuzzle[3].Visible = false;

	}




}



