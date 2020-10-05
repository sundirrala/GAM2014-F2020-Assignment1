// summary
// Nisara Drahman
// 101120917
// oct 03 2020, button behaviour script
// this is where i put in the functionality for every button in game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnHowToPlayButtonPressed()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void OnMainMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnGameOverPressed()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
