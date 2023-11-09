using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Inimigo : MonoBehaviour
{
    private Animator animInimigo;
    private NavMeshAgent navMesh;
    private GameObject player;
    public float velocidadInimigo;
    private GameObject maoInimigo;

    void Start()
    {
        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        maoInimigo = GameObject.FindWithTag("maoInimigo");
        navMesh.speed = velocidadInimigo;
        maoInimigo.SetActive(false); 
    }

    void Update()
    {
        navMesh.destination = player.transform.position;
        animInimigo.SetBool("walk", true);

        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            navMesh.speed = 0;
            maoInimigo.SetActive(true);
            animInimigo.SetBool("atack", true);
            StartCoroutine(Ataque()); // Corrigi o nome da corrotina para "Ataque"
        }
    }

    IEnumerator Ataque()
    {
        yield return new WaitForSeconds(2.8f);
        navMesh.speed = velocidadInimigo;
        animInimigo.SetBool("atack", false);
        maoInimigo.SetActive(false);
    }
}

