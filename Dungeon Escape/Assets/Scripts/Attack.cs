using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;

    /// <summary>
    /// If attack hitbox collides with object with an Idameable interface, deal damage to it. Pause for a brief time to stop it taking constant damage.
    /// </summary>
    /// <param name="other"> Collider2D of objected colided with</param>
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null) {

            if (canDamage == true) {
                hit.Damage();
                canDamage = false;
                StartCoroutine(AttackWait());
            }
        }
    }

    /// <summary>
    /// Wait method for allowing damage to be dealt
    /// </summary>
    /// <returns> Wait time</returns>
    IEnumerator AttackWait() {

        yield return new WaitForSeconds(0.8f);
        canDamage = true;

    }
}
