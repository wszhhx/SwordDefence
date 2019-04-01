//创建日期：2019/4/1
//版本：    v0.01
//说明：    防御塔核心数据

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._02.Scripts
{
    [Serializable]
    public class TowerCore
    {
        public myVector3 position;
        private int _level;
        private float _atk;
        private float _ats;
        private int _id;
        private float _atkrange;
        public towerState state;
        public towerAtkOption atkOption;
        public Resource costResource;
        public int LEVEL
        {
            get
            {
                return _level;
            }
        }
        public float ATK
        {
            get
            {
                return _atk;
            }
        }
        public float ATS
        {
            get
            {
                return _ats;
            }
        }
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public float RANGE
        {
            get
            {
                return _atkrange;
            }
        }

        public TowerCore()
        {
            _atk = 30.0f;
            _ats = 2.0f;
            _id = 1;
            _level = 1;
            _atkrange = 8;
            state = towerState.exist;    //测试时先设为已经建造好
            atkOption = towerAtkOption.distance;
            costResource = new Resource(30, 0, 0);
        }

        public bool LevelUp()   //判断是否可以升级，并做相应数值更新
        {
            return true;
        }
    }
}
