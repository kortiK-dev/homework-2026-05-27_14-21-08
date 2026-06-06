using System;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField]
    private Vector3 _fullsecption = Vector3.zero;
     [SerializeField]
    private Vector3 _rotainsecption = Vector3.zero;
    [SerializeField]
  private Transform taget ;

    private void Awake()
    {
        if (taget == null)
        throw new NullReferenceException("camera is not");
    }

    private void LateUpdate()
    {
        Vector3 targetrotaion = _rotainsecption - _fullsecption;
        transform.position = taget.position + _fullsecption;
        transform.rotation = Quaternion.LookRotation(targetrotaion, Vector3.up);
    }
}
