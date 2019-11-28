using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 6;

    public List<IInventoryItem> myItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public GameObject obj = null;
    public GameObject camera;

    public void AddItem(IInventoryItem item)
    {
        if (myItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;

                myItems.Add(item);

                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }else{
            if(myItems.Count == SLOTS){
                SceneManager.LoadSceneAsync("ChoiceMenu");
            }
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camera.GetComponent<CameraController>().enabled = true;
    }

    public void RemoveItem(IInventoryItem item)
    {
        Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
        collider.enabled = true;
        myItems.Remove(item);
    }
}
