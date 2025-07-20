using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LavaFlick : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [ColorUsage(true, true)]
    [SerializeField] private Color emissionColor = Color.yellow;
    [SerializeField] private float minIntensity = 0f;
    [SerializeField] private float maxIntensity = 2f;
    [SerializeField] private float minFlickerTime = 0.1f;
    [SerializeField] private float maxFlickerTime = 0.5f;

    private float currentIntensity;

    void Start()
    {
        currentIntensity = minIntensity;
        StartCoroutine(Flicker());
    }
    IEnumerator Flicker()
    {
        while (true)
        {
            float randomPeak = UnityEngine.Random.Range(minIntensity, maxIntensity);
            float timeToPeak = UnityEngine.Random.Range(minFlickerTime, maxFlickerTime);

            yield return StartCoroutine(InterpolateEmission(randomPeak, timeToPeak));

            float timeToLow = UnityEngine.Random.Range(minFlickerTime, maxFlickerTime);

            yield return StartCoroutine(InterpolateEmission(minIntensity, timeToLow));
        }
    }
    IEnumerator InterpolateEmission(float targetIntensity, float duration)
    {
        float timer = 0f;
        float startIntensity = currentIntensity;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            currentIntensity = Mathf.Lerp(startIntensity, targetIntensity, timer / duration);
            _meshRenderer.sharedMaterial.SetColor("_EmissionColor", emissionColor * currentIntensity);
            yield return null;
        }
        currentIntensity = targetIntensity;
        _meshRenderer.sharedMaterial.SetColor("_EmissionColor", emissionColor * currentIntensity);
    }
}