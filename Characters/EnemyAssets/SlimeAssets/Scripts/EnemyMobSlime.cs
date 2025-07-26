using Godot;
using System;
using System.Diagnostics;
using System.Drawing;

public partial class EnemyMobSlime : CharacterBody2D, IMob, IDamagable
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
    public ProgressBar HPProgress { get; set; }

    public override void _Ready()
    {

        PlayerPosition = GetNode<CharacterBody2D>("/root/Game/Player");

        HPProgress = GetNode<ProgressBar>("VisualHealth");
        HPProgress.Value = HP;
        HPProgress.MaxValue = HPMax;
        HPProgress.MinValue = 0;
        HPProgress.FillMode = 0;
    }

    public override void _PhysicsProcess(double delta)
    {
        PathfindToTarget();
    }

    //a dumb pathfind where the slim always assumes it can just go straight to the player
    //may try to make this smarter
    public void PathfindToTarget()
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
        MoveAndSlide();
    }

    public void GetAnimation(string animationName)
    {
        GetNode<AnimationPlayer>("Slime/EntityAnimationPlayer").Play(animationName);
        
    }

    public void TakeDamage(int damageTaken)
    {
        HP -= damageTaken;
        HPProgress.Value = HP;

        if(HP <= 0)
        {
            QueueFree();
        }
    }

    public void OnTargetDetected(CharacterBody2D target)
    {
        
    }
}
