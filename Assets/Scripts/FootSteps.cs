using UnityEngine;

public class FootSteps : MonoBehaviour
{
    //[SerializeField]
    //private AudioClip[] stoneClips;
    //[SerializeField]
    //private AudioClip[] mudClips;
    //[SerializeField]
    //private AudioClip[] grassClips;
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;
    //private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
        /*int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch(terrainTextureIndex)
        {
            case 0:
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
            case 1:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 2:
            default:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
        }*/

    }
}