using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.InterfaceScripts;

namespace Test1.Characters.PlayerAssets.Scripts.PlayerMain
{
    public abstract partial class Entity : CharacterBody2D
    {
        #region PlayerMain Properties
        [Export]
        public int Speed { get; set; }

        [Export]
        public int HitPoints { get; set; }
        [Export]
        public int HitPointsMax { get; set; }

        [Export]
        public bool IsInvincible { get; set; }

        #endregion PlayerMain Properties

        //Will provide the base node with animation in it from the _Ready() function
        //This will also provide flexibility such as changing ground shadow and such.
        internal AnimationPlayer animationHandler;
        internal Timer playerTimer;

        //public override void _Ready()
        //{
        //    animationHandler = GetNode<Node2D>("HappyBoo").GetNode<AnimationPlayer>("AnimationPlayer");
        //    GetNode<Label>("HPLabel").Text = PlayerHitPoints.ToString();
        //    SetProcess(true);
        //}

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

        public abstract void OnWeaponPickUp();
    }

}
