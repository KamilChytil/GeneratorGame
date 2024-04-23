using Godot;
using System;
using System.Linq;

public partial class LightOffOn : Node
{

	public static Sprite2D[] spritLight;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		var lightChild = GetChildren();
		if(lightChild != null )
		{
			var sprite2D = lightChild.OfType<Sprite2D>().ToArray();
			spritLight = sprite2D;
		}
        SetLightToYellow();

    }

	public static void SetLightToWhite()
	{
        for (int i = 0; i < spritLight.Length; i++)
        {
            spritLight[i].Modulate = new Color(1, 1, 1);
        }

    }

    public static void SetLightToYellow()
    {

        for (int i = 0; i < spritLight.Length; i++)
        {
            spritLight[i].Modulate = new Color(1, 1, 0);
        }

    }



    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
