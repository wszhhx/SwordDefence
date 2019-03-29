//创建日期：2019/3/27
//版本：    v0.01
//说明：    控制发射的飞剑行为

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._02.Scripts;

public class BulletSwordCtrl : MonoBehaviour {
    public BulletCore bulletCore;


    private float launchTime;
    // Use this for initialization
    private void Awake()
    {
        bulletCore = new BulletCore();
        launchTime = Time.time;
    }

	public void ToDestroy()         //武器击中敌人后自己的处理，包括消失效果，数值记录，销毁子弹等
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time - launchTime > 3)
        {
            Destroy(gameObject);
        }
	}
}
