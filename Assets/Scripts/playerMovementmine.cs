using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    //static int score;
    public Animator playerAnimator;
    bool midjump = false, isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0f);
        rb.velocity = movement * speed;

        if (horizontal > 0 || horizontal < 0)
        {
            playerAnimator.SetFloat("speed", 5f);
        }
        else 
        {
            playerAnimator.SetFloat("speed", -5f);
        }

        if (isFacingRight == false && horizontal > 0)
        {
            FlipFace();
        }
        else if (isFacingRight == true && horizontal < 0)
        {

            FlipFace();
        }

        if (Input.GetKeyDown("space") /*&& midjump == false*/)
        {
            playerAnimator.SetBool("jump", true);
            transform.Translate(Vector3.up * 60 * Time.deltaTime, Space.World);
            /*rb.velocity = new Vector2(0f, 20f);*/
            midjump = true;
        }
    }
    void FlipFace()
    {
        isFacingRight = !isFacingRight;
        Vector3 scalar = transform.localScale;
        scalar.x *= -1;
        transform.localScale = scalar;

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("jump", false);
            midjump = false;
        }
    }
}




