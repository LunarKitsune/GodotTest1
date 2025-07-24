using Godot;
using System;

public interface IFirable
{
    float FireRate { get; set; }

    int AmmoCount { get; set; }

    int MaxAmmoCount { get; set; }

    PackedScene BulletType { get; set; }

    void FireBullet(Node2D bulletSpawnRef);
}
