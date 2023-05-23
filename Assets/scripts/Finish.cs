using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private AudioSource FinishSound;
    private bool levelCompleted = false;
    // Start is called before the first frame update
   private  void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }
   private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name=="Bob" && !levelCompleted)
        {
            FinishSound.Play();
            levelCompleted=true;
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
