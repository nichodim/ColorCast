using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public Material Pink;
    public Material Purple;
    public Material PinkLaserMat;
    public Material PurpleLaserMat;

    public Color pink = new Color(0.255f, 0.004f, 0.149f, 1f);
    public Color purple = new Color(0.075f, 0.043f, 0.275f, 1f);

    Renderer renderer;
    public LineRenderer LaserRenderer;

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
                LaserRenderer.material = PinkLaserMat;
                LaserRenderer.SetColors(pink, pink); 
                break;
            case "groundpurple":
                renderer.material = Purple;
                LaserRenderer.material = PurpleLaserMat;
                LaserRenderer.SetColors(purple, purple);
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
