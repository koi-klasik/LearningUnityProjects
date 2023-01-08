using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  // controls
  [SerializeField] float moveSpeed = 1f;
  Vector2 rawInput;

  // boundaries
  [SerializeField] float paddingTop;
  [SerializeField] float paddingBottom;
  [SerializeField] float paddingLeft;
  [SerializeField] float paddingRight;
  Vector2 minBounds;
  Vector2 maxBounds;

  Shooter shooter;

  void Awake()
  {
    shooter = GetComponent<Shooter>();
  }

  void Start()
  {
    BoundsInit();
  }

  void Update()
  {
    Move();
  }

  void BoundsInit()
  {
    Camera mainCamera = Camera.main;
    minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
    maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
  }

  private void Move()
  {
    Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
    Vector2 newPos = new Vector2();
    newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
    newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
    transform.position = newPos;
  }

  void OnMove(InputValue value)
  {
    rawInput = value.Get<Vector2>();
  }

  void OnFire(InputValue value)
  {
    if (shooter != null)
    {
      shooter.isFiring = value.isPressed;
    }
  }
}
