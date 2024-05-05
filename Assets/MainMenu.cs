using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadNextScene);
        //startButton.onClick.AddListener(()=>SceneManager.LoadScene("split screen HUD")); as a shorter alternative
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("pause menu");
    }
}
