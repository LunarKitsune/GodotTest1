using Godot;
using System;

public partial class PlayerMain : CharacterBody2D,IDamagable
{
    //these are player properties. These are what defines some of the players attributes
    //think of what attributes you have on your own. 

    /*
     * As a person you have:
     *   -Walk Speed, Run speed, and you can stop in place (speed varience)
     *   -You can interact with your enviornemnt
     *   -You can get hurt and lose life force (for real life its blood, for characters its endurance/hp representing
     *   what stress they can endure before they passout/croak
     *   
     *   
     *   Player will need push back from slimes when collided with. Also will need to take damage as well
    */


    #region PlayerMain Properties
    [Export]
    int Speed { get; set; } = 600;

    [Export]
    string PlayerName { get; set; }

    [Export]
    int PlayerHitPoints { get; set; } = 30;

    [Export]
    bool isInvincible { get; set; }
    #endregion PlayerMain Properties

    //Will provide the base node with animation in it from the _Ready() function
    //This will also provide flexibility such as changing ground shadow and such.
    AnimationPlayer animationHandler;


    public override void _Ready()
    {
        animationHandler = GetNode <Node2D>("HappyBoo").GetNode<AnimationPlayer>("AnimationPlayer");
        SetProcess(true);
    }

    //These are functions. Functions commonly have thse base characteristics:

    /*
     * [Access modifier]  [Return type (can be void if returning nothing)]  [Name]      [Arguments] examnple (int a, string b...ect)
     * 
     * So a function could simply be public int CalculateSum (int input1, int input2){}
     * 
     * Functions also consist of a code body that comes in brackets so say in CalculateSum()
     * 
     * {
     *      Return input 1 + input 2;
     * }
    */

    public override void _Process(double delta)
    {
        if (Velocity.Length() > 0.0f || Velocity.Length() < 0.0f)
        {
            AnimatePlayerBody("walk");
        }
        else
        {
            AnimatePlayerBody("idle");
        }
        
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();

        MoveAndSlide();
    }

    #region Custom Player Functions
    public Vector2 GetInput()
    {
        Vector2 inputDirection = Input.GetVector("GD_Left", "GD_Right", "GD_Up", "GD_Down");
        Velocity = inputDirection * Speed;

        return Velocity;
    }

    /// <summary>
    /// Plays an animation of the player and if queing an animation will make the next animation play after the initial animation is finished. 
    /// </summary>
    /// <param name="animation">Animation to be played</param>
    /// <param name="queueAnimation">Whether an animation is going to be queued or not. By default false</param>
    /// <param name="queuedAnimation">Animation to be queued. The default animation will play if not specified</param>
    public void AnimatePlayerBody(string animation, bool queueAnimation = false, string queuedAnimation = "default")
    {
        animationHandler.Play(animation);

        if (queueAnimation)
        {
            animationHandler.Queue(queuedAnimation);
        }
    }

    //Thinking of making this for a hostile entity and we will check if they have damage collision
    //if they do then we will determine what the enemy strength is (provided there is one) and
    //deduct from the player's health. 
    public void TakeDamage(int damageTaken)
    {
        PlayerHitPoints -= damageTaken;
        if (PlayerHitPoints < 0)
        {
            QueueFree();
        }
    }


    #endregion Custom Player Functions

    #region signal delegates
    //[Signal]
    public delegate void PlayerCollisionHurtHandler();

    #endregion signal delegates

    #region DevFunctions

    public void GetTreeAndTypes()
    {

    }

    #endregion

}
