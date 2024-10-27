using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DummyInventory : MonoBehaviour {

    public event Action<ItemSO> OnItemSelected;

    [SerializeField] private List<ItemSO> itemList;
    [SerializeField] private Transform itemTemplate;

    [Header("INVENTORY")]
    [SerializeField] GameObject inventoryPanel;

    private Transform itemGrid; // parent
    private Dictionary<ItemSO, Transform> itemSOTransformDic;

    [Header("Debuging")]
    [SerializeField] Pickupable[] pickableItems;


    private void Awake() {
        itemTemplate.gameObject.SetActive(false);

        itemSOTransformDic = new Dictionary<ItemSO, Transform>();

        foreach (ItemSO itemSO in itemList) {
            Transform itemTransform = Instantiate(itemTemplate, itemTemplate.parent);
            itemTransform.gameObject.SetActive(true);
            itemTransform.Find("Image").GetComponent<Image>().sprite = itemSO.sprite;

            itemSOTransformDic[itemSO] = itemTransform;

            itemTransform.GetComponent<Button>().onClick.AddListener(() => {
                SelectItem(itemSO);
            }); //these are all buttons so I will need to make all of the items buttons damn
        }
    }
    private void Start()
    {
        pickableItems = GameObject.FindObjectsOfType<Pickupable>();
        if(pickableItems != null)
        {
            foreach (var item in pickableItems)
            {
                item.GetComponent<IItemInteractable>().OnItemPickUp += AddItem;
            }
        }
       
    }

    //write me a function to add items to the inventory
    public void AddItem(ItemSO itemSO)
    {
        itemList.Add(itemSO);
        Transform itemTransform = Instantiate(itemTemplate, itemTemplate.parent);
        itemTransform.gameObject.SetActive(true);
        itemTransform.Find("Image").GetComponent<Image>().sprite = itemSO.sprite;

        itemSOTransformDic[itemSO] = itemTransform;

        itemTransform.GetComponent<Button>().onClick.AddListener(() =>
        {
            SelectItem(itemSO);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            HandleOpenInventory();
        }
    }
    void HandleOpenInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    private void SelectItem(ItemSO selectedItemSO) 
    { 
        foreach (ItemSO itemSO in itemSOTransformDic.Keys) {
            itemSOTransformDic[itemSO].Find("Selected").gameObject.SetActive(false); //close all other selected items when a new item is selected
        }

        itemSOTransformDic[selectedItemSO].Find("Selected").gameObject.SetActive(true); 

        OnItemSelected?.Invoke(selectedItemSO); 
    }

}

