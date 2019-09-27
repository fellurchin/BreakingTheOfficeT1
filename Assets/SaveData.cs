using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveData
{
    static int[] levelsScore;
    static int[] maxScore;
    static int weaponEquiped;
    static int money;

    public static int[] LevelsScore { get => levelsScore; set => levelsScore = value; }
    public static int[] MaxScore { get => maxScore; set => maxScore = value; }
    public static int WeaponEquiped { get => weaponEquiped; set => weaponEquiped = value; }
    public static int Money { get => money; set => money = value; }
    public static int FirstMoney { get => FirstMoney; set => FirstMoney = value; }

    public static void GetDataFromPrefs()
    {
        //for(int x = 0; x < levelsScore.Length - 1; x++)
        //{
        //    levelsScore[x] = PlayerPrefs.GetInt(string.Format("level {0}", x), 0);
        //}
    }
}
