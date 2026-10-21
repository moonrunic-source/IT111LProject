using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public float SpeedArrow = 300.0f; // Enables changing for difficulty [Arrow key speeds]
	public float SpeedKeys = 5.0f;  // Enables changing for difficulty [WASD keys speeds]
	public int healthPoints; // Enables damage 
	
	private Sprite2D _sprite;
	private Texture2D Left;
	private Texture2D Right;
	private bool Check = true;
	
	public override void _Ready()
	{
		GD.Print("Test");
		_sprite = GetNode<Sprite2D>("Sprite2D");
		Left = GD.Load<Texture2D>("res://Assets/l.png");
		Right = GD.Load<Texture2D>("res://Assets/r.png");
		healthPoints = 3;
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity; 

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down"); // Sets the movement down
		
		if (Input.IsKeyPressed(Key.A)) {
			this.Position += new Vector2(-SpeedKeys, 0);
			Check = false;
		}
		if (Input.IsKeyPressed(Key.D)) {
			this.Position += new Vector2(SpeedKeys, 0);
			Check = true;
		}
		if (Input.IsKeyPressed(Key.W)) {
			this.Position += new Vector2(0, -SpeedKeys);
		}
		if (Input.IsKeyPressed(Key.S)) {
			this.Position += new Vector2(0, SpeedKeys);
		}
		
		if (direction != Vector2.Zero) // For horizotal movement
		{
			velocity.X = direction.X * SpeedArrow;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, SpeedArrow);
		}
		
		
		if (direction != Vector2.Zero) //For vertical movement
		{
			velocity.Y = direction.Y * SpeedArrow;
		}
		else 
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, SpeedArrow);
		}

		if (direction.X < 0) { // Enables sprite flipping
			_sprite.FlipH = true;
		}
		else
		{
			_sprite.FlipH = false;
		}
		
		if (Check)
		{
			_sprite.Texture = Right;
		}
		else
		{
			_sprite.Texture = Left;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
