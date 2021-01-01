﻿using System.Collections.Generic;
using Config;
using UnityEditor;

namespace Utils {
    public static class ConfUtil {
        public static Dictionary<int, T> LoadConf<T>() where T : UnityEngine.Object, IConfig {
            string[] guids = AssetDatabase.FindAssets("t: ConfGarbage");
            int count = guids.Length;
            var dict = new Dictionary<int, T>(count);
            for (int i = 0; i < count; i++) {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                T conf = AssetDatabase.LoadAssetAtPath<T>(path);
                dict.Add(conf.ID, conf);
            }
            return dict;
        }
    }
}