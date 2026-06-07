using UnityEngine;

public class spawnPickup : MonoBehaviour
{
[SerializeField] 
private PickUpitem _pickupPrefab;
 [SerializeField]
 private float _spawnRadius = 5f;
[SerializeField]
 private int _spawnedPickupCount = 2;
[SerializeField]
private float _respawnTime = 10f;

[SerializeField]
private float _minRespawnTime = 5f;  
[SerializeField]
private float _maxRespawnTime = 15f; 

private float _currentRespawnTime;
private int _currentPickupCount;
private float _nextSpawnDelay;

   protected void Start()
    {
        _currentPickupCount = 0;
        _nextSpawnDelay = Random.Range(_minRespawnTime, _maxRespawnTime);
        _currentRespawnTime = 0f;
    }

protected void Update()
{
    if(_currentPickupCount < _spawnedPickupCount)
    {
       _currentRespawnTime += Time.deltaTime;   
       if( _currentRespawnTime >= _nextSpawnDelay)
       {
        _currentRespawnTime = 0f;
        _currentPickupCount++;

        var Randominside = Random.insideUnitCircle * _spawnRadius;
        var randomposition = new Vector3(Randominside.x, 0f, Randominside.y) + transform.position;

        var pickup = Instantiate(_pickupPrefab, randomposition, Quaternion.identity, transform);
       pickup.OnPickUp += OnItemPickUp;

        _nextSpawnDelay = Random.Range(_minRespawnTime, _maxRespawnTime);
       }
    }

}

private void  OnItemPickUp(PickUpitem item)
    {
        _currentPickupCount--;
        item.OnPickUp -= OnItemPickUp;
    }
 protected void OnDrawGizmos()

 {
    var lastcolor = Gizmos.color;
        var position = transform.position;
#if UNITY_EDITOR
         UnityEditor.Handles.color = Color.black;
        UnityEditor.Handles.DrawWireDisc(position, Vector3.up, _spawnRadius);
#endif
        Gizmos.color = lastcolor;
 }
}
