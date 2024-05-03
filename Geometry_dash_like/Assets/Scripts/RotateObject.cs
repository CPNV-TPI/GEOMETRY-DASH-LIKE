using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private const int DegreesPerSecond = -180;
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,DegreesPerSecond) * Time.deltaTime);
    }
}
