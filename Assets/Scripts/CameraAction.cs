using UnityEngine;

public class CameraAction : MonoBehaviour
{
    private void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if(SystemInfo.supportsGyroscope)
        {
            transform.Rotate (-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, -Input.gyro.rotationRateUnbiased.z);
        }
        else
        {
            float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
            float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
            transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
        }
    }
}
