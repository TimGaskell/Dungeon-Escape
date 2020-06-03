using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy,IDamageable {

    public int health { get; set; }

    public override void Init() {
        base.Init();
        health = base.Health;
    }

   

}
