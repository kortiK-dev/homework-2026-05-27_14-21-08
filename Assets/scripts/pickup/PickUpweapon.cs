using UnityEngine;

public class PickUpweapon : PickUpitem
{
  [SerializeField] 
  private weapon _weaponPrefab;



  public override void PickUp(basecharacter character)
  {
        base.PickUp(character);
    character.SetWeapon(_weaponPrefab);
  }
}
