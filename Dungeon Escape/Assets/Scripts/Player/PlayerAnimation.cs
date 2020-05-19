using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator Playeranimator;
    Animator SwordAnimator;


    // Start is called before the first frame update
    void Start()
    {
        Playeranimator = transform.GetChild(0).GetComponent<Animator>();
        SwordAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    /// <summary>
    /// Sets the float value of "Move" in the animator to the movement of the character.
    /// </summary>
    /// <param name="movement"> float movement of player </param>
    public void Run(float movement) {

        Playeranimator.SetFloat("Move", Mathf.Abs(movement));

    }
    
    /// <summary>
    /// Sets the bool value of "Jump" in the animator to the jumping state of the character
    /// </summary>
    /// <param name="Grounded"> Bool whether player is on the ground </param>
    public void Jump(bool Grounded) {

        Playeranimator.SetBool("Jump", Grounded);
    }

    /// <summary>
    /// Sets the triggers on the player animation and sword animation to begin their attacking animations
    /// </summary>
    public void Attack() {
        Playeranimator.SetTrigger("Attack");
        SwordAnimator.SetTrigger("SwordAnimation");
    }

 

}
