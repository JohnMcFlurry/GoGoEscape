using Unity.Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera[] cameras;

    private int currentCamera = 0;

    private int activePriority = 10;
    private int inactivePriority = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCamera++;
            if (currentCamera >= cameras.Length)
            {
                currentCamera = 0;
            }
            UpdateCamera();
        }
    }
    private void UpdateCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            CinemachineCamera cam = cameras[i];
            if (i == currentCamera)
            {
                cam.Priority = activePriority;
            }
            else
            {
                cam.Priority = inactivePriority;
            }
        }
    }
}
