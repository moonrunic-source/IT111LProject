using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Speed = 300.0f;
	
	private Texture2D _rightSprite;
	private Texture2D _leftSprite;
	
	public override void _Ready()
	{
		_rightSprite = GD.Load<Texture2D>("res://Assets/ChatGPT Image Oct 2, 2026, 06_00_13 PM.png");
		_leftSprite = GD.Load<Texture2D>("res://Assets/flipped.png");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		if (Input.IsActionPressed("ui_left"))
		{
			//_rightSprite.FlipH(true);
			Console.WriteLine("Left");
		}
		else 
		{
			//_rightSprite.FlipH(false);
			Console.WriteLine("Right");
		}
		
		if (direction != Vector2.Zero) 
		{
			velocity.Y = direction.Y * Speed;
		}
		else 
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
