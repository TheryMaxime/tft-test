using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textUI;

    public void Write(string text)
    {
        this.textUI.text = text;
    }
}
