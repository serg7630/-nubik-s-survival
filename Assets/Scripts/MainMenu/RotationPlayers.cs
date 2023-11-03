
using UnityEngine;

public class DragToRotate : MonoBehaviour
{

    public float RotationValue = 20f;
    private float _directionRotation=0f;
    public int CountPlayer;
    private void Update()
    {
        
    }
    public void RotateObject(bool RotateRight)
    {
        if (RotateRight)
        {
            _directionRotation += RotationValue;
            CountPlayer++;
            if (CountPlayer == 7) CountPlayer = 1;
        }
        else
        {
            _directionRotation -= RotationValue;
            CountPlayer--;
            if (CountPlayer == -0) CountPlayer = 6;
        }
    }
    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _directionRotation, 0), Time.deltaTime);
    }


}
