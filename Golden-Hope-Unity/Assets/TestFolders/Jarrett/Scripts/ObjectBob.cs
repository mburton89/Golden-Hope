using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ObjectBob : MonoBehaviour
{
    private float _initialYPosition;
    public float bobDistance;
    public float bobDuration;
    public Ease ease;

    private void Start()
    {
        StartCoroutine(BobCo());
        _initialYPosition = transform.position.y;
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(_initialYPosition + bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        transform.DOMoveY(_initialYPosition - bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        StartCoroutine(BobCo());
    }
}

