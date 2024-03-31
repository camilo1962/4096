using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [SerializeField] private float _sencetivity = 25f;
    [SerializeField] private float _maxXPosition = 2.5f;
    private float _xPosition;
    //������� ���� �� � � ���������� �����
    private float _oldMouseX;
    public int clic;

    private void Awake()
    {
       instance = this;
         
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMouseX = Input.mousePosition.x;
            clic++;
        }
        if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - _oldMouseX;
            _oldMouseX = Input.mousePosition.x;
            _xPosition += delta * _sencetivity / Screen.width;
            _xPosition = Mathf.Clamp(_xPosition, -_maxXPosition, _maxXPosition);
            transform.position = new Vector3(_xPosition, transform.position.y, transform.position.z);
            
        }
       
    }
}
