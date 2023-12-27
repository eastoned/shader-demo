using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{
    [SerializeField]
    private Material _transformMaterial;

    [SerializeField]
    private Vector3 cachedPosition;
    [SerializeField]
    private Vector3 cachedRotation;
    public float speed;
    private void Start()
    {
        cachedPosition = transform.position;
        cachedRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        //shader needs a cached position and an interpolator since it already has current position
        cachedPosition = Vector3.Lerp(cachedPosition, transform.position, Time.deltaTime * speed);
        cachedRotation = Vector3.Lerp(cachedRotation, transform.localEulerAngles, Time.deltaTime * speed);
        _transformMaterial.SetVector("_OldPos", cachedPosition);

        _transformMaterial.SetVector("_CurrentRot", transform.localEulerAngles);
        _transformMaterial.SetVector("_OldRot", cachedRotation);
    }
}
