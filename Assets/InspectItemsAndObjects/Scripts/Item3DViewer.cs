using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler {

    [SerializeField] private DummyInventory inventory;

    private Transform itemPrefab;

    private void Start() {
        inventory.OnItemSelected += OnItemSelected;
    }

    private void OnItemSelected(ItemSO itemSO) {
        if (itemPrefab != null) {
            Destroy(itemPrefab.gameObject);
        }
        Debug.Log("Picked up item: " + itemSO.name);
        itemPrefab = Instantiate(itemSO.prefab, new Vector3(1000, 1000, 1000), Quaternion.identity); //spawn the item far away from the player
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging" + eventData);
        itemPrefab.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
    }

}