using Godot;
using System;
using System.Diagnostics;
using System.Drawing;

public abstract partial class SlimeBase : CharacterBody2D
{
    public CharacterBody2D PlayerPosition { get; set; }

    [Export]
    public int HP { get; set; }
    [Export]
    public int Speed { get; set; }
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

    //a dumb pathfind where the slim always assumes it can just go straight to the player
    //may try to make this smarter
    public abstract void PathfindToTarget();

    public abstract void GetAnimation(string animationName);


    public abstract void TakeDamage(int damageTaken);

    public abstract void OnTargetDetected(CharacterBody2D target);

}

