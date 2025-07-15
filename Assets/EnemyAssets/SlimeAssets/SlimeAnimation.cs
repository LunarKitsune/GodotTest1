using Godot;
using System;

public partial class SlimeAnimation : Node2D
{
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
        GetNode<AnimationPlayer>("EntityAnimationPlayer").Play(animationName);
    }

    public void QeueueAnimation(string animationName)
    {
        GetNode<AnimationPlayer>("EntityAnimationPlayer").Queue(animationName);
    }

    public string GetCurrentAnimation()
    {
        return GetNode<AnimationPlayer>("EntityAnimationPlayer").CurrentAnimation;
    }
}
