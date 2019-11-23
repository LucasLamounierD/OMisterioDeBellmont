using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    public GameObject player;
    public GameObject Panel;

    public GameObject camera;
    public Sprite selectedItem = null;

    public void AddObject()
    {

        if (Panel != null)
        {
            if(player.GetComponent<Player>().inventory.obj != null)
                selectedItem = player.GetComponent<Player>().inventory.obj.transform.GetChild(0).GetComponent<Image>().sprite;

            if (selectedItem == null)
            {
                Debug.Log(player.GetComponent<Player>().currentObject);
                Panel.SetActive(false);
                //player.GetComponent<Player>().pistas.Add(player.GetComponent<Player>().currentObject.GetComponent<IInventoryItem>());
                player.GetComponent<Player>().inventory.AddItem(player.GetComponent<Player>().currentObject.GetComponent<IInventoryItem>());
                //player.GetComponent<Player>().currentObject = null;
            }
            else
            {
                foreach (IInventoryItem item in player.GetComponent<Player>().inventory.myItems)
                {
                    if (item.Image == selectedItem)
                    {
                        Vector3 position = player.transform.position;
                        item.OnDrop(position);
                        player.GetComponent<Player>().inventory.RemoveItem(item);
                        player.GetComponent<Player>().inventory.obj.transform.GetChild(0).GetComponent<Image>().enabled = false;
                        player.GetComponent<Player>().inventory.obj = null;
                        ClosePanel();
                        break;
                    }
                }
            }
        }
    }

    public void OpenPanelByInventory()
    {
        selectedItem = this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        Debug.Log(selectedItem);
        if (this.gameObject.transform.GetChild(0).GetComponent<Image>().enabled) {
            player.GetComponent<Player>().inventory.obj = this.gameObject;
            Panel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = selectedItem;
            Panel.SetActive(true);
        }
    }

    public void ClosePanel()
    {

        camera.GetComponent<CameraController>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Panel != null)
        {
            Panel.SetActive(false);
            selectedItem = null;
        }
    }
}
