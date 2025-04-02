using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class FlyBehavior : MonoBehaviour
{
    private float _velocity = 1.5f;
    private Rigidbody2D _rb;
    private float _rotationSpeed = 10f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f; // ✨ No gravity!
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || IsTouchInput())
        {
            _rb.linearVelocity = Vector2.up * _velocity;
        }
        else
        {
            _rb.linearVelocity = Vector2.zero; // Prevent falling
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.GameOver();
    }

    bool IsTouchInput()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }
}
