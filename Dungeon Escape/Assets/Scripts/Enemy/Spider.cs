using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    public int health { get; set; }
    public GameObject acidEffect;

    public override void Init() {
        base.Init();
        health = base.Health;
    }

    public override void Movement() {
        
    }

    public void Damage() {

        if(isDead == true) {
            return;
        }
        health--;
        if (health <= 0) {

            anim.SetTrigger("Death");
            isDead = true;
        }
    }

    public override void Attack() {
        base.Attack();
        Instantiate(acidEffect, transform.position, Quaternion.identity);
    }

}
