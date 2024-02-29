using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    private int _speed = 8;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
    }
}
