//创建日期：2019/3/28
//修改日期：2019/3/28
//版本：    v0.01
//说明：    负责记录、显示路径点和路径

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControl : MonoBehaviour {
    //GameObject[] pathPoints;
    public Transform[] pathPoints;
    
    private void Awake()
    {
        
    }

    private void OnDrawGizmos()
    {
        pathPoints = gameObject.GetComponentsInChildren<Transform>();
        Gizmos.color = Color.blue;
        for (int i = 1; i < pathPoints.Length; ++i)
        {
           
            if (i > 1)
            {
                Gizmos.DrawLine(pathPoints[i - 1].position, pathPoints[i].position);
            }
            Gizmos.DrawSphere(pathPoints[i].position, 1);
        }

    }

    void Start () {
        
	}
	
	
	void Update () {
		
	}
}
