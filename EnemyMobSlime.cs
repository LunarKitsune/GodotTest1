using Godot;
using System;
using System.Drawing;

public partial class EnemyMobSlime : CharacterBody2D
{
    public CharacterBody2D PlayerEnemy { get; set; }

    [Export]
    public int Speed { get; set; } = 300;

    public void _Ready()
    {
        //PlayerEnemy = GetNode<CharacterBody2D>()
    }

    public void _PhysicsProces(double delta)
    {
        PathfindToPlayer();
    }

    public void PathfindToPlayer()
    {
        var direction = GlobalPosition.DirectionTo(PlayerPosition.GlobalPosition);
        Velocity = direction * Speed;
        MoveAndSlide();
    }


}
