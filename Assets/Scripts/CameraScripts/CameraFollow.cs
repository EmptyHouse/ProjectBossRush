using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region main variables
    public AnimationCurve zoomingAnimationCurve;
    [Range(0, 1)]
    [Tooltip("The lerp speed of our camera from the target transform")]
    public float cameraFollowSpeed = 10;
    /// <summary>
    /// This value is used for the default offset of our camera from the player
    /// </summary>
    private Vector3 defaultOffset;
    /// <summary>
    /// If our camera is currently in the process of zooming in or out this variable will be set to true.
    /// </summary>
    private bool isZooming;
    private Camera associatedCamera;
    #endregion main variables

    public Transform targetTransformObject { get; set; }
    
    #region monbehaviour methods

    private void Awake()
    {
        targetTransformObject = GetComponentInParent<PlayerCharacterStats>().transform;
        defaultOffset = this.transform.localPosition;
        this.transform.SetParent(null);
        associatedCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            SetCameraSize(associatedCamera.orthographicSize + 5, 1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            SetCameraSize(associatedCamera.orthographicSize - 5, 1);
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = targetTransformObject.position + defaultOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraFollowSpeed);
        transform.position = smoothedPosition;
    }
    #endregion monobehaviour methods

    /// <summary>
    /// Lerps the camera to the target position
    /// 
    /// </summary>
    private void LerpToTargetTransform()
    {
        Vector3 goalPosition = targetTransformObject.position + defaultOffset;

        print(goalPosition);
        if (targetTransformObject)
        {
            transform.position = Vector3.Lerp(transform.position, goalPosition, Time.deltaTime * cameraFollowSpeed);
        }
    }

    /// <summary>
    /// Sets the camera scale. You can zoom in and out with this method
    /// </summary>
    public void SetCameraSize(float sizeToSet, float timeToReachGoalSize = .25f)
    {
        StartCoroutine(SetCameraToDesiredSize(sizeToSet, timeToReachGoalSize));
    }

    /// <summary>
    /// Coroutine that sets the camera to the desired size gradually
    /// </summary>
    /// <param name="sizeToSet"></param>
    /// <param name="timeToReachGoalSize"></param>
    /// <returns></returns>
    private IEnumerator SetCameraToDesiredSize(float sizeToSet, float timeToReachGoalSize)
    {
        isZooming = false;
        yield return null;
        float originalSize = associatedCamera.orthographicSize;

        isZooming = true;
        float timeThatHasPassed = 0;
        while(timeThatHasPassed < timeToReachGoalSize)
        {
            if (!isZooming)
            {
                yield break;
            }
            associatedCamera.orthographicSize = Mathf.Lerp(originalSize, sizeToSet, zoomingAnimationCurve.Evaluate(timeThatHasPassed / timeToReachGoalSize));
            yield return null;
            timeThatHasPassed += Time.deltaTime;
        }
        associatedCamera.orthographicSize = sizeToSet;
    }
}
