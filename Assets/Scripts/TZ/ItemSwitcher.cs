using UnityEngine;

public class ItemSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefabs;

    public void SwitchItem()
    {
        if (itemPrefabs == null || itemPrefabs.Length == 0)
        {
            Debug.LogError("Предметы не назначены!");
            return;
        }
        
        GameObject[] currentItems = GameObject.FindGameObjectsWithTag("NPC Item");

        if (currentItems == null || currentItems.Length == 0)
        {
            Debug.LogError("Предметы с тегом NPC Item не найдены!");
            return;
        }

        foreach (GameObject item in currentItems)
        {
            ItemId itemId = item.GetComponent<ItemId>();

            if (itemId == null)
            {
                Debug.LogError($"На обьекте {item.name} не назначен ItemId!");
            }
            int randomIndex = Random.Range(0, itemPrefabs.Length);

            while (itemPrefabs.Length > 1 && randomIndex == itemId.id)
            {
                randomIndex = Random.Range(0, itemPrefabs.Length);
            }
            
            Transform handPosition = item.transform.parent;
            Destroy(item.gameObject);
            
            GameObject newItem = Instantiate(itemPrefabs[randomIndex], handPosition);

            newItem.transform.localRotation = item.transform.localRotation;
            newItem.transform.localPosition = item.transform.localPosition;
        }
    }
    
    
    
}
