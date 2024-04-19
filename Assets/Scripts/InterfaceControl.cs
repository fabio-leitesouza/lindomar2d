using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceControl : MonoBehaviour
{
    public Slider SliderCollections;
    public int TotalCollections = 10;
    private PlayerController scriptPlayerController;

    // Start is called before the first frame update
    void Start()
    {
        SliderCollections.maxValue = TotalCollections;
        scriptPlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void UpdateSliderCollections()
    {
        if (scriptPlayerController != null)
        {
            SliderCollections.value = scriptPlayerController.Collections;
        }
        else
        {
            Debug.LogWarning("PlayerController not found!");
        }
    }
}
