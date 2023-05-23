using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text points;
    public void Setup(int score){

        gameObject.SetActive(true);
        points.text =score.ToString()+ "Points";
    }
}
