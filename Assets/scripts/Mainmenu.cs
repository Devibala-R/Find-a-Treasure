using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStartButton() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void OnStartAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    //public void OnExitButton() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

}
