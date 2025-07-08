using Godot;
using System;

public partial class PlayerMain : CharacterBody2D
{
    //create an animated sprite object that will handle playing sprite asset animations
    AnimationPlayer _playerAnimation;

    #region PlayerMain Properties
    [Export]
    int speed { get; set; } = 600;

    [Export]
    string playerName { get; set; }

    [Export]
    int playerHitPoints { get; set; } = 30;
    #endregion PlayerMain Properties

    public override void _Ready()
    {
        GetTreeAndTypes();
        //recieve the node that will be using the animation
        //_animation2D = GetNode
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        AnimatePlayerBody();
        MoveAndSlide();
    }

    #region Custom Player Functions
    public Vector2 GetInput()
    {
        Vector2 inputDirection = Input.GetVector("GD_Left", "GD_Right", "GD_Up", "GD_Down");
        Velocity = inputDirection * speed;

        return Velocity;
    }

    public void AnimatePlayerBody()
    {
        //doing get node on another node retrieves its child
        _playerAnimation = GetNode<Node2D>("HappyBoo").GetNode<AnimationPlayer>("AnimationPlayer");
        _playerAnimation.Play("walk");
    }


    #endregion Custom Player Functions

    #region signal delegates
    //[Signal]
    //public delegate void NameChangeEventHandler();

    #endregion signal delegates

    #region DevFunctions

    public void GetTreeAndTypes()
    {
    }

    #endregion

}
