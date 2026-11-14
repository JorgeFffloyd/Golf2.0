using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StoneController : MonoBehaviour
{
    [Header("Stone Settings")]
    [SerializeField] private float lifetime = 5f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
