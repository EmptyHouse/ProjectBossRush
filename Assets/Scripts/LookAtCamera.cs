using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    #region main variables
    private SpriteRenderer spriteRenderer;
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("No Sprite Renderer was found in the child of this object....");
            this.gameObject.SetActive(false);
        }
    }


    private void Start()
    {
        if (GameOverseer.Instance == null)
        {
            this.gameObject.SetActive(false);
            Debug.LogWarning("There was no game overseer found. Deactivating look at camera sciprt");
            return;
        }
    }

    private void LateUpdate()
    {
        //Camera cam = GameOverseer.Instance.mainGameCamera;
        //spriteRenderer.transform.LookAt(cam.transform.position);
    }
    #endregion monobehaviour methods
}
