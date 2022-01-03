using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


using System.Reflection;


namespace TutorialFixes
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class ReplaceBadTutorials : MonoBehaviour
    {


        public void Start()
        {
            string ROOT_PATH = KSPUtil.ApplicationRootPath;
            string TRAININGDIR = "saves/training";

            string MOD = Assembly.GetAssembly(typeof(ReplaceBadTutorials)).GetName().Name;

            String CONFIG_BASE_FOLDER = ROOT_PATH + "GameData/";
            String TT_BASE_FOLDER = CONFIG_BASE_FOLDER + MOD + "/";
            string COPYFROM = TT_BASE_FOLDER + "PluginData/" + TRAININGDIR;
            string COPYTO = ROOT_PATH + TRAININGDIR + "/";

            foreach (var s in Directory.GetFiles(COPYFROM))
            {
                string filename = Path.GetFileName(s);

                Debug.Log("TutorialFix: Copying replacement file: " + s + " to " + COPYTO  + filename);

                File.Copy(s, COPYTO +  filename, true);
            }
        }
    }
}
