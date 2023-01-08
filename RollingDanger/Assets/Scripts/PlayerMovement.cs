using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody rbPlayer;
  private float hozInput, verInput;

  [SerializeField] private float speed = 1f, jumpForce = 5f;

  private bool isJumpButtonPressed, isGrounded;

  // Start is called before the first frame update
  void Start()
  {
    rbPlayer = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    hozInput = Input.GetAxis("Horizontal");
    verInput = Input.GetAxis("Vertical");

    if (Input.GetKeyDown(KeyCode.Space))
    {
      isJumpButtonPressed = true;
    }
  }

  // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  void FixedUpdate()
  {
    Vector3 playerMovement = new Vector3(hozInput, 0.0f, verInput);
    playerMovement *= speed;
    rbPlayer.AddForce(playerMovement, ForceMode.Acceleration);

    Ray ray = new Ray(transform.position, Vector3.down);
    if (Physics.Raycast(ray, transform.localScale.x / 2f + 0.01f))
    {
      isGrounded = true;
    }
    else
    {
      isGrounded = false;
    }

    if (isJumpButtonPressed && isGrounded)
    {
      rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isJumpButtonPressed = false;
    }
  }

  //   // OnCollisionEnter is called when this collider/rigidbody has begun
  //   // touching another rigidbody/collider.
  //   private void OnCollisionEnter(Collision other)
  //   {
  //     isGrounded = true;
  //   }

  //   // OnCollisionExit is called when this collider/rigidbody has
  //   // stopped touching another rigidbody/collider.
  //   private void OnCollisionExit(Collision other)
  //   {
  //     isGrounded = false;
  //   }
}
