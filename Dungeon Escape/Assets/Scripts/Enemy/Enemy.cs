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

        //sets move to point as point a
        if (transform.position == pointA.position) {
            CurrentTarget = pointB.position;
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetTrigger("Idle");

        }
        //sets move to point as point b
        else if (transform.position == pointB.position) {
            CurrentTarget = pointA.position;
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetTrigger("Idle");
        }

        //If not in combat move towards targeted position
        if (!isHit) {
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime);
            if(CurrentTarget == pointA.position) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition; //determine the direction of the player

        if (anim.GetBool("InCombat") && direction.x > 0) { //sets enemy to face the player
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (anim.GetBool("InCombat") && direction.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    /// <summary>
    /// Function used for dealing damage to this enemy. Each times they take damage they lose 1 health. This also sets them into combat and will attack the player. 
    /// If after taking damage they are bellow 0, they will play their death animation and drop a gem.
    /// </summary>
    public virtual void Damage() {
        if (isDead == true) {
            return;
        }

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health <= 0) {

            anim.SetTrigger("Death");
            isDead = true;
            GameObject Gem = Instantiate(GemPrefab, transform.position, Quaternion.identity);
            Gem.GetComponent<Diamond>().Gems = Gems;
        }
    }

    /// <summary>
    /// Function used for checking the distance between the enemy and the player. If the distance is greater than a set amount, they will come out of combat.
    /// </summary>
    void CheckDistance() {

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distance > 2.0f) {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }

    /// <summary>
    /// Function used for attacking the player.
    /// </summary>
    public virtual void Attack() {
        Debug.Log("My name is: " + this.gameObject.name);
    }




}
