using Godot;
using System;

public partial class PuzzlesCloseInstances : Node2D
{

    public static PuzzlesCloseInstances iPuzzlesCloseInstances;

    [Export]
    public Node2D mathPuzzleNode;
    [Export]
    public Node2D node2d2;

    public override void _Ready()
	{
        iPuzzlesCloseInstances = this;
        SetVisibleOff();
    }

    public void SetVisibleOff()
    {
        mathPuzzleNode.Visible = false;
        node2d2.Visible = false;

    }


}
