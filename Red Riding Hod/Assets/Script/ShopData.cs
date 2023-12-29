using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    [System.Serializable]
    public class ShopData
    {
        public WeaponsInfo[] weaponsData;
        public PlayerAtteributeInfo[] playerAttributeData;
    }

    [System.Serializable]
    public class WeaponsInfo{
        public string name;
        public bool isUnlock;
        public int unlockCost;
        public int unlockLv;
        public WeaponsLv[] weaponsLv;
    }

    [System.Serializable]
    public class WeaponsLv{
        public int costLvUnlock;
        public float damage;
        public float atkSpeed;
    }

    [System.Serializable]
    public class PlayerAtteributeInfo{
        public string name;
        public int unlockCost;
        public int unlockLv;
        public PlayerAttributeLv[] AttributeLv;
    }

    [System.Serializable]
    public class PlayerAttributeLv{
        public int costLvUnlock;
        public float Amount;
    }
}

