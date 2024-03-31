using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollapseManager : MonoBehaviour
{
    public static CollapseManager Instance ; 
    
    public TMP_Text scoreText;
    public TMP_Text scoreTextFinal;
    public GameObject panelGameOver;
    public GameObject panelPalmao;




    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
        panelGameOver.SetActive(false);
        panelPalmao.SetActive(false);


    }

    public void Collapse(ActiveItem itemA, ActiveItem itemB)
    {
        StartCoroutine(CollapseProcess(itemA, itemB));
       
        
    }

    public IEnumerator CollapseProcess(ActiveItem itemA,ActiveItem itemB)
    {
        itemA.Disable();
        Vector3 startPosition = itemA.transform.position;
        for (float t = 0f; t < 1f; t+=Time.deltaTime / 0.08f)        
        {
            itemA.transform.position = Vector3.Lerp(startPosition, itemB.transform.position, t);
            yield return null;
        }
        itemA.transform.position = itemB.transform.position;
        itemA.Die();
        itemB.Increaselevel();
    }
    public void Update()
    {
        scoreText.text = Spawner.instance.clic.ToString();
        
        

    }

}
