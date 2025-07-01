using Godot;
using System;

public partial class PlayerMain : CharacterBody2D
{
    [Export]
    int speed { get; set; } = 50;

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }

    public Vector2 GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * speed;

        return Velocity;
    }
}
