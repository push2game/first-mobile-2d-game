using Godot;

public abstract partial class Actor : CharacterBody2D
{
    [Export]
    public float MoveSpeed { get; set; } = 300.0f;

    [Export]
    public float Gravity { get; set; } = 50.0f;

    public abstract void TakeDamage(float amount, Node body);
}
