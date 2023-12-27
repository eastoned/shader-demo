using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SendQuadToVFX : MonoBehaviour
{

    [SerializeField]
    private VisualEffect _Cross, _Cross2;

    

    // Update is called once per frame
    void Update()
    {
        _Cross.SetVector3("PlanePos", transform.position);
        _Cross.SetVector3("PlaneNormal", transform.localEulerAngles.normalized);

        _Cross2.SetVector3("PlanePos", transform.position);
        _Cross2.SetVector3("PlaneNormal", transform.localEulerAngles.normalized);
    }
}
