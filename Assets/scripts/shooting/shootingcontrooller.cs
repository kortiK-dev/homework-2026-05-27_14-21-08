
using UnityEngine;
using UnityEngine.UIElements;

public class shootingcontrooller : MonoBehaviour
{
    public bool Misevil => _evil != null;
    public Vector3 Targetposition
    {
        get
        {
            if(Misevil)
            return _evil.transform.position;
            return Vector3.zero;
        }
    }
    private weapon _weapon = null;

    private float _nextshoottime;

    private GameObject _evil = null ;

    private Collider[] _coliider = new Collider[10];

    [SerializeField] private string targetLayerName;

    private void Update()
    {
        _evil = Gettarget();
        _nextshoottime -= Time.deltaTime;
        if (_nextshoottime <= 0f)
        {
            if(Misevil)
            _weapon.shoot(_evil.transform.position);
             _nextshoottime = _weapon._shootspeed;
        }
        
    }
    public void SetWeapon(weapon weaponprefab, Transform hand)
    {
        if(_weapon != null)
        {
            Destroy(_weapon.gameObject);
        }

        _weapon = Instantiate(weaponprefab, hand);
        _weapon.transform.localPosition =  Vector3.zero;
        _weapon.transform.localRotation = weaponprefab.transform.localRotation;
    }

    private GameObject Gettarget()
    {
        GameObject target = null;
        var position = _weapon.transform.position;
        var radius = _weapon._shootradius;
        var layer = LayerMask.GetMask(targetLayerName);
        var size = Physics.OverlapSphereNonAlloc(position, radius, _coliider, layer);
        if (size > 0 )
        {
            target = _coliider[0].gameObject;
        }
        return target;
    }

    private void OnDrawGizmos()
    {
        if(_weapon != null)
        {
        var position = _weapon.transform.position;
        var radius = _weapon._shootradius;
#if UNITY_EDITOR
         UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.DrawWireDisc(position, Vector3.up, radius);
#endif
        }
    }
}