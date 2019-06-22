using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableOption : MonoBehaviour
{
    [SerializeField]
    private SelectableOption northOption;
    [SerializeField]
    private SelectableOption southOption;
    [SerializeField]
    private SelectableOption eastOption;
    [SerializeField]
    private SelectableOption westOption;

    public bool optionActive { get; private set; }
    private bool wasInspected;

    public void SetOptionActive(bool optionActive)
    {

    }


    public SelectableOption GetOptionNorth()
    {
        if (northOption == null || wasInspected)
        {
            return null;
        }

        if (optionActive)
        {
            return northOption;
        }
        SelectableOption optionToReturn = null;
        if (northOption != null)
        {
            wasInspected = true;
            optionToReturn = northOption.GetOptionNorth();
            wasInspected = false;
        }
        return optionToReturn;
        
    }

    public SelectableOption GetOptionSouth()
    {
        if (southOption == null || wasInspected)
        {
            return southOption;
        }

        if (optionActive)
        {
            return southOption;
        }
        SelectableOption optionToReturn = null;
        if (southOption != null)
        {
            wasInspected = true;
            optionToReturn = southOption.GetOptionSouth();
            wasInspected = false;
        }
        return optionToReturn;
    }

    public SelectableOption GetOptionEast()
    {
        if (eastOption == null || wasInspected)
        {
            return null;
        }

        if (optionActive)
        {
            return eastOption;
        }
        SelectableOption optionToReturn = null;
        if (eastOption != null)
        {
            wasInspected = true;
            optionToReturn = eastOption.GetOptionEast();
            wasInspected = false;
        }
        return optionToReturn;
    }

    public SelectableOption GetOptionWest()
    {
        if (westOption == null || wasInspected)
        {
            return null;
        }

        if (optionActive)
        {
            return westOption;
        }
        SelectableOption optionToReturn = null;
        if (westOption != null)
        {
            wasInspected = true;
            optionToReturn = westOption.GetOptionWest();
            wasInspected = false;
        }
        return optionToReturn;
    }

    
}
