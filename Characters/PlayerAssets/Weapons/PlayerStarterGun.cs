using Godot;
using System;

/*
 * Notes:
 * 
 * Need to have the bullet that will eventually be fired inherit the rotation
 * of the gun so it fires in the proper direction.
 * 
 * Bullet will need to collide with mobs and make mobs take damage. 
 */


public partial class PlayerStarterGun : Area2D
{
    [Export]
    float FireRate {  get; set; }
    [Export]
    Bullet BulletType { get; set; }
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
        Vector2 mouseDirection = GlobalPosition.DirectionTo(GetGlobalMousePosition());

        RotateAroundPlayer(GunPositionOffset, mouseDirection);
        PointGun(mouseDirection);
    }

    public void RotateAroundPlayer(float offset, Vector2 mouseDir)
    {
        Position = mouseDir * offset;

    }

    public void PointGun(Vector2 mouseDir)
    {
        LookAt(GetGlobalMousePosition());
    }

    public void FireFun()
    {

    }
}
