using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private Color color;
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        color = image.color;
        image.color = Color.clear;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = color;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.clear;
    }
}
