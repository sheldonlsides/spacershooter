
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.25f;
    [SerializeField] GameObject deathFX = null;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player died");
        SendMessage("OnPlayerDeath");
        
        deathFX.SetActive(true);
        //transform.gameObject.SetActive(false);

        Invoke("reloadLevel", levelLoadDelay);
    }

    private void reloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
