using Godot;
using System;
using System.Drawing;

public partial class EnemyMobSlime : CharacterBody2D, IMob
{
    public CharacterBody2D PlayerPosition { get; set; }

    [Export]
    public int HP { get; set; }
    [Export]
    public int Speed { get; set; } = 300;
    [Export]
    public string MonsterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Export]
    public int HPMax { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Export]
    public int Attack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Export]
    public int Defense { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(double delta)
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
