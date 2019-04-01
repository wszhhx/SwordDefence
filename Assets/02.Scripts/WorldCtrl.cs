//创建日期：2019/3/28
//版本：    v0.01
//说明：    承载内核world，负责world与外壳交互数据

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets._02.Scripts;

public class WorldCtrl : MonoBehaviour {
    World world;

    public Text txCountDown;
    public Text showMoney;
    public Text showOre;
    public Text showWood;

    public GameObject enemy01;

    public PlayerControl playerControler;
    public Transform spawnPoint;
    public Turn[] TurnInfoSet;


    public float spawnInterval = 1.0f;


    
    private int synCount = 1;

    private float lastSpawnTime;

    private void Awake()
    {
        world = World.GetInstance();
        StartCoroutine(SynCore());
        showMoney.text = world.money.ToString();
        showWood.text = world.wood.ToString();
        showOre.text = world.ore.ToString();
        //StartCoroutine(SpawnEnemy());
    }
    void Start () {
        world.player = playerControler.playerCore;
    }
	
    IEnumerator SynCore()  //固定间隔同步world内核数据
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator SpawnEnemy()    //测试时先设置无限生成敌人，后面需要创建条件生成逻辑
    {
        while (true)
        {
            Instantiate(enemy01, spawnPoint.position, new Quaternion());
            yield return new WaitForSeconds(30.0f);
            
        }
    }

    void Pause()    //暂停游戏
    {

    }

    void Resume()   //继续游戏
    {

    }

    public void EnemyDie(EnemyCore enemy)     //敌人死亡
    {
        world.money += enemy.MONEY;
        showMoney.text = world.money.ToString();
    }

    void TurnFinish()   //当前波数完毕
    {
        world.turnState = TurnState.rest;
        world.restTimeStamp = Time.time;    //记录进入休息的时间节点
        txCountDown.gameObject.SetActive(true);
    }

    void NextTurnActive()   //开始进行下一波
    {
        world.turnCount += 1;
        txCountDown.gameObject.SetActive(false);
        world.turnState = TurnState.spawning;
        world.spawnEnemyCount = 0;
    }

	// Update is called once per frame
	void FixedUpdate () {
        if(world.gameState == GameState.resume)
        {
            if(world.turnState == TurnState.spawning)   //若当前波敌人还在刷新进攻
            {
                if(world.spawnEnemyCount < TurnInfoSet[world.turnCount].enemyCount)    //当前波的敌人没有全部出完
                {
                    if(Time.time - world.preSpawnTime > spawnInterval)
                    {
                        Instantiate(TurnInfoSet[world.turnCount].enemy, spawnPoint.position, new Quaternion());
                        world.preSpawnTime = Time.time;
                        world.spawnEnemyCount += 1;
                    }
                }
                else
                {
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)       //所有敌人都消失，即可进入休息时间
                    {
                        TurnFinish();
                    }
                }
            }
            else   //当前波进攻结束，正在休息整顿中
            {
                if (world.turnCount == TurnInfoSet.Length - 1)  //若当前波为最后一波
                {
                    Debug.Log("所有波都已结束");
                }
                else
                {
                    if (Time.time - world.restTimeStamp < TurnInfoSet[world.turnCount].restTime) //休息时间未结束
                    {
                        txCountDown.text = string.Format("<b>整备计时：{0:f0}</b>", TurnInfoSet[world.turnCount].restTime - Time.time + world.restTimeStamp);
                    }
                    else    //休息时间结束
                    {
                        NextTurnActive();

                    }
                }
                
            }
            
           
        }
        else    //若游戏处于暂停状态
        {

        }
	}
}
