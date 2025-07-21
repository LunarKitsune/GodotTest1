using Godot;
using System;

public partial class Bullet : Area2D
{
    [Export]
    float BulletSpeed { get; set; } 
    [Export]
    float BulletDamage {  get; set; }
    [Export]
    bool isPiercing {  get; set; }

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

}
