using UnityEngine;
using static System.TimeZoneInfo;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _startColor = Color.red;
    [SerializeField] private Color _endColor = Color.blue;
    [SerializeField] private float _duration = 5f;

    //private bool _isTransitioning = false;
    //private float _elapsedTime = 0f;
    private float _timestart = 0f;
    void Start()
    {
        //_meshRenderer.sharedMaterial.SetColor("_BaseColor", new Color(255 / 255f, 0, 255 / 255f));
        _meshRenderer.sharedMaterial.SetColor("_BaseColor", _startColor);

        //_isTransitioning = true;
        //_elapsedTime = 0f;
    }

    void Update()
    {   
        _timestart += Time.deltaTime;
        //float pingPongTime = Mathf.PingPong(_timestart, _duration);
        float t = Mathf.PingPong(_timestart, _duration);

        float normalizedT = t / _duration;
        Color currentColor = Color.Lerp(_startColor, _endColor, normalizedT);

        _meshRenderer.sharedMaterial.SetColor("_BaseColor", currentColor);
        /*if (_isTransitioning)
        {
            _elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(_elapsedTime / Duration);
            float easedT = 1 - (1 - t) * (1 - t);
            Color currentColor = Color.Lerp(_startColor, _endColor, easedT);
            _meshRenderer.sharedMaterial.SetColor("_BaseColor", currentColor);
            if (t >= 1f)
            {
                _isTransitioning = false;
            }
        }*/
    }

}
