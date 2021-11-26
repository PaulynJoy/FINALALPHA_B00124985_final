using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scorePointText;
    public Text highScoreText;

    public float scoreCounter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter += Time.deltaTime;
        scorePointText.text = ((int)scoreCounter).ToString();
  
        
    }
}
