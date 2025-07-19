using Godot;
using System;

public partial class SlimeAnimation : Node2D
{
    public AnimationPlayer PlayerAnimationManager { get; set; }

    public override void _Ready()
    {
        PlayerAnimationManager = GetNode<AnimationPlayer>("EntityAnimationPlayer");
    }

    public void PlayWalkAnimation()
    {
        PlayAnimation("walk");
    }

    public void PlayIdolAnimation()
    {
        PlayAnimation("idle");
    }

    public void PlayHurtAnimation()
    {
        PlayAnimation("hurt");
        QeueueAnimation("idle");
    }

    public void PlayAnimation(string animationName)
    {
        PlayerAnimationManager.Play(animationName);
    }

    public void QeueueAnimation(string animationName)
    {
        PlayerAnimationManager.Queue(animationName);
    }

    public string GetCurrentAnimation()
    {
        return PlayerAnimationManager.CurrentAnimation;
    }

    #region debugFunctions

    public string[] GetQueuedAnimations()
    {
        return PlayerAnimationManager.GetQueue();
    }

    public void TestAnimations()
    {
    }

    #endregion debugFunctions
}
