using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    private void Start()
    {
        pauseMenu.SetActive(false);
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
