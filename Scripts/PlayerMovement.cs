using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public float Speed = 300.0f; // Enables changing for difficulty
	
	private Sprite2D _sprite;
	
	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>("Sprite2D"); // Fetching the sprite Node in player
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity; 

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down"); // Sets the movement down
		if (direction != Vector2.Zero) // For horizotal movement
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		if (direction.X != 0) { // Enables sprite flipping
			_sprite.FlipH = direction.X < 0;
		}
		
		if (direction != Vector2.Zero) //For vertical movement
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
