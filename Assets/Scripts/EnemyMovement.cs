using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA; // Primeiro ponto de destino
    public Transform pointB; // Segundo ponto de destino
    public float movementSpeed = 1.0f; // Velocidade de movimento do inimigo

    private Transform currentTarget; // Ponto de destino atual

    private void Start()
    {
        // Define o ponto de destino inicial como pointA
        currentTarget = pointA;
    }

    private void Update()
    {
        // Move o inimigo em direção ao ponto de destino atual
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, movementSpeed * Time.deltaTime);

        // Se o inimigo chegou ao ponto de destino atual, troca o ponto de destino
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
        {
            // Se o ponto de destino atual é pointA, define pointB como o próximo ponto de destino
            if (currentTarget == pointA)
            {
                Debug.Log("Reached point A, moving to point B");
                currentTarget = pointB;
            }
            // Se o ponto de destino atual é pointB, define pointA como o próximo ponto de destino
            else
            {
                Debug.Log("Reached point B, moving to point A");
                currentTarget = pointA;
            }
        }
    }
}
