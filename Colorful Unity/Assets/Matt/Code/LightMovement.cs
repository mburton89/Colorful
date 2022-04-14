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

    [SerializeField] Vector3 pivotRotation2;
    [SerializeField] Vector3 lightRotation2;

    [SerializeField] float secondsToMove;
    [SerializeField] Ease ease;
    [SerializeField] Light directionalLight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            MoveToPosition1();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MoveToPosition2();
        }

    }

    public void MoveToPosition1()
    {
        if (directionalLight != null)
        {
            directionalLight.DOIntensity(.2f, secondsToMove);
        }
        pivot.DOLocalRotate(pivotRotation, secondsToMove).SetEase(ease);
        light.DOLocalRotate(lightRotation, secondsToMove).SetEase(ease);
    }

    public void MoveToPosition2()
    {
        if (directionalLight != null)
        {
            directionalLight.DOIntensity(.2f, secondsToMove);
        }
        pivot.DOLocalRotate(pivotRotation2, secondsToMove).SetEase(ease);
        light.DOLocalRotate(lightRotation2, secondsToMove).SetEase(ease);
    }
}
