using Godot;
using System;

public partial class PlayerStarterGun : Area2D, IFirable
{
    [Export]
    public float  FireRate { get; set; }
    [Export]
    public int AmmoCount { get; set; }
    [Export]
    public int MaxAmmoCount { get; set; }
    [Export]
    public PackedScene BulletType { get; set; }
    Timer BulletTimer { get; set; }
    bool bulletReady { get; set; } = true;

    Node2D shootPointref;



    //"WeaponPivot/GunWeaponType/ShootingPoint"
    public override void _Ready()
    {
        BulletTimer = GetNode<Timer>("BulletTimer");
        BulletTimer.OneShot = true;
        BulletTimer.WaitTime = .5;
    }

    public override void _PhysicsProcess(double delta)
    {
        shootPointref = GetNode<Node2D>("WeaponPivot/Pistol/ShootingPoint");
        //should both point and rotate the gun mouse. 
        //will have to figure out how to get gun not to follow mouse inside the gun offset from player
        Vector2 mousePos = GetGlobalMousePosition();
        

        PointGun(mousePos);
        FireBullet(shootPointref);
        if(BulletTimer.IsStopped())
        {
            bulletReady = true;
        }
    }

    public void PointGun(Vector2 mousePosition)
    {
        
        LookAt(mousePosition);
    }

    public void FireBullet(Node2D spawnPointRef)
    {
        if (Input.IsActionJustPressed("Fire") && bulletReady)
        {

            //solved bullet spawning issue by selecting "top leve" in inspector for bullet's visbility tab.
            //top level allows the bullet to act independently despite being a child of node shooting point. 
            //it would otherwise just spawn relative to the spawning point made

            Bullet gunBullet = (Bullet)BulletType.Instantiate();
            gunBullet.GlobalTransform = spawnPointRef.GlobalTransform;


            shootPointref.AddChild(gunBullet);
            BulletTimer.Start();
            bulletReady = false;
        }
    }

    #region EventHandlers
    public void OnBulletRangeExited(Area2D body)
    {
        //handles if the object is a projectile and is player spawned
        //in case there are other projectiles that shot by enemies
        if (body is IProjectile && body is IPlayerSpawned )
        {
            body.QueueFree();
        }
    }
    #endregion EventHandlers

}
