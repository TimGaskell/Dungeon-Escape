using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{

    private void Start() {

        Destroy(this.gameObject, 5.0f);
    }

    private void Update() {

        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.tag == "Player") {

            IDamageable hit = collision.GetComponent<IDamageable>();
            
            if(hit != null) {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }

}
