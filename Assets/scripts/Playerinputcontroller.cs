using UnityEngine;

public class Playerinputcontroller : MonoBehaviour
{
    private Camera _camre;
       public Vector3 movementdirection {get; private set;}
    private void Awake()
    {
        _camre = Camera.main;
    }
    void Update()
    {
        var horizontol = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var directional = new Vector3(horizontol, 0f , vertical).normalized;
         directional = _camre.transform.rotation * directional;
         directional.y = 0f;
         movementdirection = directional;
    }
}
