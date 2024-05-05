using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text HUDText;

    [SerializeField] private int secondsLeft;
    
    private void Start()
    {
        secondsLeft = 300;
        HUDText.text = "Time Left: " + secondsLeft;
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
