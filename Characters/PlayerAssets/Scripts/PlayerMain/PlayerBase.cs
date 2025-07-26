using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.InterfaceScripts;

namespace Test1.Characters.PlayerAssets.Scripts.PlayerMain
{
    public partial class PlayerBase : CharacterBody2D, IPlayable
    {
        public string PlayerName { get; set; }
        public PackedScene PlayerCharacterType { get; set; }

        public Vector2 GetInput()
        {
            throw new NotImplementedException();
        }

    }
}
