using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject ReferenceImage;

    [SerializeField]
    GameObject ReferenceImageButton;

    public void PlayGame()
    {
        // SceneManager.LoadScene("Level");
        Loader.Load(Loader.Scene.Level);
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenReferenceImage()
    {
        ReferenceImage.SetActive(true);
        ReferenceImageButton.SetActive(true);
    }

    public void CloseReferenceImage()
    {
        ReferenceImage.SetActive(false);
        ReferenceImageButton.SetActive(false);
    }
}
