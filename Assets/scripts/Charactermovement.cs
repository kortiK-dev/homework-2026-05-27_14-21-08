using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class Charactermovement : MonoBehaviour
{

    
    [SerializeField ] [UnityEngine.Range(0f,10f)]
    private float speed = 1f;
    [SerializeField ] [UnityEngine.Range(0f,45f)]
    private float rotationspeed = 1f;
    [SerializeField]
    private CharacterController _chacatercont;

    public Vector3 movementdirection {get ; set;}
    public Vector3 viewdirection {get ; set;}
    
    public float SpeedMultiplier { get; set; } = 1f;

    private void Awake()
    {
        _chacatercont = GetComponent<CharacterController>();
         
    }

    private void Update()
    {
       Translate();
       rotate();
    }
    private void Translate()
    {
        if (movementdirection != Vector3.zero)
        {
        var delta = movementdirection * speed * SpeedMultiplier * Time.deltaTime;
        _chacatercont.Move(delta);
        }
    }

    private void rotate()
    {
        if (viewdirection != Vector3.zero)
        {
           var tagerrotat = Quaternion.LookRotation(viewdirection);
           transform.rotation = Quaternion.Slerp(transform.rotation,tagerrotat,rotationspeed *Time.deltaTime);
        }
    }


}
