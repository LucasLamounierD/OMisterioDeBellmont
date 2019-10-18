using System.Collections;
using UnityEngine;

public class ColideWithObject : MonoBehaviour
{
// Eu estou utilizando SerializeField e variáveis 
	// privadas aqui porque a combinação está de acordo 
	// com a convenção de encapsulamento e segurança
	// de código C#.
 
	[SerializeField] private Color32 _normalColor = new Color32(100, 100, 100,100);
	[SerializeField] private Color32 _highlightColor = new Color32(100, 200, 200,200);
	[SerializeField] private Color32 _activeColor = new Color32(255, 255, 255,255);
 
	private Renderer _renderer; // Todos os renderizadores derivam da classe Renderer.
 
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
		GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
	}
 
	private void OnMouseExit ()
	{
		_renderer.material.color = _normalColor;
	}

}
