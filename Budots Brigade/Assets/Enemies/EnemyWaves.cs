using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum EnemyType {
    MELEE,
    RANGED
}

public static class EnemyWaves {
    // THE DREADED ENEMY WAVE LIST
    // ==========================================================================
    public const int FINAL_WAVE = 10;
    public static Dictionary<EnemyType, int>[] WaveList { get; private set; } = new Dictionary<EnemyType, int>[FINAL_WAVE] {
        new Dictionary<EnemyType, int>() { // Wave 1
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 2
            {EnemyType.MELEE, 2},
            {EnemyType.RANGED, 1}  
        },
        new Dictionary<EnemyType, int>() { // Wave 3
            {EnemyType.MELEE, 3} 
        },
        new Dictionary<EnemyType, int>() { // Wave 4
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 5
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 6
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 7
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 8
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 9
            {EnemyType.MELEE, 1} 
        },
        new Dictionary<EnemyType, int>() { // Wave 10
            {EnemyType.MELEE, 1} 
        },
    };
}
