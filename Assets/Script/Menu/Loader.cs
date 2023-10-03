using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Using code from https://www.youtube.com/watch?v=3I5d2rUJ0pE&t=666s
public static class Loader 
{
    public enum Scene
    {
        Level, Loading, MainMenu
    }
    
    
    public static void Load(Scene scene)
    { 
        
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loading.ToString());

    }

    private static Action onLoaderCallback;

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

}
