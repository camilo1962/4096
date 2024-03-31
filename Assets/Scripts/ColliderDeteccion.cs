using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeteccion : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject bola;

    public GameObject sigObject;

    private bool actividad = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ha entrdo una bola");
        CollapseManager.Instance.panelPalmao.SetActive(true);
        if (other.tag == "Player")
        {
            sigObject.SetActive(true);
            if (!actividad)
            {
                actividad = true;

                audioSource.enabled = true;
                bola.SetActive(true);
                CollapseManager.Instance.panelGameOver.SetActive(true);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
