using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
