using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] targets;
    [SerializeField] private ParticleSystem rainParticles; 
    
    [Header("Cloud Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float cloudHeight = 10f;

    private int currentIndex;
    private CloudState currentState;

    void Start()
    {
        currentState = CloudState.Raining;
    }

    private enum CloudState
    {
        Moving,
        Raining,
    }

    private IEnumerator MoveRoutine()
    {
        if (targets == null || targets.Length == 0)
        {
            Debug.LogError("Targets не назначены!");
            yield break;
        }
        
        if (rainParticles == null)
        {
            Debug.LogError("RainParticles не назначен!");
            yield break;
        }
        
        currentState = CloudState.Moving;

        rainParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        Vector3 targetPos = targets[currentIndex].position;
        targetPos.y += cloudHeight;
        
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        currentIndex++;
        
        if (currentIndex >= targets.Length)
            currentIndex = 0;
        
        rainParticles.Play();
        
        currentState = CloudState.Raining;
    }

    public void StartRain()
    {
        if (currentState != CloudState.Raining)
            return;
        
        StartCoroutine(MoveRoutine());
    }
}
