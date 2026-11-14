using Golf.TZ;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private RainController rainController;
    [SerializeField] private ItemSwitcher itemSwitcher;

    void Awake()
    {
        if (stoneSpawner == null || rainController == null || itemSwitcher == null)
        {
            Debug.LogError("TaskManager настроен некорректно!");
            enabled = false;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            stoneSpawner.SpawnStone();
        
        if (Input.GetKeyDown(KeyCode.Z))
            rainController.StartRain();

        if (Input.GetKeyDown(KeyCode.Space))
            itemSwitcher.SwitchItem();
    }
}
