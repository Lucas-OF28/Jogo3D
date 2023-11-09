using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Jar"))
        {
            score = score + 1;
            Destroy(col.gameObject);
            UpdateScoreText();
            if(score == 7)
            {

            }
        }
    }
    void UpdateScoreText()
    {
        scoreTxt.text = "Jarras coletadas: " + score.ToString();
    }
}
