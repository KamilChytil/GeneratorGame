using Godot;
using System;
using System.Linq;

public partial class FiveLightAnimation : Node2D
{
	// Called when the node enters the scene tree for the first time.


	public static  AnimatedSprite2D[] lightAnimSprite;
	
	public static int whenSpeedAnimation;
	public override void _Ready()
	{
		whenSpeedAnimation = 240;
		var animationNode = GetChildren();
		if (animationNode != null)
		{
			var sprites = animationNode.OfType<AnimatedSprite2D>().ToArray();
			lightAnimSprite = sprites;
		}
		else
		{
			GD.PrintErr("Grafika/Animation node was not found.");
		}
		for (int i = 0; i < lightAnimSprite.Length; i++)
		{
			lightAnimSprite[i].SpeedScale = 0.1f;
		}

	}

	public static void SpeedAnimation()
	{
		for (int i = 0; i < lightAnimSprite.Length; i++)
		{
            lightAnimSprite[i].SpeedScale = lightAnimSprite[i].SpeedScale + 0.2f;
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{



	}
}
