using Godot;
using System;

public interface IMob
{
    public string MonsterName {  get; set; }
    public string Description { get; set; }
    public int HP {  get; set; }

    public int HPMax { get; set; }

    public int Attack { get; set; }

    public int Defense { get; set; }
}

