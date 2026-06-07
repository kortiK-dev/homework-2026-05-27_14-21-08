using UnityEngine;


[RequireComponent(typeof(Playerinputcontroller))]
[RequireComponent(typeof(Charactermovement))]
[RequireComponent(typeof(shootingcontrooller))]
public abstract class basecharacter : MonoBehaviour
{

    [SerializeField]
    private weapon _baseweaponprefab;
    [SerializeField]
    private Transform _hand;
    protected Charactermovement _Charactermovement;
    private shootingcontrooller _shootingcontrooller;
    [SerializeField]
    private float _heal = 10f;


    protected virtual void Awake()
    {
         _Charactermovement = GetComponent<Charactermovement>();
         _shootingcontrooller = GetComponent<shootingcontrooller>();
    }

    protected void Start()
    {
        SetWeapon(_baseweaponprefab);
    }
    protected void Update()
    {
        var direction = GetMovmentDire() ;
        var viewdirection = direction ; 
        if(_shootingcontrooller.Misevil)
        {
            viewdirection = _shootingcontrooller.Targetposition - transform.position;
            viewdirection.y = 0f;
            viewdirection.Normalize();
        }
        _Charactermovement.movementdirection =  direction;
        _Charactermovement.viewdirection =  viewdirection;

        if(_heal <= 0f )
        Destroy(gameObject);
    }

    public void SetWeapon(weapon weaponPrefab)
    {
        _shootingcontrooller.SetWeapon(weaponPrefab, _hand);
    }
    protected abstract Vector3 GetMovmentDire();
    protected void OnTriggerEnter(Collider other)
    {
        if(Layer.Inbullet(other.gameObject))
        {
            var bullet = other.GetComponent<bullet>();
            _heal -= bullet.Damage;
            Destroy(bullet.gameObject);
        }
    else if(Layer.InPickUp(other.gameObject)) 
{
    var pickup = other.GetComponent<PickUpitem>();
    if(pickup != null)
    {
        pickup.PickUp(this);
        Destroy(other.gameObject);
    }
}
    }
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawCube(_hand.position , new Vector3(0.2f,0.2f,0.2f));
    }

   public void ApplySpeedBoost(float multiplier, float duration)
{
    StartCoroutine(SpeedBoostCoroutine(multiplier, duration));
}

private System.Collections.IEnumerator SpeedBoostCoroutine(float multiplier, float duration)
{
   
    _Charactermovement.SpeedMultiplier = multiplier;
    
   
    yield return new WaitForSeconds(duration);
    
   
    _Charactermovement.SpeedMultiplier = 1f;
}
}
