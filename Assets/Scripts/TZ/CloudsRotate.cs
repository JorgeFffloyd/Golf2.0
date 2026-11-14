using UnityEngine;

namespace Golf.TZ
{
    public class CloudsRotate : MonoBehaviour
    {
        [Header("Rotate Settings")]
        [SerializeField] private float rotateSpeed = 1f;

        void Update()
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
