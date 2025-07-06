using Godot;
using System;

public partial class PlayerMain : CharacterBody2D
{
    [Export]
    int speed { get; set; } = 600;

    [Export]
    string playerName { get; set; }

    [Export]
    int playerHitPoints { get; set; } = 30;


    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }

    #region Custom Player Functions
    public Vector2 GetInput()
    {
        Vector2 inputDirection = Input.GetVector("GD_Left", "GD_Right", "GD_Up", "GD_Down");
        Velocity = inputDirection * speed;

        return Velocity;
    }


    #endregion

    #region signal delegates
    //[Signal]
    //public delegate void NameChangeEventHandler();
    
    #endregion signal delegates

}
