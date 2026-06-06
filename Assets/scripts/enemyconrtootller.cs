using UnityEngine;

public class enemyconrtootllerScript : basecharacter
{
    private Transform _player;

   protected override void Awake()
{
    base.Awake();
    _player = GameObject.FindGameObjectWithTag("Player")?.transform;
}
protected override Vector3 GetMovmentDire()
{
    if (_player == null) return Vector3.zero;

    var dir = _player.position - transform.position;
    dir.y = 0f;

    return dir.normalized;
}
}