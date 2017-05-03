 using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {

    public float speed = 5.0f;//移动速度
    public float ObstacleRange = 5.0f;//对墙壁做出反应的距离

    private bool _alive;

	void Start () {
        _alive = true;
	}
	
	void Update () {
        if (_alive == true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);  //本地坐标，往自己的z轴移动

            Ray ray = new Ray(transform.position, transform.forward);//和角色相同位置的射线，并且方向相同
            RaycastHit hit;//结构体来储存信息
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < ObstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
        
	}

    public void SetAlive(bool alivestate)
    {
        _alive = alivestate;
    }
}
