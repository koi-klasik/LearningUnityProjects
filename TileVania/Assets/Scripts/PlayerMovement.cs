using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float runAmount = 10f;
  [SerializeField] float jumpAmount = 10f;
  [SerializeField] float climbAmount = 10f;
  [SerializeField] Vector2 deathKick = new Vector2(20f, 20f);

  // ref serializefield
  [SerializeField] Transform gun;
  [SerializeField] GameObject bullet;

  bool isAlive = true;
  float currentGravity;
  Vector2 moveInput;

  // ref
  Rigidbody2D myRigidbody;
  Animator myAnimator;
  CapsuleCollider2D myBodyCollider;
  BoxCollider2D myFootCollider;

  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
    myBodyCollider = GetComponent<CapsuleCollider2D>();
    myFootCollider = GetComponent<BoxCollider2D>();

    currentGravity = myRigidbody.gravityScale;
  }

  void Update()
  {
    if (!isAlive) return;

    Run();
    FlipSprite();
    Climb();
    Die();
  }

  void OnMove(InputValue value)
  {
    if (!isAlive) return;

    moveInput = value.Get<Vector2>();
  }

  void OnJump(InputValue value)
  {
    if (!isAlive) return;

    if (!myFootCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

    if (value.isPressed)
    {
      myRigidbody.velocity += new Vector2(0f, jumpAmount);
    }
  }

  void OnFire(InputValue value)
  {
    if (!isAlive) return;

    Instantiate(bullet, gun.position, transform.rotation);
  }

  void Run()
  {
    Vector2 playerVelocity = new Vector2(moveInput.x * runAmount, myRigidbody.velocity.y);
    myRigidbody.velocity = playerVelocity;

    bool hasHorizontalMove = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    myAnimator.SetBool("isRunning", hasHorizontalMove);
  }

  void FlipSprite()
  {
    bool hasHorizontalMove = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

    if (hasHorizontalMove)
      transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
  }

  void Climb()
  {
    if (!myFootCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
    {
      myRigidbody.gravityScale = currentGravity;
      myAnimator.SetBool("isClimbing", false);
      return;
    }

    Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbAmount);
    myRigidbody.velocity = climbVelocity;
    myRigidbody.gravityScale = 0f;

    bool hasVerticalMove = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
    myAnimator.SetBool("isClimbing", hasVerticalMove);
  }

  void Die()
  {
    if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Spike")))
    {
      isAlive = false;
      myRigidbody.velocity = deathKick;

      myAnimator.SetTrigger("Dying");

      FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
  }
}
