using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.InterfaceScripts
{
    internal interface IPlayable
    {
        string PlayerName { get; set; }
        int PlayerHitPoints { get; set; }
        int PlayerMaxHitPoints { get; set; }
        PackedScene PlayerCharacterType { get; set; }


    }
}
