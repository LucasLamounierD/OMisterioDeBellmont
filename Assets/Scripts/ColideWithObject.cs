using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColideWithObject : MonoBehaviour
{
// Eu estou utilizando SerializeField e variáveis 
	// privadas aqui porque a combinação está de acordo 
	// com a convenção de encapsulamento e segurança
	// de código C#.
 
 	public GameObject player;
    public GameObject Panel;

    public GameObject camera;

	[SerializeField] private Color32 _normalColor = new Color32(100, 100, 100,100);
	[SerializeField] private Color32 _highlightColor = new Color32(100, 200, 200,200);
	[SerializeField] private Color32 _activeColor = new Color32(255, 255, 255,255);
 
	private Renderer _renderer; // Todos os renderizadores derivam da classe Renderer.
 
	void Start(){
		player = GameObject.FindWithTag("Player");
	}

		private void Awake ()
	{
		_renderer = GetComponent<Renderer>();
		_renderer.material.color = _normalColor;
	}
 
	private void OnMouseEnter ()
	{
		_renderer.material.color = _highlightColor;
	}
 
	private void OnMouseDown ()
	{
		//GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
		if(this.tag == "Pista"){
            if (Panel != null)
            {
				player.GetComponent<MouseLook>().enabled = false;
        		camera.GetComponent<MouseLook>().enabled = false;
                Panel.SetActive(true);
                Debug.Log("aoba");
                Panel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = this.gameObject.GetComponent<IInventoryItem>().Image;
                player.GetComponent<Player>().currentObject = this.gameObject;
            }
			//player.GetComponent<Player>().pistas.Add("Pista");
            //player.GetComponent<Player>().inventory.AddItem(this.gameObject.GetComponent<IInventoryItem>());
            //Destroy(this.gameObject);
        }
	}

	private void OnMouseExit ()
	{
		_renderer.material.color = _normalColor;
	}

}
