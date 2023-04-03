using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject winGameScreen;
    bool winGame = false;

    void Update()
    {
        if(winGame)
        {
            winGameScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        winGame = true;
    }

    // Called when restart button is clicked
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Scene1");
    }
}
