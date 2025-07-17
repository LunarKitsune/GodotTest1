using Godot;
using System;

public partial class PlayerMain : CharacterBody2D
{
    //these are player properties. These are what defines some of the players attributes
    //think of what attributes you have on your own. 

    /*
     * As a person you have:
     *   -Walk Speed, Run speed, and you can stop in place (speed varience)
     *   -You can interact with your enviornemnt
     *   -You can get hurt and lose life force (for real life its blood, for characters its endurance/hp representing
     *   what stress they can endure before they passout/croak
    */


    #region PlayerMain Properties\
    int Speed { get; set; } = 600;

    [Export]
    string PlayerName { get; set; }

    [Export]
    int PlayerHitPoints { get; set; } = 30;

    [Export]
    bool invicibilityOn { get; set; } = false;
    #endregion PlayerMain Properties

<<<<<<< Updated upstream
=======
    [Export]
    bool isInvincible { get; set; };
>>>>>>> Stashed changes

    //Will provide the base node with animation in it from the _Ready() function
    //This will also provide flexibility such as changing ground shadow and such.
    Node2D baseAnimationNode;


    public override void _Ready()
    {
        baseAnimationNode = GetNode <Node2D>("HappyBoo");
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


    public override void _PhysicsProcess(double delta)
    {
        GetInput();

        AnimatePlayerBody(doAnimate: (Velocity.Length() > 0.0f || Velocity.Length() < 0.0f));

        MoveAndSlide();
    }

    #region Custom Player Functions
    public Vector2 GetInput()
    {
        Vector2 inputDirection = Input.GetVector("GD_Left", "GD_Right", "GD_Up", "GD_Down");
        Velocity = inputDirection * Speed;

        return Velocity;
    }

    public void AnimatePlayerBody(bool doAnimate)
    {
        //retrieving animation node here from the base node. 
        if (doAnimate)
        {
            baseAnimationNode.GetNode<AnimationPlayer>("AnimationPlayer").Play("walk");
        }
        else 
        {
            baseAnimationNode.GetNode<AnimationPlayer>("AnimationPlayer").Play("idle");
        }
    }

    //Thinking of making this for a hostile entity and we will check if they have damage collision
    //if they do then we will determine what the enemy strength is (provided there is one) and
    //deduct from the player's health. 
    void HurtPlayer(CharacterBody2D hostileEntity)
    {

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
