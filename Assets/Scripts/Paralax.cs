using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform[] backgrounds; // Array para armazenar os planos de fundo
    private float[] parallaxScales; // A proporção do movimento do plano de fundo em relação à câmera
    public float smoothing = 1f; // Quão suavemente o plano de fundo se moverá

    private Transform cam; // Referência à câmera principal
    private Vector3 previousCamPos; // A posição da câmera na frame anterior

    void Awake()
    {
        // Configurando a referência da câmera
        cam = Camera.main.transform;
    }

    void Start()
    {
        // Armazenando as posições iniciais da câmera
        previousCamPos = cam.position;

        // Configurando a proporção do parallax para cada plano de fundo
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        // Para cada plano de fundo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // O parallax é o oposto do movimento da câmera, multiplicado pelo parallaxScale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Definindo uma posição alvo x que é a posição atual mais o parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Criando uma posição alvo que é a posição atual com a posição x alvo
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Suavizando a transição entre a posição atual e a posição alvo
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Atualizando a posição da câmera anterior para a posição da câmera atual no final do frame
        previousCamPos = cam.position;
    }
}