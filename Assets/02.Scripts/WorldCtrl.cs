//创建日期：2019/3/28
//版本：    v0.01
//说明：    承载内核world，负责world与外壳交互数据

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._02.Scripts;

public class WorldCtrl : MonoBehaviour {
    World world;

    public PlayerControl playerControler;
    public GameObject enemy01;
    public Transform spawnPoint;
    
    public int synCount = 1;

    private void Awake()
    {
        world = World.GetInstance();
        StartCoroutine(SynCore());
        StartCoroutine(SpawnEnemy());
    }
    void Start () {
        world.player = playerControler.playerCore;
    }
	
    IEnumerator SynCore()  //固定间隔同步world内核数据
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            Debug.Log(string.Format("第 {0} 次同步内核数据", synCount++));
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

	// Update is called once per frame
	void Update () {
		
	}
}
