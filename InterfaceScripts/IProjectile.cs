using Godot;
using System;

public interface IProjectile
{
 
    float ProjectileSpeed { get; set; }

    int ProjectileDamage { get; set; }

    Vector2 ProjectileRange { get; set; }

    bool isProjectilePiercing { get; set; }
}
