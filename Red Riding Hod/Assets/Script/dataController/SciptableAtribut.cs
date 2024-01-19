using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemDataLoad;

[CreateAssetMenu(fileName = "SciptableAtribut", menuName = "Red Riding Hod/SciptableAtribut", order = 0)]
public class SciptableAtribut : ScriptableObject {
    public WeaponsDataTemplate[] WeaponsData;
    public PlayerAtteributeDataTemplate[] PlayerAtteributeData;

}
