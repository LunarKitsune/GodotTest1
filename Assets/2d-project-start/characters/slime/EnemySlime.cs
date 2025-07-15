using Godot;
using System;

public partial class EnemySlime : Node2D
{
    /// <summary>
    /// Plays the "walk" animation of the slime
    /// </summary>
    public void PlayWalkAnimation()
    {
        PlayAnimation("walk");
    }

    /// <summary>
    /// Plays the "idle" animation of the slime
    /// </summary>
    public void PlayIdleAnimation() 
    {
        PlayAnimation("idle");
    }

    /// <summary>
    /// Plays the "hurt" animation of the slime
    /// </summary>
    public void PlayHurtAnimation()
    {
        PlayAnimation("hurt");
        QueueAnimation("walk");
    }

    /// <summary>
    /// Function to get the node that needs the animation changed.
    /// </summary>
    /// <param name="animationName">Animation to be played</param>
    void PlayAnimation(string animationName)
    {
        GetNode<AnimationPlayer>("EntityAnimationPlayer").Play(animationName);
    }

    /// <summary>
    /// Queues Animation to be played next
    /// </summary>
    /// <param name="animationName">Animation to be played next</param>
    void QueueAnimation(string animationName)
    {
        GetNode<AnimationPlayer>("EntityAnimationPlayer").Queue(animationName);
    }

    /// <summary>
    /// Retrieves the current animation of the node. This function is meant for
    /// Two purposes:
    ///     1: To compare if an object is already in an animation and
    ///     2: For debugging purposes if that animation is already playing or not
    /// </summary>
    /// <returns></returns>
    public string GetCurrentAnimation()
    {
        return GetNode<AnimationPlayer>("EntityAnimationPlayer").CurrentAnimation;
    }

  
}
