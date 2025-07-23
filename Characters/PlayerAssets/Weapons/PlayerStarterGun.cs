using Godot;
using System;

public partial class PlayerStarterGun : Area2D
{
    [Export]
    float FireRate {  get; set; }
    [Export]
    PackedScene BulletType { get; set; }
    [Export]
    int AmmoCount {  get; set; }
    [Export]
    int MaxAmmoCount { get; set; }
    [Export]
    float GunPositionOffset { get; set; }


    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        //should both point and rotate the gun mouse. 
        //will have to figure out how to get gun not to follow mouse inside the gun offset from player
        Vector2 mousePos = GlobalPosition.DirectionTo(GetGlobalMousePosition());

        RotateAroundPlayer(GunPositionOffset, mousePos);
        PointGun(mousePos);
        FireBullet();
    }

    public void RotateAroundPlayer(float offset, Vector2 mousePosition)
    {
        Position = GlobalPosition.DirectionTo(GetGlobalMousePosition()) * offset;

    }

    public void PointGun(Vector2 mousePosition)
    {
        LookAt(GetGlobalMousePosition());
    }

    public void FireBullet()
    {
        if(Input.IsActionJustPressed("Fire"))
        {
            
        }
            
    }
}
