using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Characters.EnemyAssets.SlimeAssets.Scripts.GreenSlime
{
    public partial class GreenSlime: SlimeBase, IMob, IDamagable
    {

        public override void _Ready()
        {

            PlayerPosition = GetNode<CharacterBody2D>("/root/Game/Player");

            Speed = 250;
            HP = 30;
            HPMax = 30;
            Attack = 3;
            HPProgress = GetNode<ProgressBar>("VisualHealth");
            HPProgress.Value = HP;
            HPProgress.MaxValue = HPMax;
            HPProgress.MinValue = 0;
            HPProgress.FillMode = 0;
        }

        public override void _PhysicsProcess(double delta)
        {
            PathfindToTarget();
        }

        //a dumb pathfind where the slim always assumes it can just go straight to the player
        //may try to make this smarter
        public override void PathfindToTarget()
        {
            var direction = GlobalPosition.DirectionTo(PlayerPosition.GlobalPosition);
            var distance = GlobalPosition.DistanceTo(PlayerPosition.GlobalPosition);

            if (distance < 500)
            {
                Velocity = direction * Speed;

                GetAnimation("walk");
            }
            else
            {
                Velocity = direction * 0;
                GetAnimation("idle");
            }
            MoveAndSlide();
        }

        public override void GetAnimation(string animationName)
        {
            GetNode<AnimationPlayer>("Slime/EntityAnimationPlayer").Play(animationName);

        }

        public override void TakeDamage(int damageTaken)
        {
            HP -= damageTaken;
            HPProgress.Value = HP;


            if (HP <= 0)
            {
                QueueFree();
            }
        }

        public override void OnTargetDetected(CharacterBody2D target)
        {

        }
    }
}
