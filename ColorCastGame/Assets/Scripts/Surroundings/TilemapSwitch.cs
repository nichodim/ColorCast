using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapSwitch : MonoBehaviour
{
    public Material Pink;
    public Material Purple;
    public Material Black;

    Renderer renderer; 

    public string colorSwitch1 = "groundpurple";
    public string colorSwitch2 = "groundpink";

    public float waitTime = 1f; 

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        // Sets type of tilemap and color right away
        gameObject.tag = colorSwitch1;
        TilemapColor(colorSwitch1);
        StartCoroutine(TilemapSwitcher());
    }

    void TilemapColor(string tiletag)
    {
        // Changes color depnding on tag name
        switch (gameObject.tag)
        {
            case "groundpink":
                renderer.material = Pink;
                break;
            case "groundpurple":
                renderer.material = Purple;
                break;
            case "groundblack":
                renderer.material = Black;
                break;
        }
    }

    IEnumerator TilemapSwitcher()
    {
        while (true)
        {
            gameObject.tag = colorSwitch1;
            TilemapColor(colorSwitch1);
            yield return new WaitForSeconds(waitTime);
            gameObject.tag = colorSwitch2;
            TilemapColor(colorSwitch2);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
