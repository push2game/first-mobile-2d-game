using Godot;
using System;

public partial class Player : Actor
{
	[Signal]
	delegate void GameOverEventHandler();

	[Export]
	public float JumpImpulse { get; set; } = 150.0f;

	private AnimatedSprite2D _animatedSprite2D;

	private const int MAX_HEALTH = 3;

	private int playerHealth = MAX_HEALTH;

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		var direction = Input.GetAxis("MoveLeft", "MoveRight");
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;

			_animatedSprite2D.Play(Velocity.Y > 0 ? "Fall" : "Jump");
		}
		else
		{
			_animatedSprite2D.Play(direction != 0 ? "Run" : "Idle");
		}

		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y -= JumpImpulse;
		}

		if (direction != 0)
		{
			velocity.X = direction * MoveSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, MoveSpeed * (float)delta);
		}

		Velocity = velocity;

		UpdateFacingDirection();
		MoveAndSlide();
	}

	private void UpdateFacingDirection()
	{
		if (Velocity.X > 0)
		{
			_animatedSprite2D.FlipH = false;
		}
		else if (Velocity.X < 0)
		{
			_animatedSprite2D.FlipH = true;
		}
	}

	public override void TakeDamage(float amount, Node body)
	{
		throw new NotImplementedException();
	}
}
