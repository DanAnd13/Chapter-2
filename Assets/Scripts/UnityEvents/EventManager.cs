using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public static void TriggerClickEvent()
    {
        if (OnClicked != null)
        {
            OnClicked();
        }
    }
}
