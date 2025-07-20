using Godot;
using System;
using System.Diagnostics;
using System.Drawing;

public partial class EnemyMobSlime : CharacterBody2D, IMob
{
    public CharacterBody2D PlayerPosition { get; set; }

    [Export]
    public int HP { get; set; }
    [Export]
    public int Speed { get; set; } = 300;
    [Export]
    public string MonsterName { get; set; }
    public string Description { get; set; }
    [Export]
    public int HPMax { get; set; }
    [Export]
    public int Attack { get; set; }
    [Export]
    public int Defense { get; set; }

    public override void _Ready()
    {
        PlayerPosition = GetNode<CharacterBody2D>("/root/Game/Player");
    }

    public override void _PhysicsProcess(double delta)
    {
        PathfindToPlayer();
    }

    public void PathfindToPlayer()
    {
        var direction = GlobalPosition.DirectionTo(PlayerPosition.GlobalPosition);
        var distance = GlobalPosition.DistanceTo(PlayerPosition.GlobalPosition);

        if (distance < 500)
        {
            Velocity = direction * Speed;

            GetAnimation("walk");
        }
        else
        {
            Velocity = direction * 0;
            GetAnimation("idle");
        }

    }

    public void GetAnimation(string animationName)
    {
        GetNode<AnimationPlayer>("Slime/EntityAnimationPlayer").Play(animationName);
        
    }
   


}
