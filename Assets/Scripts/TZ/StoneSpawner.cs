using UnityEngine;

namespace Golf.TZ
{
    public class StoneSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject stonePrefab;
        [SerializeField] private Transform[] spawnPoints;
    
        [Header("Stone Settings")]
        [SerializeField] private float launchForce = 250f;
    
        private int currentIndex;

        public void SpawnStone()
        {
            if (stonePrefab == null)
            {
                Debug.LogError("Префаб не назначен!");
                return;
            }
        
            GameObject stone = Instantiate(stonePrefab, spawnPoints[currentIndex].position, Quaternion.identity);
        
            Rigidbody rb = stone.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoints[currentIndex].forward * launchForce, ForceMode.Impulse);
        
            currentIndex++;
        
            if (currentIndex >= spawnPoints.Length)
                currentIndex = 0;
        }
    }
}
