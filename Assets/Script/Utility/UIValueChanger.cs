using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIValueChanger : MonoBehaviour
{
    public Slider slider;
    public TMP_Text TextBox;

    public void SetValue()
    {
        TextBox.text = slider.value.ToString();
    }
}
