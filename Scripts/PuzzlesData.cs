using Godot;
using System;

public partial class PuzzlesData : Node
{
	public static PuzzlesData iPuzzleData;


    public int mathNumber1;
    public int mathNumber2;
    public int mathNumber3;

    public float mathNumberPlayerFound;
    public bool isMathCombinationGenerate = false;

    public override void _Ready()
	{
		iPuzzleData = this;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
