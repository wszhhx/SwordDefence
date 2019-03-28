//创建日期：2019/3/28
//修改日期：2019/3/28
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
    public int pathFLag;
    public GameObject[] pathPoints;

    public Rigidbody2D myRigidbody;

    private void Awake()
    {
        enemyCore = new EnemyCore();  //测试阶段预先固定敌人属性
        pathPoints = GameObject.FindGameObjectsWithTag("PathPoint");
        
        pathFLag = 8;
    }
    void Start () {
	
	}
	
    void GetHit(float dmg)          //公式：实际扣血 = 角色攻击力 x [ 10 / (10 + 怪物防御) ]
    {

        if(enemyCore.BloodDeduction(dmg * (10 / (10 + enemyCore.DEF))))
        {
            DeadProcess();
            Destroy(gameObject);
        }
        else
        {
            bloodBar.fillAmount = enemyCore.HP / enemyCore.MAXHP;
        }
    }

    void DeadProcess()              //这里进行怪物死亡后进行奖励等死亡处理
    {

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
        
        Debug.Log(pathPoints[pathFLag].name);
        if((pathPoints[pathFLag].transform.position - transform.position).magnitude < 0.1f)  //抵达路径点
        {
            Debug.Log("抵达路径点");
            pathFLag--;
            Vector3 forward = (pathPoints[pathFLag].transform.position - transform.position).normalized;
            myRigidbody.velocity = forward * enemyCore.SPD;
            
        }
        if (pathFLag < 1)
            Destroy(gameObject);
    }
}
