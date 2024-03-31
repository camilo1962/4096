using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int record;
    public void Awake()
    {
       instance = this;
       
    }
    public TMP_Text scoreText;
    public TMP_Text scoreTextFinal;
    public GameObject panelGameOver;
    

    public TMP_Text recordText;
   
  
    void Start()
    {
        record = PlayerPrefs.HasKey("best") ? PlayerPrefs.GetInt("best") :0;
        scoreText.text = Spawner.instance.clic.ToString();
        recordText.text = record.ToString();
    }

    
    void Update()
    {

       
    }



}
