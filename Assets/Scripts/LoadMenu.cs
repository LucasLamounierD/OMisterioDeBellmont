using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadMenu : MonoBehaviour
{
    public string cenaACarregar;
    public float TempoFixoSeg = 5;
    public enum tipoCarreg{Carregamento,TempoFixo};
    public tipoCarreg tipoDeCarregamento;
    public Image barraCarregamento;
    public Text textoProgresso;
    private int progresso =0;
    private string textoOriginal;
    // Start is called before the first frame update
    void Start()
    {
        switch(tipoDeCarregamento){
            case tipoCarreg.Carregamento:
            StartCoroutine(CenaDeCarregamento(cenaACarregar));
            break;
            case tipoCarreg.TempoFixo:
            StartCoroutine(TempoFixo(cenaACarregar));
            break;
        }
        if(textoProgresso!=null){
            textoOriginal = textoProgresso.text;
        }
        if(barraCarregamento != null){
            barraCarregamento.type = Image.Type.Filled;
            barraCarregamento.fillMethod = Image.FillMethod.Horizontal;
            barraCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
    }

    IEnumerator CenaDeCarregamento(string cena){
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        while(!carregamento.isDone){
            progresso = (int)(carregamento.progress * 100.0f);
            yield return null;
        }
    }

    IEnumerator TempoFixo(string cena){
        yield return new WaitForSeconds(TempoFixoSeg);
        SceneManager.LoadScene(cena);
    }

    // Update is called once per frame
    void Update()
    {
        switch(tipoDeCarregamento){
            case tipoCarreg.Carregamento:
            break;
            case tipoCarreg.TempoFixo:
            progresso = (int)(Mathf.Clamp((Time.time / TempoFixoSeg),0.0f,1.0f) * 100.0f);
            break;
        }
        if(textoProgresso!=null){
            textoProgresso.text = textoOriginal + " " + progresso + "%";
        }
        if(barraCarregamento != null){
            barraCarregamento.fillAmount = (progresso/100.0f);
        }
    }
}
