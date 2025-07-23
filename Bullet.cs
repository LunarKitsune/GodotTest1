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

    Marker2D rotationReference;

    public override void _Ready()
    {
        rotationReference = GetNode<Area2D>("Gun").GetNode<Marker2D>("WeaponPivot");
        ProjectileRange = Position * 1500;
    }

    public override void _PhysicsProcess(double delta)
    {
        PushBullet(delta);

        if (ProjectileRange < Position)
        {
            DestroyBullet();
        }

    }

    public void PushBullet(double deltaRef)
    {
        Vector2 direction = Vector2.Right.Rotated(rotationReference.Rotation);

        Position += direction * ProjectileSpeed * (float)deltaRef;
    }

    public void DestroyBullet()
    {
        QueueFree();
    }

    #region EventHandlers

    
    public void OnBodyEntered(Node2D body)
    {
        if(body is IDamagable damagable)
        {
            damagable.TakeDamage(ProjectileDamage);
        }

        if(!isProjectilePiercing)
        { DestroyBullet(); }
    }

    #endregion EventHandlers

}
