using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class ActiveItem : MonoBehaviour
{
    public static ActiveItem instance { get; private set; }
    
    public int Level;
    public float Radius;
    [SerializeField] protected Text _levelText;

    [SerializeField] private Transform _visualtransform;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private SphereCollider _trigger;
    /// <summary>
    public TMP_Text maximoText;
 
    /// </summary>

    public Rigidbody Rigidbody;
    public bool IsDead;
    public int score;
    
    [SerializeField] private Animator _animator;

    public Projection Projection;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Projection.Hide();


        
    }

    [ContextMenu("IncreaseLevel")]
    public void Increaselevel()
    {
        Level++;
        SetLevel(Level);
        _animator.SetTrigger("IncreaseLevel");
        _trigger.enabled = false;
        Invoke(nameof(EnableTrigger), 0.1f);
        score++;
        
    }
    

    public virtual void SetLevel(int level)
    {
        Level = level;
        //��������� ����� �� ����
        int number = (int)Mathf.Pow(2, level + 1);
        string numberString = number.ToString();
        _levelText.text = numberString;

        Radius = Mathf.Lerp(0.4f, 0.7f, level / 10f);
        Vector3 ballScale = Vector3.one * Radius * 2f;
        _visualtransform.localScale = ballScale;
        _collider.radius = Radius;
        _trigger.radius = Radius + 0.1f;
        if (number == 4096)
        {
           
            
            CollapseManager.Instance.panelGameOver.SetActive(true); 
            CollapseManager.Instance.scoreTextFinal.text = Spawner.instance.clic.ToString();

            int clic = Spawner.instance.clic;

            PlayerPrefs.SetInt("best", clic);
            //maximoText.text = PlayerPrefs.GetInt("best").ToString();
            if (clic < PlayerPrefs.GetInt("best"))
            {
                PlayerPrefs.SetInt("best", clic);
                maximoText.text = PlayerPrefs.GetInt("best").ToString();
                //ScoreManager.instance.recordText.text = PlayerPrefs.GetInt("best").ToString();
            }
            PlayerPrefs.Save();
        }
    }
    

    void EnableTrigger()
    {
        _trigger.enabled = true;
    }

    //������������� Item � �����

    public void SetupInTube()
    {
        //��������� ������
        _trigger.enabled = false;
        _collider.enabled = false;
        Rigidbody.isKinematic = true;
        Rigidbody.interpolation = RigidbodyInterpolation.None;
    }

    public void Drop()
    {
        //�������� ������ ����
        _trigger.enabled = true;
        _collider.enabled = true;
        Rigidbody.isKinematic = false;
        Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        //������������� �� ������
        transform.parent = null;
        //������ �������� ����, ����� ����� �������
        Rigidbody.velocity = Vector3.down * 1.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsDead)
        {
            return;
        }

        if (other.attachedRigidbody)
        {
            ActiveItem otheritem = other.attachedRigidbody.GetComponent<ActiveItem>();
            
            if (otheritem)
            {
                if (Level == otheritem.Level && !otheritem.IsDead)
                {
                    CollapseManager.Instance.Collapse(this, otheritem);
                   
                }
            }
        }
    }

    public void Disable()
    {
        _trigger.enabled = false;
        _collider.enabled = false;
        Rigidbody.isKinematic = true;
        IsDead = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

   
  
}
