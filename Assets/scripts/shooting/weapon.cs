using UnityEngine;
using UnityEngine.AI;

public class weapon : MonoBehaviour
{

    [SerializeField]
    public Transform _bulletspawn ;
    [SerializeField]
    private bullet _bulletprefab;
    [SerializeField]
    private float _bulletdamage = 1f;
    [SerializeField]
    private float _bulletspeed = 10f;

    [SerializeField]
    private float _bulletmaxflydis = 10f ;

    [field:SerializeField]
    public float _shootradius{get; private set;} = 5f;
    [field:SerializeField]
    public float _shootspeed{get; private set;} = 1f;

    public void shoot (Vector3 targetpoint )
    {
        var bullet = Instantiate(_bulletprefab, _bulletspawn.position, Quaternion.identity);
        var targetdirection = targetpoint - _bulletspawn.position;
        targetdirection.y = 0f;
        targetdirection.Normalize();
        bullet.Initialize(_bulletdamage, targetdirection, _bulletspeed, _bulletmaxflydis);
    }
}
