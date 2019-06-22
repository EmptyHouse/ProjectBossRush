using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SelectableMenuManager : MonoBehaviour
{
    #region const variables
    public const float JOYSTICK_THRESHOLD = .6f;
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
    public const string SELECT_INPUT = "Submit";
    public const string CANCEL_INPUT = "Cancel";

    public const float DELAY_BEFORE_BEGIN_AUTO_SCROLL = .12f;
    public const float DELAY_BETWEEN_NEXT_OPTION_AUTO_SCROLL = .03f;
    #endregion const variables

    public SelectableOption initialOptionToSelect;

    private SelectableOption currentlySelectedOption;
    private bool isAutoScrolling;
    #region monobehaviour methods
   
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
        float verticalInput = Input.GetAxisRaw(VERTICAL_AXIS);

        if (isAutoScrolling) return;

        if (Mathf.Abs(horizontalInput) > JOYSTICK_THRESHOLD)
        {
            StartCoroutine(AutoScrollHorizontal(horizontalInput));
        }
        else if (Mathf.Abs(verticalInput) > JOYSTICK_THRESHOLD)
        {
            StartCoroutine(AutoScrollVertical(verticalInput));
        }
    }
    #endregion monobehaviour methods

    #region controls
    protected float GetHorizontalInput()
    {
        return Input.GetAxisRaw(HORIZONTAL_AXIS);
    }

    protected float GetVerticalInput()
    {
        return Input.GetAxisRaw(VERTICAL_AXIS);
    }
    #endregion controls

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hInput"></param>
    /// <param name="vInput"></param>
    protected void SetNextOption(int hInput, int vInput)
    {
        if (hInput > 0)
        {
            SelectNextOption(currentlySelectedOption.GetOptionEast());
        }
        else if (hInput < 0)
        {
            SelectNextOption(currentlySelectedOption.GetOptionWest());
        }


        if (vInput > 0)
        {
            SelectNextOption(currentlySelectedOption.GetOptionNorth());
        }
        else if (vInput < 0)
        {
            SelectNextOption(currentlySelectedOption.GetOptionSouth());
        }
    }

    private void SelectNextOption(SelectableOption optionToSelect)
    {
        if (optionToSelect == null)
        {
            return;
        }

        if (currentlySelectedOption != null)
        {
            currentlySelectedOption.enabled = false;
        }

        currentlySelectedOption = optionToSelect;
        currentlySelectedOption.enabled = true;
    }

    private IEnumerator AutoScrollHorizontal(float horizontalInput)
    {
        isAutoScrolling = true;
        int direction = (int)Mathf.Sign(horizontalInput);
        float timeThatHasPassed = 0;
        SetNextOption(direction, 0);
        while (timeThatHasPassed < DELAY_BEFORE_BEGIN_AUTO_SCROLL)
        {
            if (direction * GetHorizontalInput() < JOYSTICK_THRESHOLD)
            {
                isAutoScrolling = false;
                yield break;
            }

            timeThatHasPassed += Time.unscaledDeltaTime;
            yield return null;
        }
        SetNextOption(direction, 0);
        timeThatHasPassed = 0;
        while (direction * GetHorizontalInput() > JOYSTICK_THRESHOLD)
        {
            if (timeThatHasPassed > DELAY_BETWEEN_NEXT_OPTION_AUTO_SCROLL)
            {
                timeThatHasPassed = 0;
                SetNextOption(direction, 0);
            }

            timeThatHasPassed += Time.unscaledDeltaTime;
            yield return null;
        }

        isAutoScrolling = false;
    }

    private IEnumerator AutoScrollVertical(float verticalInput)
    {
        isAutoScrolling = true;
        int direction = (int)Mathf.Sign(verticalInput);
        float timeThatHasPassed = 0;
        SetNextOption(0, direction);
        while (timeThatHasPassed < DELAY_BEFORE_BEGIN_AUTO_SCROLL)
        {
            if (direction * GetVerticalInput() < JOYSTICK_THRESHOLD)
            {
                isAutoScrolling = false;
                yield break;
            }

            timeThatHasPassed += Time.unscaledDeltaTime;
            yield return null;
        }
        SetNextOption(0, direction);
        timeThatHasPassed = 0;
        while (direction * GetVerticalInput() > JOYSTICK_THRESHOLD)
        {
            if (timeThatHasPassed > DELAY_BETWEEN_NEXT_OPTION_AUTO_SCROLL)
            {
                timeThatHasPassed = 0;
                SetNextOption(0, direction);
            }

            timeThatHasPassed += Time.unscaledDeltaTime;
            yield return null;
        }

        isAutoScrolling = false;
    }

}
