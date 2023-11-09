using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int vidaPlayer = 100;
    public float velocidadeCorrida = 10;
    public float velocidadeAndar = 5;
    public Camera cameraPlayer;
    public GameObject sangue;
    public gameOverScreen gameOver;
    public GameManager gameManager;

    private Vector3 direcoes;
    private Animator anim;
    private float velocidadePlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        sangue.SetActive(false);
        velocidadePlayer = velocidadeAndar; // Defina a velocidade inicial como andar.
    }

    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");
        float InputRun = Input.GetAxis("correr");

        direcoes = new Vector3(InputX, 0, InputZ);
        if (InputX != 0 || InputZ != 0)
        {
            var camrotation = cameraPlayer.transform.rotation;
            camrotation.x = 0;
            camrotation.z = 0;
            anim.SetBool("walk", true);
            transform.Translate(0, 0, velocidadePlayer * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcoes) * camrotation, 5 * Time.deltaTime);

            if (InputRun != 0)
            {
                anim.SetBool("run", true);
                velocidadePlayer = velocidadeCorrida;
            }
            else
            {
                anim.SetBool("run", false);
                velocidadePlayer = velocidadeAndar;
            }
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
        if (vidaPlayer <= 0)
        {
            anim.SetBool("morte", true);
            StartCoroutine(Morte()); // Corrija a chamada para a corrotina Morte
            
            velocidadePlayer = 0;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "maoInimigo")
        {
            vidaPlayer -= 80;
            sangue.SetActive(true);
        }
    }
    IEnumerator Morte()
    {
        yield return new WaitForSeconds(2.8f);
        gameManager.GameOver();
        //SceneManager.LoadScene("GameOver");
    }
}
