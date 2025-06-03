using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D pRigidbody2D;
    private bool didPlayerJump = false;
    private float forwardSpeed = 1.2f;
    private float jumpPower = 6f;
    private float gravityScale = 1.6f;

    void Start()
    {
        pRigidbody2D = GetComponent<Rigidbody2D>();

        // Freeze at start
        pRigidbody2D.gravityScale = 0;
        pRigidbody2D.velocity = Vector2.zero;

        pRigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        pRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        if (!GameManager.gameStarted)
        {
            if (Input.GetButtonDown("Fire1") || Input.touchCount > 0)
            {
                GameManager.gameStarted = true;
                GameManager.canReceiveInput = true;

                pRigidbody2D.gravityScale = gravityScale;
                didPlayerJump = true;
                AudioManager.instance.PlayJumpSound(); // First jump sound
            }
            return;
        }

        if (GameManager.canReceiveInput)
        {
            if (Input.GetButtonDown("Fire1") || Input.touchCount > 0)
            {
                didPlayerJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.gameStarted) return;

        pRigidbody2D.velocity = new Vector2(forwardSpeed, pRigidbody2D.velocity.y);

        if (didPlayerJump)
        {
            pRigidbody2D.velocity = new Vector2(forwardSpeed, jumpPower);
            AudioManager.instance.PlayJumpSound();
            didPlayerJump = false;
        }
    }
}
