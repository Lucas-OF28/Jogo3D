using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject painelGameOver;
    public int moedasNaFase;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DescontarMoedas()
    {
        moedasNaFase -= 1;        
    }
    public void GameOver()
    {
        painelGameOver.SetActive(true);
        Invoke("RecarregarLevel", 2);
    }
    public void RecarregarLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
