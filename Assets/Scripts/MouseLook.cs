using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;


    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2

    }

    public RotationAxes axes = RotationAxes.MouseXandY;


	void Start () {
	
	}
	
	void Update () {
	    if(axes == RotationAxes.MouseX)
        {
            //水平旋转
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor,0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            //垂直旋转
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else
        {
            //水平且垂直旋转
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float _ratationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _ratationY, 0);
        }
	}
}
