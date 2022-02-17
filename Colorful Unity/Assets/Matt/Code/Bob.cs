using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bob : MonoBehaviour
{
    public float maxyPos;
    public float minyPos;

    void Start()
    {
        StartCoroutine(BobCo());
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(maxyPos, 1).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(1);
        transform.DOMoveY(minyPos, 1).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(1);
        StartCoroutine(BobCo());
    }
}
