using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{

    public ParticleSystem particles;
    public AudioSource audioSource;

    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
            audioSource.Play();

        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;//it doesnt count or moving after blast
        anim.SetTrigger("dead");
        particles.Play();



    }

    private void RestartLevel() => SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name);
}
