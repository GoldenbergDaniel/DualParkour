using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public LayerMask whatIsGround;
    public string axis;

    public float movementSpeed = 600f;
    public float jumpHeight = 17.5f;
    public int initialJumpCount = 1;
    private int jumpCount;

    private Rigidbody2D rb;
    private Vector3 velocity;
    private KeyCode jump;

    private float groundedRemember;
    private float jumpRemember;
    private bool isGrounded;

    private Vector2 initialScale;
    public Vector2 newScale;

    public float speed = 5f;
    private float duration = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector3.zero;

        initialScale = transform.localScale;

        jumpCount = 0;

        switch (axis)
        {
            case "Horizontal1":
                jump = KeyCode.W;
                break;
            case "Horizontal2":
                jump = KeyCode.UpArrow;
                break;
            case "Horizontal3":
                jump = KeyCode.I;
                break;
            default:
                jump = KeyCode.Space;
                break;
        }
    }

    private void Update()
    {
        groundedRemember -= Time.deltaTime;
        jumpRemember -= Time.deltaTime;

        if (initialJumpCount > 1)
        {
            if (isGrounded)
            {
                jumpCount = initialJumpCount;
            }

            if (Input.GetKeyDown(jump) && jumpCount > 1)
            {
                jumpRemember = 0.5f;
                jumpCount -= 1;

                Jump();
            }
        }
        else
        {
            if (isGrounded)
            {
                groundedRemember = 0.15f;
            }

            if (Input.GetKeyDown(jump) && groundedRemember > 0 && jumpRemember < 0)
            {
                jumpRemember = 0.5f;
                groundedRemember = 0;

                Jump();
            }
        } 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis(axis) * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, rb.velocity, ref velocity, 0.05f);

        isGrounded = false;

        Collider2D[] col = Physics2D.OverlapBoxAll((Vector2) transform.position - new Vector2(0f, 1f), new Vector2(0.96f, 0.5f), 0f, whatIsGround);

        for (int x = 0; x < col.Length; x++)
        {
            isGrounded = true;

            jumpCount = initialJumpCount;
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(0f, jumpHeight);

        AudioManager.instance.Play("Jump");

        StartCoroutine(JumpAnimation(initialScale, newScale, duration));
        StartCoroutine(JumpAnimation(newScale, initialScale, duration));
        
        jumpRemember -= Time.deltaTime;
    }

    private IEnumerator JumpAnimation(Vector2 min, Vector2 max, float dur)
    {
        float rate = (1f / dur) * speed;
        float i = 0f;

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            
            transform.localScale = Vector2.Lerp(min, max, i);
            
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube((Vector2) transform.position - new Vector2(0f, 1f), new Vector2(0.96f, 0.5f));
    }
}
