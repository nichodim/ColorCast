using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    public Button button;
    // scene should be defined in Unity
    public string scene;

    private void Start()
    {
        Button btn = button.GetComponent<Button>();
        // Triggers loading of scene when clicked
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Loader.Load(scene); 
    }
}
