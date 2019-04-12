//创建日期：2019/3/28
//版本：    v0.01
//说明：    控制敌人的行为

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets._02.Scripts;

public class EnemyControl : MonoBehaviour {
    public EnemyCore enemyCore;
    public Image bloodBar;
    public int pathFlag;
    public GameObject pathContain;

    public WorldCtrl worldCtrl;
    private Transform[] pathPoints;

    public Rigidbody2D myRigidbody;

    private void Awake()
    {
        //enemyCore = new EnemyCore();  //测试阶段预先固定敌人属性
        pathPoints = pathContain.GetComponentsInChildren<Transform>();
        pathFlag = 1;
    }
    void Start () {
        worldCtrl = GameObject.Find("WorldCtrl").GetComponent<WorldCtrl>();
	}
	
    public void BindCore(EnemyCore core)
    {
        enemyCore = core;
    }

    public void GetHit(float dmg)          //公式：实际扣血 = 角色攻击力 x [ 10 / (10 + 怪物防御) ]
    {
        Debug.Log(dmg * (10f / (10 + enemyCore.DEF)));
        if (enemyCore.BloodDeduction(dmg * (10f / (10 + enemyCore.DEF))))
        {
            DeadProcess();
            
        }
        else
        {
            bloodBar.fillAmount = (float)enemyCore.HP / enemyCore.MAXHP;
        }
    }

    void DeadProcess()              //这里进行怪物死亡后进行奖励等死亡处理
    {
        worldCtrl.EnemyDie(enemyCore);
        Destroy(gameObject);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.tag == "Bullet")
    //    {
            
    //        BulletSwordCtrl bulletControler = collision.gameObject.GetComponent<BulletSwordCtrl>();
    //        float dmg = bulletControler.bulletCore.belongWeapon.ATK + World.GetInstance().player.ATN;
            
    //        GetHit(dmg);
    //        bulletControler.ToDestroy();
    //    }
    //}

    void FixedUpdate () {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject bullet in bullets)
        {
            if((bullet.transform.position - transform.position).magnitude < 1)
            {
                BulletSwordCtrl bulletControler = bullet.GetComponent<BulletSwordCtrl>();
                float dmg = bulletControler.bulletCore.belongWeapon.ATK + World.GetInstance().player.ATN;
                GetHit(dmg);
                bulletControler.ToDestroy();
            }
        }
        if ((pathPoints[pathFlag].position - transform.position).magnitude < 0.1f)  //抵达路径点
        {
            
            pathFlag++;
            if (pathFlag >= pathPoints.Length)   //若敌人成功到达最后一个路径点则消失
            {
                Destroy(gameObject);
            }
            else
            {
                Vector3 forward = (pathPoints[pathFlag].position - transform.position).normalized;
                myRigidbody.velocity = forward * enemyCore.SPD;
            }
        }
        
    }
}
