using Godot;
using System;

public partial class Bullet : Area2D
{
    [Export]
    float BulletSpeed { get; set; } 
    [Export]
    int BulletDamage {  get; set; }
    [Export]
    Vector2 BulletRange {  get; set; }
    [Export]
    bool isPiercing {  get; set; }

    Marker2D rotationReference;

    public override void _Ready()
    {
        rotationReference = GetNode<Area2D>("Gun").GetNode<Marker2D>("WeaponPivot");
        BulletRange = Position * 1500;
    }

    public override void _PhysicsProcess(double delta)
    {
        RotateBullet(delta);

        if (BulletRange < Position)
        {
            DestroyBullet();
        }

    }

    public void RotateBullet(double deltaRef)
    {
        Vector2 direction = Vector2.Right.Rotated(rotationReference.Rotation);

        Position += direction * BulletSpeed * (float)deltaRef;
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
            damagable.TakeDamage(BulletDamage);
        }

        DestroyBullet();
    }

    #endregion EventHandlers

}
