using Godot;
using System;
using System.Collections.Generic;

public partial class PuzzlesData : Node
{
	public static PuzzlesData i;


	public int[] mathNumber  = new int[3];

    public int mathNumber1;
    public int mathNumber2;
    public int mathNumber3;

    public float mathNumberPlayerFound;


    public bool isMathCombinationGenerate = false;

    public bool[] isPuzzleGenerate = new bool[2];

	public bool isLeversUp = false;

    [Export]
    public Node2D[] buttonsOpenPuzzle = new Node2D[2];

    [Export]
    public Node2D[] disableButtons = new Node2D[2];

    public int damageGeneratorPerSec;
    public override void _Ready()
	{
		i = this;

        for (int i = 0; i < buttonsOpenPuzzle.Length; i++)
        {
            buttonsOpenPuzzle[i].Visible = false;
            isPuzzleGenerate[i] = false;
        }
    }

}
