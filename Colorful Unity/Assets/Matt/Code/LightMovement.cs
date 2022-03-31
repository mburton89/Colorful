using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightMovement : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] Transform light;
    [SerializeField] Vector3 pivotRotation;
    [SerializeField] Vector3 lightRotation;
    [SerializeField] float secondsToMove;
    [SerializeField] Ease ease;
    [SerializeField] Light directionalLight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (directionalLight != null)
            {
                directionalLight.DOIntensity(.2f, secondsToMove);
            }
            MoveToPosition();
        }
    }

    public void MoveToPosition()
    {
        pivot.DOLocalRotate(pivotRotation, secondsToMove).SetEase(ease);
        light.DOLocalRotate(lightRotation, secondsToMove).SetEase(ease);
    }
}
