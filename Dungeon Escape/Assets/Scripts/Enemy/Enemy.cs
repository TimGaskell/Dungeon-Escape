using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int Health;
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected int Gems;
    [SerializeField]
    protected Transform pointA, pointB;


    protected Vector3 CurrentTarget;
    protected Animator anim;

    public void Start() {
        Init();
    }

    public virtual void Update() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            return;
        }

        Movement();
    }

    public virtual void Init() {
        anim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Function responsible for having the enemy move between two target positions. The enemy will walk to the point, idle then walk to the opposite point.
    /// </summary>

    public virtual void Movement() {

        if (transform.position == pointA.position) {
            CurrentTarget = pointB.position;
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position) {
            CurrentTarget = pointA.position;
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime);

    }


    public virtual void Attack() {
        Debug.Log("My name is: " + this.gameObject.name);
    }




}
