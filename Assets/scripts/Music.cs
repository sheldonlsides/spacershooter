using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        int numberOfMusicPlayers = FindObjectsOfType<Music>().Length;

        if (numberOfMusicPlayers > 1)
        {
            print(numberOfMusicPlayers);
            Destroy(gameObject);
        } else
        {
            print(numberOfMusicPlayers);
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("loadNextLevel", 3f);
    }

    private void loadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
