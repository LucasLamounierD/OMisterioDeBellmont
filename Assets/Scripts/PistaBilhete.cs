using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour, IInventoryItem
{
   public string Name
    {
        get
        {
            return "Bilhete";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public void OnDrop(Vector3 position)
    {
        
        float posi = Random.Range(1.0f, 2.0f);

        position[0] += posi;
        position[1] += posi;
        position[2] += posi;
        gameObject.transform.position = position;
        gameObject.SetActive(true);
    }
}
