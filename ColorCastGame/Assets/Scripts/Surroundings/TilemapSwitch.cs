using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSwitch : MonoBehaviour
{
    // Groundswitch allows for an object that switches between 2 types of ground/colors between a certain interval
    // The following are valid ground types: 
    // groundpink, groundpurple, groundblack
    public Material Pink;
    public Material Purple;
    public Material Black;

    private Renderer renderer; 

    public string colorSwitch1 = "groundpurple";
    public string colorSwitch2 = "groundpink";

    public float waitTime = 1f; 

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        // Sets type of ground and color right away
        gameObject.tag = colorSwitch1;
        GroundColor(colorSwitch1);
        StartCoroutine(GroundSwitcher());
    }

    void GroundColor(string tiletag)
    {
        // Changes color depnding on tag name/ground
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

    IEnumerator GroundSwitcher()
    {
        // Loops switching between 2 types of ground
        while (true)
        {
            gameObject.tag = colorSwitch1;
            GroundColor(colorSwitch1);
            yield return new WaitForSeconds(waitTime);
            gameObject.tag = colorSwitch2;
            GroundColor(colorSwitch2);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
