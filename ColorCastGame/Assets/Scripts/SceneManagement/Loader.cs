using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    // This enum and enum mathod is only useful when making a script that isnt dynamic
    public enum Scene
    {
        SampleScene, Loading, MainMenu
    }

    private static Action onLoaderCallback; 
    public static void Load(Scene scene)
    {
        // Set the loader callback action to load the taget scene
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };
        // Load the loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void Load(string sScene)
    {
        // Set the loader callback action to load the taget scene
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(sScene);
        };
        // Load the loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback()
    {
        // Triggered after the first update to let the sceen refresh
        // Execute the loader callback action loading the target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
