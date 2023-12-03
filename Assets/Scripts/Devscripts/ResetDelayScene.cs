using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDelayScene : MonoBehaviour
{
    [SerializeField] int waitTime = 4;
    [SerializeField] AudioClip triggerAudioClip;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    IEnumerator WaitAndReloadScene()
    {
        Debug.Log("Waiting for " + waitTime + " seconds...");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Reloading scene...");
        SceneManager.LoadScene("MainScene");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Player entered the trigger zone
            print("player in");
            StartCoroutine(WaitAndReloadScene());
            PlayAudioClip();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out");
            StopAudioClip();
        }
    }

    void PlayAudioClip()
    {
        if (triggerAudioClip != null && audioSource != null)
        {
            audioSource.clip = triggerAudioClip;
            audioSource.Play();
        }
    }

    void StopAudioClip()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

}
