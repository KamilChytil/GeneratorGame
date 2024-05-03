using Godot;
using System;

public partial class PuzzlesShowInstances : Node2D
{

	public static PuzzlesShowInstances i;



	[Export]
	public Node2D mathPuzzleNode;
	[Export]
	public Node2D lightPuzzlNode;
	[Export]
	public Node2D progressBarNode;
	public override void _Ready()
	{
		i = this;
		SetVisibleOff();
	}

	public void SetVisibleOff()
	{
		mathPuzzleNode.Visible = false;
		lightPuzzlNode.Visible = false;
		progressBarNode.Visible = false;
	}


}
