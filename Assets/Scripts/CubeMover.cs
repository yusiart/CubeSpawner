using UnityEngine;
using Random = UnityEngine.Random;

public class CubeMover : MonoBehaviour
{
    private float _distanceToDestroy;
    private float _speed;
    private Vector3 _randomDirection;
    private Vector3 _targetPos;

    public CubeMover(float speed, float distanceToDestroy)
    {
        _speed = speed;
        _distanceToDestroy = distanceToDestroy;
    }

    private void OnEnable()
    {
        _randomDirection = new Vector3(Random.Range(-1f, 1f),0, Random.Range(-1f, 1f));
        SetPath();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        
        if (transform.position == _targetPos)
        {
            Destroy(gameObject);
        }
    }
    
    private void SetPath()
    {
        _targetPos = transform.position + _randomDirection * _distanceToDestroy;
    }

    public void SetSpeedAndDistance(float distanceToDestroy, float speed)
    {
        _distanceToDestroy = distanceToDestroy;
        _speed = speed;
    }
}