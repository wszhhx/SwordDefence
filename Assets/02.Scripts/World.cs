//创建日期：2019/3/27
//修改日期：2019/3/27
//版本：    v0.01
//说明：    记录全局数据

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._02.Scripts
{
    public class World
    {
        private static World _world = null;
        public PlayerCore player;
        public float gameTime = 0;              //游戏时间（秒）
        public float turnTime = 0;              //当前波进行时间
        public int turnCount = 0;               //波数记录
        public int spawnEnemyCount = 0;         //记录已经生成的敌人数
        public int[] eachTurnEnemyCount;        //每波敌人的数量（只读）
        public Vector3 camPosition;             //记录摄像机位置



        public static World GetInstance()
        {
            if(_world == null)
            {
                _world = new World();
            }
            return _world;
        }
    }
}
