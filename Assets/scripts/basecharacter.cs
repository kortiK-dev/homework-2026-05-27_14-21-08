using UnityEngine;


[RequireComponent(typeof(Playerinputcontroller))]
[RequireComponent(typeof(Charactermovement))]
[RequireComponent(typeof(shootingcontrooller))]
public abstract class basecharacter : MonoBehaviour
{

    [SerializeField]
    private weapon _weaponprefab;
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
        _shootingcontrooller.SetWeapon(_weaponprefab, _hand);
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
     protected abstract Vector3 GetMovmentDire();
    protected void OnTriggerEnter(Collider other)
    {
        if(Layer.Inbullet(other.gameObject))
        {
            var bullet = other.GetComponent<bullet>();
            _heal -= bullet.Damage;
            Destroy(bullet.gameObject);
        }
    }
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawCube(_hand.position , new Vector3(0.2f,0.2f,0.2f));
    }

   
}
