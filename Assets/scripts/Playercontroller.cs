using UnityEngine;
[RequireComponent(typeof(Playerinputcontroller))]
public class Playercontroller : basecharacter
{
    private Playerinputcontroller _Playerinputcontroller;

    [SerializeField] private float _sprintMultiplier = 2f; 


    protected void Awake()
    {
        base.Awake();
         _Playerinputcontroller = GetComponent<Playerinputcontroller>();
 
    }

    protected override Vector3 GetMovmentDire()
    {
        return _Playerinputcontroller.movementdirection;
    }
     protected new void Update()
    {
    
        base.Update();

       
        if (_Charactermovement != null)
        {
            if (Input.GetKey(KeyCode.Space))
                _Charactermovement.SpeedMultiplier = _sprintMultiplier;
            else
                _Charactermovement.SpeedMultiplier = 1f;
        }
    }
}

