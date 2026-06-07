using UnityEngine;
using System;

public abstract class PickUpitem : MonoBehaviour
{
  public event Action<PickUpitem> OnPickUp;

  public virtual void PickUp(basecharacter character)
    {
        OnPickUp?.Invoke(this);
    }
    private void OnTriggerEnter(Collider other)
{
    var character = other.GetComponent<basecharacter>();
    if (character != null)
    {
        PickUp(character);
        Destroy(gameObject); 
    }
}
}
