using System.Collections;
using UnityEngine;

public class RainbowColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _hueShiftSpeed = 0.1f;
    [SerializeField] private Color _startColor = Color.red;

    private float hueShift = 0f;


    void Start()
    {
        StartCoroutine(noHomoRainbow(_hueShiftSpeed));
    }

    private IEnumerator noHomoRainbow(float speed)
    {
        while (true)
        {
            hueShift += speed * Time.deltaTime;
            if (hueShift > 1f) hueShift -= 1f;
            Color rainbowColor = Color.HSVToRGB(hueShift, 1f, 1f);
            _meshRenderer.sharedMaterial.SetColor("_BaseColor", rainbowColor);
            yield return null;
        }
    }
}
