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

    Marker2D shootingPoint;

    //"WeaponPivot/GunWeaponType/ShootingPoint"
    public override void _Ready()
    {
        shootingPoint = GetNode<Marker2D>("WeaponPivot/GunWeaponType/ShootingPoint");
        GD.Print($"shooting point position: {shootingPoint.GlobalPosition}");
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
        Position = mousePosition * offset;

    }

    public void PointGun(Vector2 mousePosition)
    {
        LookAt(GetGlobalMousePosition());
    }

    public void FireBullet()
    {
        if(Input.IsActionJustPressed("Fire"))
        {
            //need to figure out how to pull the global position of the bullet being instantiated in c#
            //fires seperately from the gun, but now just needs the rotation and position of gun bullet spawner
            Bullet gunBullet = (Bullet)BulletType.Instantiate();
            gunBullet.Rotation = shootingPoint.GlobalRotation;
            gunBullet.Position = Position;
            GetParent().AddChild(gunBullet);
            
            
        }
            
    }
}
