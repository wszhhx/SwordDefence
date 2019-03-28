//创建日期：2019/3/27
//修改日期：2019/3/27
//版本：    v0.01
//说明：    角色的内核类，记录角色状态、属性

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._02.Scripts
{
    [System.Serializable]
    public class PlayerCore
    {
        private float _spd;
        private int _mp;
        

        private int level;
        private int[] maxExp;

        public float ATN { get; set; }
        public float SPD
        {
            get
            {
                return _spd;
            }
            set
            {
                if (value < 0)
                {
                    UnityEngine.Debug.Log("速度负值错误");
                }
                else
                {
                    _spd = value;
                }
            }
        }
        public float HIT { get; set; }
        public int MP
        {
            get
            {
                return _mp;
            }
            set
            {
                if(value < 0)
                {
                    UnityEngine.Debug.Log("魔法值负数错误");
                }
            }
        }
        public int EXP { get; set; }

        public Vector3 position;
        public Weapon equipedWeapon;

        public PlayerCore(float spd, int mp, float atn, float hit)
        {
            SPD = spd;
            _mp = mp;
            ATN = atn;
            HIT = hit;
            level = 1;
            EXP = 0;
            maxExp = new int[21];
            for(int i=1; i<=20; ++i)
            {
                maxExp[i] = (int)UnityEngine.Mathf.Pow(((float)i + 10f), 2f);
            }
        }

        public void LevelUp()       //人物升级、重新计算当前属性值
        {

        }

        private void RefreshAttr()  //使用属性成长函数计算最新人物基本属性值
        {

        }

        public override string ToString()
        {
            return String.Format("ATN:{0}   SPD:{1}   MP:{2}   HIT:{3}", ATN, SPD, MP, HIT);
        }
    }
}
