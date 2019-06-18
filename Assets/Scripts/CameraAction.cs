using UnityEngine;

public class CameraAction : MonoBehaviour
{
    Vector3 firstpoint;
    Vector3 secondpoint;
    float xAngle = 0.0f;
    float yAngle = 0.0f;
    float xAngTemp = 0.0f;
    float yAngTemp = 0.0f;

    private void Start()
    {
        Input.gyro.enabled = true;
        xAngle = 0.0f;
        yAngle = 0.0f;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
    }

    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (SystemInfo.supportsGyroscope)
            {
                transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, -Input.gyro.rotationRateUnbiased.z);
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        firstpoint = Input.GetTouch(0).position;
                        xAngTemp = xAngle;
                        yAngTemp = yAngle;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        secondpoint = Input.GetTouch(0).position;
                        xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
                        yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;
                        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                    }
                }
            }
        }
        else if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
            float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
            transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
        }
    }
}
