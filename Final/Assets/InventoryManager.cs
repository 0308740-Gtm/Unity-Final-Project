using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> inventory = new List<string>();

    public GameObject itemSlotPrefab;
    public Transform Inventorypanel;

    public void AddItem(string item)
    {
        inventory.Add(item);

        GameObject newSlot = Instantiate(itemSlotPrefab, Inventorypanel);
        TMP_Text itemText = newSlot.GetComponentInChildren<TMP_Text>();

        itemText.text = item;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
