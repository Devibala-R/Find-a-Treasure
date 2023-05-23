using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float horizontalX;
    public float speed;
    public float jumpingPower;
    private Animator anim;
    public Vector2 boxsize;
    public float maxDistance;

    private bool isGround=true;


    public AudioSource audioSource;


    [SerializeField] private Rigidbody2D rb;


    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") &&  ground())
        {

           
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isJumping = true;

            if (isJumping)
            {
                audioSource.Play();

                isJumping = false;
            }

            ground();
        }

        if (horizontalX == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else if (horizontalX > 0)
        {
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(2.5f, 2, 1);
        }
        else
        {
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(-2.5f, 2, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }


    }
    bool ground()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, Vector3.down, maxDistance))
        {
           return true;;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "powerup")
        {
            Destroy(collision.gameObject);
            speed = 7f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(5);
        speed = 3f;
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}

