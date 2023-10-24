using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class displayTextController : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject TextItem;

    void Start()
    {
        TextItem.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TextItem.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextItem.SetActive(false);
    }
}
