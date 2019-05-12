using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class that will act as the manager script for all attached selectable UI elements
/// This will open and close the menu as well as carry out any actions required when selectint
/// UI elements
/// </summary>
public class SelectableUIManager : MonoBehaviour {
    #region const variables
    /// <summary>
    /// The minimum absolute value of our joystick axis, before it is registered
    /// as an input in our settings manager
    /// </summary>
    protected const float JOYSTICK_THRESHOLD = .65f;

    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
    public const string ACCEPT_BUTTON = "Submit";
    public const string CANCEL_BUTTON = "Cancel";
    #endregion const variables
    #region main variables
    [Tooltip("This is the time before we begin autoscrolling in our menu. We will always move to a new item immediately, but we may want a delay before scrolling to different optins automatically")]
    public float timeBeforeAutoScrolling = .4f;
    [Tooltip("The time between selecting the next item when we begin autoscrolling.")]
    public float timeToScrollToNextOption = .1f;
    [Tooltip("The menu item that we will select upon opening the menu. If resetToInitialUIUponOpening is set to false, we will remain on the previous menu option whenever this menu is opened again")]
    public SelectableUI initiallySelectedUI;
    [Tooltip("This will make it so that we begin our menu on the initiallySelectedUI object whenever we open our menu")]
    public bool resetToInitialUIUponOpening;
    //[Tooltip("The transform parent that contains all the UI elements related to this menu")]
    
    #endregion main variables

    public SelectableUI currentlySelectedUI { get; private set; }
    private bool isCurrentlyAutoScrolling;

    #region monobehaviour methods

    private void Awake()
    {
        SetNextSelectableUIOption(initiallySelectedUI);
    }

    private void Update()
    {
        if (isCurrentlyAutoScrolling)
        {
            return;
        }
        float verticalInput = GetVertical();
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (JoystickAboveThreshold(verticalInput))
        {
            StartCoroutine(BeginAutoScrollingVertical(verticalInput));
        }
        else if (Mathf.Abs(horizontalInput) > JOYSTICK_THRESHOLD)
        {

        }
    }
    #endregion monobehaviour methods
    /// <summary>
    /// Gets the next available option in our selectable UI Manager.
    /// If there is no available option, this method will return null.
    /// </summary>
    /// <param name="directionToCheck"></param>
    /// <returns></returns>
    private SelectableUI GetNextOption(SelectableUI.UIDirection directionToCheck)
    {
        SelectableUI optionToCheck = currentlySelectedUI.GetUIInDirection(directionToCheck);
        return optionToCheck;
        //while (optionToCheck != null && !currentlyCheckedOptions.Contains(optionToCheck))
        //{

        //}
    }

    /// <summary>
    /// Sets the next selecctable UI Option. This will disable the currently selected
    /// item and 
    /// </summary>
    /// <param name="selectableUI"></param>
    private void SetNextSelectableUIOption(SelectableUI selectableUI)
    {
        if (selectableUI == null) return;
        if (this.currentlySelectedUI != null)
        {
            this.currentlySelectedUI.enabled = false;
        }
        this.currentlySelectedUI = selectableUI;
        this.currentlySelectedUI.enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initialVerticalInput"></param>
    /// <returns></returns>
    private IEnumerator BeginAutoScrollingVertical(float initialVerticalInput)
    {
        isCurrentlyAutoScrolling = true;
        float direction = Mathf.Sign(initialVerticalInput);

        float timeThatHasPassed = 0;

        SelectableUI nextOption = GetNextOption(direction < 0 ? SelectableUI.UIDirection.South : SelectableUI.UIDirection.North);
        if (nextOption != null)
        {
            SetNextSelectableUIOption(nextOption);
        }

        while (timeThatHasPassed < timeBeforeAutoScrolling)
        {
            if (!JoystickAboveThresholdSign(direction, GetVertical()))
            {
                this.isCurrentlyAutoScrolling = false;
                yield break;
            }
            timeThatHasPassed += Time.unscaledDeltaTime;
            yield return null;
        }

        timeThatHasPassed = 0;
        while (JoystickAboveThresholdSign(direction, GetVertical()))
        {
            if (timeThatHasPassed > timeToScrollToNextOption)
            {
                timeThatHasPassed = 0;
                ///TO-DO Add code that will change to the next item in the ui menu
                nextOption = GetNextOption(direction < 0 ? SelectableUI.UIDirection.South : SelectableUI.UIDirection.North);
                if (nextOption != null)
                {
                    SetNextSelectableUIOption(nextOption);
                }
            }
            timeThatHasPassed += Time.unscaledDeltaTime;
            yield return null;
        }
        this.isCurrentlyAutoScrolling = false;
        yield break;
    }

    #region common inputs

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool GetAcceptButtonDown()
    {
        return Input.GetButtonDown(ACCEPT_BUTTON);
    }


    public bool GetAcceptButton()
    {
        return Input.GetButton(ACCEPT_BUTTON);
    }


    public bool GetAcceptButtonUp()
    {
        return Input.GetButtonUp(ACCEPT_BUTTON);
    }


    public bool GetCancelButtonDown()
    {
        return Input.GetButtonDown(CANCEL_BUTTON);
    }


    public bool GetCancelButton()
    {
        return Input.GetButton(CANCEL_BUTTON);
    }

    /// <summary>
    /// 
    /// </summary>
    public bool GetCancelButtonUp()
    {
        return Input.GetButtonUp(CANCEL_BUTTON);
    }

    public float GetHorizontal()
    {
        return Input.GetAxisRaw(HORIZONTAL_AXIS);
    }

    public float GetVertical()
    {
        return Input.GetAxisRaw(VERTICAL_AXIS);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="axis"></param>
    /// <returns></returns>
    public bool JoystickAboveThreshold(float axis)
    {
        return Mathf.Abs(axis) > JOYSTICK_THRESHOLD;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sign"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public bool JoystickAboveThresholdSign(float sign, float axis)
    {
        return (sign * axis) > JOYSTICK_THRESHOLD;
    }
    #endregion common inputs

    /// <summary>
    /// 
    /// </summary>
    /// <param name="methodToPerformAfterOneFrame"></param>
    /// <returns></returns>
    protected IEnumerator PerformActionAfterOneFrame(Action methodToPerformAfterOneFrame)
    {
        yield return null;
        methodToPerformAfterOneFrame.Invoke();
    }
}
