//创建日期：2019/3/27
//版本：    v0.01
//说明：    记录敌人的内核数据

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets._02.Scripts
{
    public class EnemyCore
    {
        private float _atk;
        private float _def;
        private float _maxhealth;
        private float _health;
        private float _speed;
        private int _money;
        public float ATK
        {
            get
            {
                return _atk;
            }
        }
        public float DEF
        {
            get
            {
                return _def;
            }
        }
        public float HP
        {
            get
            {
                return _health;
            }
        }
        public float SPD
        {
            get
            {
                return _speed;
            }
        }
        public float MAXHP
        {
            get
            {
                return _maxhealth;
            }
        }
        public int MONEY
        {
            get
            {
                return _money;
            }
        }
        public myVector3 position;

        public EnemyCore()
        {
            _atk = 12.0f;
            _def = 5.0f;
            _health = 100.0f;
            _maxhealth = 100.0f;
            _speed = 4.0f;
            _money = 10;
        }

        public bool BloodDeduction(float hp)
        {
            _health -= hp;
            if (_health <= 0)
                return true;
            else
                return false;
        }
    }
}
