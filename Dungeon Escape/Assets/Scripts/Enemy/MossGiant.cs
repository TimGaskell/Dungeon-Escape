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

        if (isDead == true) {
            return;
        }

        health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (health <= 0) {

            anim.SetTrigger("Death");
            isDead = true;
            GameObject Gem =  Instantiate(GemPrefab, transform.position, Quaternion.identity);
            Gem.GetComponent<Diamond>().Gems = base.Gems;
        }
    }

}
