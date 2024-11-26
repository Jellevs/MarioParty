using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStore : MonoBehaviour
{
    public List<Item> StoreInventory = new();
    public delegate Item ItemCreator();
    public int StoreInventoryMaximumSize = 3;


    public void Awake()
    {
        RestockStoreInventory();
        foreach (Item item in StoreInventory) {
            print(item);
        }
    }

    public void RestockStoreInventory()
    {
        for (int i = StoreInventory.Count; i < StoreInventoryMaximumSize; i++)
        {
            StoreInventory.Add(GenerateRandomItem());
        }
    }

    public Item GenerateRandomItem()
    {
        int randomIndex = Random.Range(0, ItemList.Count);
        return ItemList[randomIndex]();
    }

    public List<ItemCreator> ItemList = new() 
    {
        () => new DefaultDice(),
        () => new OneTwoThreeDice()
    };
}
