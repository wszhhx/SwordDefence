//创建日期：2019/3/27
//修改日期：2019/3/27
//版本：    v0.01
//说明：    控制摄像机行为

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public bool isFollow;
    public Transform player;
    // Use this for initialization
    private void Awake()
    {
        isFollow = true;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFollow = !isFollow;
        }
        if (isFollow)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        else
        {

        }
	}
}
