using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SystemDataLoad
{
    [System.Serializable]
    public class DataSlotTemplate //dipake untuk mengecek slot apakah sudah ter isi atau belum sama pembagian slot dan menyimpan waktu
    {
        public DataSlot[] DataSlot;
    }
    [System.Serializable]
    public class DataSlot
    {
        public string namaSlot;
        public string namaFileJson;
        public Waktu waktuMain;
        public bool isEmpety;
    }
    [System.Serializable]
    public class Waktu // format penyimpanan waktu
    {
        public int jam;
        public int menit;
        public int detik;
    }

    [System.Serializable]
    public class MainDataTemplate // data setiap slot yang menyimpan progres player;
    {
        public int totalGold;
        public int unlockLvRegion;
        public int lvSg;
        public int lvFg;
        public int lvBz;
        public int lvHp;
        public int lvArmor;
    }

    [System.Serializable]
    public class WeaponsDataTemplate // untuk menyimpan data setap lv dari weapon (data tidak dapat di ubah in game)
    {
        public string name;
        public bool isUnlock;
        public int unlockCost;
        public int unlockLv;
        public WeaponsLv[] weaponsLv;
    }

    [System.Serializable]
    public class WeaponsLv
    {
        public int costLvUnlock;
        public float damage;
        public float atkSpeed;
    }

    [System.Serializable]
    public class PlayerAtteributeDataTemplate // untuk menyimpan data setap lv dari atribut player (data tidak dapat di ubah in game)
    {
        public string name;
        public int unlockCost;
        public int unlockLv;
        public PlayerAttributeLv[] AttributeLv;
    }

    [System.Serializable]
    public class PlayerAttributeLv
    {
        public int costLvUnlock;
        public float Amount;
    }

}

