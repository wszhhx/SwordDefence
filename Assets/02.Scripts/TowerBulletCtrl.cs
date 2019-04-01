//创建日期：2019/4/1
//版本：    v0.01
//说明：    控制塔发射的子弹（主动型）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._02.Scripts;

public class TowerBulletCtrl : MonoBehaviour {
    public TowerBulletCore bulletCore;
    private GameObject aimEnemy;
    public Rigidbody2D myRigidbody;
    private float speed;

    private float spawnTime;
    private void Awake()
    {
        spawnTime = Time.time;
        Debug.Log("生成bulletCore");
        bulletCore = new TowerBulletCore();
        Debug.Log(bulletCore);
    }

    public void Aim(GameObject aim,float spd)
    {
        aimEnemy = aim;
        speed = spd;
    }

    public void BindTower(TowerCore tc)
    {
        bulletCore.belongTower = tc;
    }

    void Start () {
		
	}
	
	
	void FixedUpdate () {
        if (Time.time - spawnTime > 3)
        {
            Destroy(gameObject);
            bulletCore = null;
        }    
        if (aimEnemy == null)
            return;
        else
        {
            myRigidbody.velocity = (aimEnemy.transform.position - transform.position).normalized * speed;
        }
        if((aimEnemy.transform.position - transform.position).magnitude < 0.1)
        {
            
            Debug.Log(bulletCore);
            aimEnemy.GetComponent<EnemyControl>().GetHit(bulletCore.belongTower.ATK);
            Destroy(gameObject);
            bulletCore = null;
        }
	}
}
