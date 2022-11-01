using UnityEngine;

[RequireComponent(typeof(CubeMover))]
public class Cube : MonoBehaviour
{
    private CubeMover _cubeMover;

    private void Awake()
    {
        _cubeMover = GetComponent<CubeMover>();
        _cubeMover.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Plane plane))
        {
            _cubeMover.enabled = true;
        }
    }
}
