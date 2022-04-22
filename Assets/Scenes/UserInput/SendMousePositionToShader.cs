using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMousePositionToShader : MonoBehaviour
{

    [SerializeField]
    private string _varName;

    private Vector4 _playerPos;

    //Renderer _rend;

    // Start is called before the first frame update
    void Start()
    {
        //_rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit _hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100f))
            {
               // Debug.Log(_hit.collider);
                _playerPos = _hit.point;
                Debug.Log(_playerPos);
            }
        }

        Shader.SetGlobalVector(_varName, _playerPos);

        //can be added to individual objects for different variables
        //_rend.material.SetVector(_varName, _speed);
    }
}
