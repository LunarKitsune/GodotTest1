using Godot;
using System;

public partial class HpLabel : Label
{
    /// <summary>
    /// Fires an event when HP is changed to a character
    /// </summary>
    [Signal]
    public delegate void onHPChangeEventHandler();
}
