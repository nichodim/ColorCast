using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomTextColor : MonoBehaviour
{
    public TextMeshProUGUI text; 
    public Color c1 = new Color(0.255f, 0.004f, 0.149f, 1f);
    public Color c2 = new Color(0.075f, 0.043f, 0.275f, 1f);
    private int randomc;
    void Start()
    {
        randomc = (int)Random.Range(1, 3);
        if (randomc == 1)
        {
            text.color = c1;
        } else
        {
            text.color = c2; 
        }
    }
}
