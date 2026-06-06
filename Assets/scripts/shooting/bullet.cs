using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Damage {get; private set;}
    private Vector3 _direction;
    private float _speed ;
    private float _maxflydis ;
    private float _currentflydis ;

    public void Initialize(float damage, Vector3 direction, float speed, float maxflydis)
    {
        _currentflydis = 0f;
        Damage = damage; 
        _direction =  direction; 
        _speed = speed; 
        _maxflydis = maxflydis;
    }


    void Update()
    {
        float delta = _speed * Time.deltaTime;
        _currentflydis += delta;
        transform.Translate(_direction * delta) ;

        if (_currentflydis >= _maxflydis)
        Destroy(gameObject);
    
    }
}
