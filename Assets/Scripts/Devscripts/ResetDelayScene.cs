using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDelayScene : MonoBehaviour
{
    [SerializeField] int waitTime = 4;

    // Start is called before the first frame update

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
        }
    }
}
