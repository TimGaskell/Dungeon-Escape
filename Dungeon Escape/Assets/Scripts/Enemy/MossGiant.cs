using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int health { get; set; }

    public override void Init() {
        base.Init();
        health = base.Health;
    }

    public void Damage() {

    }

}
