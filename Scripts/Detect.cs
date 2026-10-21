using Godot;
using System;

public partial class Detect : Area2D {


	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body is PlayerMovement)
		{
			GD.Print("Player touchy touch.");
		}
	}




}
