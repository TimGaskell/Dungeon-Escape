using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject GemPrefab;

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
    protected bool isHit = false;
    protected Player player;
    protected bool isDead = false;


    public void Start() {
        Init();
    }

    public virtual void Update() {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false) {
            return;
        }
        if (isDead) {
            return;
        }

        Movement();
        CheckDistance();
    }

    public virtual void Init() {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

        if (!isHit) {
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime);
            if(CurrentTarget == pointA.position) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (anim.GetBool("InCombat") && direction.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (anim.GetBool("InCombat") && direction.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    void CheckDistance() {

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distance > 2.0f) {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }


    public virtual void Attack() {
        Debug.Log("My name is: " + this.gameObject.name);
    }




}
