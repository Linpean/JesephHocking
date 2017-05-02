using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();//访问相同对象上的摄像机其他组件
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;//隐藏屏幕中心的光标
	}

	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point); //使用摄像机的方法ScreenPointToRay在摄像机所在位置创建射线
            RaycastHit hit;
            if( Physics.Raycast(ray, out hit))
            {


                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    Debug.Log("Target Hit");
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));    
                }
            }
        }

	}

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//创建游戏物体：球体变量
        sphere.transform.position = position;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }


    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
