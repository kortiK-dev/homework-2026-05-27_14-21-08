using UnityEngine;

public class Pickupbonus : PickUpitem
{
    [SerializeField] 
    private float _speedMultiplier = 2f; 
    
    [SerializeField] 
    private float _duration = 5f; 

    public override void PickUp(basecharacter character)
    {
        base.PickUp(character);
        
        character.ApplySpeedBoost(_speedMultiplier, _duration);
    }
}