using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum EnemyType {
    MELEE,
    RANGED
}

public static class EnemyWaves {
    // How does the Wave list work?
    // Will be storing 5 template waves that the game will loop through every 5 waves
    // One each loop, the game should scale the waves in difficulty by multiplying the number of enemies
    // ==========================================================================
    public const int WAVE_LIST_LEN = 5;
    public static Dictionary<EnemyType, int>[] WaveList { get; private set; } = new Dictionary<EnemyType, int>[WAVE_LIST_LEN] {
        new Dictionary<EnemyType, int>() { // Wave 1
            {EnemyType.MELEE, 1},
        },
        new Dictionary<EnemyType, int>() { // Wave 2
            {EnemyType.MELEE, 2},
            {EnemyType.RANGED, 1}  
        },
        new Dictionary<EnemyType, int>() { // Wave 3
            {EnemyType.MELEE, 2}, 
            {EnemyType.RANGED, 2} 
        },
        new Dictionary<EnemyType, int>() { // Wave 4
            {EnemyType.MELEE, 1},
            {EnemyType.RANGED, 3} 
        },
        new Dictionary<EnemyType, int>() { // Wave 5
            {EnemyType.MELEE, 3},
            {EnemyType.RANGED, 2}
        },
    };
}
