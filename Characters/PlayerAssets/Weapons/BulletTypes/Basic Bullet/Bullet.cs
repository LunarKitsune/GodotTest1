using Godot;
using System;

public partial class Bullet : Area2D,IProjectile
{
    [Export]
    public float ProjectileSpeed { get; set; }
    [Export]
    public int ProjectileDamage { get; set; }
    [Export]
    public Vector2 ProjectileRange { get; set; }
    [Export]
    public bool isProjectilePiercing { get; set; }

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        PushBullet(delta);

    }

    public void PushBullet(double deltaRef)
    {
        Vector2 direction = Vector2.Right.Rotated(Rotation);
        
        Position += ProjectileSpeed * direction * (float)deltaRef;
    }

    public void DestroyBullet()
    {
        QueueFree();
    }

    #region EventHandlers

    
    public void OnBodyEntered(Node2D body)
    {
        if(body is IDamagable damagable && body is IMob mob)
        {
            damagable.TakeDamage(ProjectileDamage);
        }

        if(!isProjectilePiercing)
        { 
            DestroyBullet(); 
        }
    }

    public void OnBulletRangeExit(Area2D body)
    {
        if (body is IFirable)
        {
            DestroyBullet();
        }
    }

    #endregion EventHandlers

}
