using Godot;
using System;

public partial class PuzzlesCloseInstances : Node2D
{

    public static PuzzlesCloseInstances i;



    [Export]
    public Node2D mathPuzzleNode;
    [Export]
    public Node2D lightPuzzlNode;


    public override void _Ready()
	{
        i = this;
        SetVisibleOff();
    }

    public void SetVisibleOff()
    {
        mathPuzzleNode.Visible = false;
        lightPuzzlNode.Visible = false;
    }


}
