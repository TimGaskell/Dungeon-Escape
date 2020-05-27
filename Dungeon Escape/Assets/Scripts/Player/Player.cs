using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    public int Gems;

    private Rigidbody2D rigid;
    private PlayerAnimation playerAnimation;
    private bool ResetJump = false;
    private bool Grounded = false;

    public int health { get; set; }
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if((Input.GetMouseButtonDown(0) || CrossPlatformInputManager.GetButtonDown("A_Button")) && IsGrounded()) {
            playerAnimation.Attack();
        }
                 
    }

    /// <summary>
    /// Method that handles the movement of the player. Player moves by pressing and keys bound the horizontal axis and jumps by pressing space bar.
    /// This method also checks whether the player is currently grounded to allow it to jump again.
    /// </summary>
    void Movement() {

        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        Grounded = IsGrounded();

        Flip(move);

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && IsGrounded()) {

            Debug.Log("Jump!");
            rigid.velocity = new Vector2(rigid.velocity.x, _jumpForce); //add jump force
            playerAnimation.Jump(true); //Play Jump animation
            StartCoroutine(ResetJumpRoutine());

        }
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y); // Add movement force
        playerAnimation.Run(move); // Play running animation
    }

    /// <summary>
    /// Flips the scale of the player depending on which direction they are heading. If move is negative they are moving left, and positive means right. 
    /// </summary>
    /// <param name="move"> float input value of direction </param>
    private void Flip(float move) {
        if (move > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /// <summary>
    /// Physics raycast method that determines whether or not the player is currently on the ground by casting to it. If the collider it comes in contact with isn't on the ground layer then the player isn't grounded.
    /// </summary>
    /// <returns> True or False whether the player is currently on the ground </returns>
    bool IsGrounded() {

        RaycastHit2D hitInfo =  Physics2D.Raycast(transform.position, Vector2.down, 0.8f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green); //Debug line of where the raycast is.

        if(hitInfo.collider != null) {
            if (!ResetJump) {
                playerAnimation.Jump(false);
                return true;             
            }
        }
        return false;
    }

    /// <summary>
    /// IEnumerator function that is used as a timer for when the ISGrounded() function is allowed to check if the player is back on the ground
    /// </summary>
    /// <returns> Wait time </returns>
    IEnumerator ResetJumpRoutine() {
        ResetJump = true;
        yield return new WaitForSeconds(0.1f);
        ResetJump = false;
    }

    public void Damage() {

        if(health < 1) {
            return;
        }
        Debug.Log("Player took damage");
        health--;
        UIManager.Instance.UpdateLivesRemaining(health);

        if(health < 1) {
            playerAnimation.Death();
        }
        
    }

    public void AddGems(int amount) {
        Gems += amount;
        UIManager.Instance.UpdateGemCount(Gems);
    }
}
