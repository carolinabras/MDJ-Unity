using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text HUDText;

    [SerializeField] private GameObject cutsceneCamera;
    [SerializeField] private int secondsLeft = 30;
    [SerializeField] private Player[] players;

    
    private void Awake()
    {
        HUDText.gameObject.SetActive(false);
        foreach (var player in players)
        {
            player.SetInteractive(false);
        }
        //the start is delayed for the cutscene
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        //cutscene playing...
        yield return new WaitForSeconds(5.5f);

        cutsceneCamera.SetActive(false);
        foreach (var player in players)
        {
            player.SetInteractive(true);
        }
        
        HUDText.text = "Time Left: " + secondsLeft;
        HUDText.gameObject.SetActive(true);
        InvokeRepeating("DecrementSecondsLeft", 1, 1);
        pauseMenu.SetActive(false);
    }
    
    private IEnumerator DecrementSecondsLeft()
    {
        secondsLeft--;
        HUDText.text = "Time Left: " + secondsLeft;
        
        if (secondsLeft == 0)
        {
            SceneManager.LoadScene("end scene");
        }
        return null;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf? 0: 1;
        }
    }
}
