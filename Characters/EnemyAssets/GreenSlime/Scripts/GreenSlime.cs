using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.InterfaceScripts;

namespace Test1.Characters.EnemyAssets.SlimeAssets.Scripts.GreenSlime
{
    public partial class GreenSlime: SlimeBase, IMob, IDamagable
    {
        List<Node2D> playerEntities;

        public override void _Ready()
        {
            playerEntities = new List<Node2D>();
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
            var targetPlayer = GetClosestTarget();

            if (targetPlayer != null)
            {
                var direction = GlobalPosition.DirectionTo(targetPlayer.GlobalPosition);

                Velocity = direction * Speed;

                GetAnimation("walk");
            }
            else
            {
                Velocity *= 0;
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

        //on area entered
        public override void OnTargetDetected(Node2D targetBody)
        {
            if(targetBody is IPlayable && !(playerEntities.Contains(targetBody)))
            {
                playerEntities.Add(targetBody);
            }
        }

        //on area exited
        public override void OnTargetLost(Node2D targetBody)
        {
            if (targetBody is IPlayable && (playerEntities.Contains(targetBody)))
            {
                playerEntities.Remove(targetBody);
            }
        }
        
        public Node2D GetClosestTarget()
        {
            float currDistance;
            float distanceFrom = 100000f;
            Node2D target = null;

            foreach(Node2D targetEntity in playerEntities) 
            {
                currDistance = GlobalPosition.DistanceTo(targetEntity.Position);
                if (currDistance <= distanceFrom)
                {
                    target = targetEntity;
                    distanceFrom = currDistance;
                }
            }

            return target;
        }
    }
}
