using Godot;

public partial class HurtboxComponent : Area2D
{
    private CollisionShape2D _collisionShape2D;

    private Timer _timer;

    public override void _Ready()
    {
        _collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
        _timer = GetNode<Timer>("Timer");
    }
}
