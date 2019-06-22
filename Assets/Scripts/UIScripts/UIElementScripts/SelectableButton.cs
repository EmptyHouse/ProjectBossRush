using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class extends selectableoption and acts as a Unity button. Since I don't find Unity selections to be very precise
/// I have decided to create my own class of button...
/// </summary>
public class SelectableButton : SelectableOption
{
    public UnityEvent onButtonPressedEvent;
    public UnityEvent onButtonReleasedEvent;


    #region monobehaviour methods
    private void Update()
    {
        if (Input.GetButtonDown(SelectableMenuManager.SELECT_INPUT))
        {
            onButtonPressedEvent.Invoke();
        }
        if (Input.GetButtonUp(SelectableMenuManager.SELECT_INPUT))
        {
            onButtonReleasedEvent.Invoke();
        }
    }
    #endregion monobehaviour methods


}
