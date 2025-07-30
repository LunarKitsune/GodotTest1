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
        public string PlayerName { get; set; }

        public PackedScene Weapon { get; set; }

    }
}
