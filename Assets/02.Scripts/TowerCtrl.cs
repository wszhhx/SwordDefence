//创建日期：2019/4/1
//版本：    v0.01
//说明：    防御塔控制脚本

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._02.Scripts;


public class TowerCtrl : MonoBehaviour {

    public TowerCore towerCore;
    public Transform bulletSpawnPoint;
    public GameObject bullet;
    private Transform aimEnemy;

    private float preAtkTime;

    private void Awake()
    {
        towerCore = new TowerCore();
        preAtkTime = 0;
        BuildComplete();    //测试：暂时先设为一出现就建造完毕
    }

    private void BuildComplete()
    {
        towerCore.state = towerState.exist;
        StartCoroutine(DetectEnemy());
    }

    IEnumerator DetectEnemy()       //根据设定选择攻击的敌人
    {
        while (true)
        {
            
            yield return new WaitForSeconds(0.2f);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            if (enemies.Length == 0)
                continue;
            if(towerCore.atkOption == towerAtkOption.distance)
            {
                int k = -1;
                float minDis = 65535;
                float tempDis;
                for(int i=0; i<enemies.Length; ++i)
                {
                    tempDis = (enemies[i].transform.position - transform.position).magnitude;
                    if (tempDis < towerCore.RANGE && tempDis < minDis)
                    {
                        k = i;
                        minDis = tempDis;
                    }
                }
                if (k == -1)
                {
                    towerCore.state = towerState.exist;
                    continue;
                }
                else
                {
                    aimEnemy = enemies[k].transform;
                    towerCore.state = towerState.attack;
                }
            }
            else
            {
                int k = -1;
                float minHealth = 65535;
                float tempDis;
                for(int i=0; i<enemies.Length; ++i)
                {
                    tempDis = (enemies[i].transform.position - transform.position).magnitude;
                    if(tempDis > towerCore.RANGE)
                    {
                        continue;
                    }
                    if(enemies[i].GetComponent<EnemyCore>().HP < minHealth)
                    {
                        k = i;
                        minHealth = enemies[i].GetComponent<EnemyCore>().HP;
                    }
                }
                if (k == -1)
                {
                    towerCore.state = towerState.exist;
                    continue;
                }
                else
                {
                    aimEnemy = enemies[k].transform;
                    towerCore.state = towerState.attack;
                }
            }
            
        }
    }

    void Start () {
		
	}
	

	void FixedUpdate () {
        if(towerCore.state == towerState.attack && Time.time - preAtkTime > 1 / towerCore.ATS && aimEnemy != null)  //进行攻击动作
        {
            GameObject temp = Instantiate(bullet, bulletSpawnPoint.position, new Quaternion());
            temp.GetComponent<TowerBulletCtrl>().BindTower(towerCore);
            //Debug.Log(temp.GetComponent<TowerBulletCtrl>().bulletCore.belongTower.ATK);
            temp.GetComponent<TowerBulletCtrl>().Aim(aimEnemy.gameObject, 20); //测试，速度先手动设置
            preAtkTime = Time.time;
        }
        
	}
}
