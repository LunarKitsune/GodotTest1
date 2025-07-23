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

    Node2D shootPointref;

    //"WeaponPivot/GunWeaponType/ShootingPoint"
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        shootPointref = GetNode<Node2D>("WeaponPivot/Pistol/ShootingPoint");
        //should both point and rotate the gun mouse. 
        //will have to figure out how to get gun not to follow mouse inside the gun offset from player
        Vector2 mousePos = GetGlobalMousePosition();

        PointGun(mousePos);
        FireBullet(shootPointref);
    }

    public void PointGun(Vector2 mousePosition)
    {
        
        LookAt(mousePosition);
    }

    public void FireBullet(Node2D spawnPointRef)
    {
        if(Input.IsActionJustPressed("Fire"))
        {
            //solved bullet spawning issue by selecting "top leve" in inspector for bullet's visbility tab.
            //top level allows the bullet to act independently despite being a child of node shooting point. 
            //it would otherwise just spawn relative to the spawning point made
            
            Bullet gunBullet = (Bullet)BulletType.Instantiate();
            gunBullet.GlobalRotation = shootPointref.GlobalRotation;
            gunBullet.GlobalPosition = shootPointref.GlobalPosition;


            shootPointref.AddChild(gunBullet);


        }
            
    }
}
