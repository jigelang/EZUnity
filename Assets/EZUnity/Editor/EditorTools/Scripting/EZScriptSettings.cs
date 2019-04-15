﻿/* Author:          ezhex1991@outlook.com
 * CreateTime:      2016-08-08 10:49:31
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace EZUnity
{
    public class EZScriptSettings : EZScriptableSingleton<EZScriptSettings>
    {
        public override string assetPath => "ProjectSettings/EZScriptSettings.asset";

        public string timeFormat = "yyyy-MM-dd HH:mm:ss";
        public List<string> extensionList = new List<string> { ".cs", ".lua", ".txt", ".shader", ".cginc" };

        static EZScriptSettings()
        {
            string oldPath = "ProjectSettings/EZScriptTemplate.asset";
            if (File.Exists(oldPath)) File.Move(oldPath, "ProjectSettings/EZScriptSettings.asset");
        }

        [Serializable]
        public class Pattern
        {
            public string Key = "";
            public string Value = "";
            public Pattern(string key = "", string value = "")
            {
                this.Key = key;
                this.Value = value;
            }
        }
        public List<Pattern> patternList = new List<Pattern>
        {
            new Pattern("#ORGANIZATION#", ""),
            new Pattern("#AUTHORNAME#", ""),
        };
    }
}