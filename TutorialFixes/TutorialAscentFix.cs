using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace TutorialAscentFix
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class TutorialAscentFixLoader : MonoBehaviour
    {
        private void Start()
        {
            Harmony harmony = new Harmony("TutorialAscentFix");
            harmony.PatchAll();
            Destroy(this);
        }
    }

    [HarmonyPatch(typeof(TutorialAscent))]
    [HarmonyPatch("OnTutorialSetup")]
    class PatchClass
    {
        static void Postfix(TutorialAscent __instance)
        {
            FieldInfo engine = AccessTools.Field(typeof(TutorialAscent), "engine");
            if (engine == null)
                return;

            TutorialScenario.TutorialFSM tutorial = AccessTools.Field(typeof(TutorialScenario), "Tutorial")?.GetValue(__instance) as TutorialScenario.TutorialFSM;
            if (tutorial == null)
                return;

            TutorialScenario.TutorialPage tutorialPage = tutorial.pages.Find(p => p.name == "lowerGone");
            if (tutorialPage == null)
                return;

            tutorialPage.OnEnter = delegate
            {
                __instance.instructor.PlayEmote(__instance.instructor.anim_true_nodB);
                engine.SetValue(__instance, null);
                Part part = FlightGlobals.ActiveVessel.parts.Find((Part p) => p.partInfo.name == "liquidEngine3.v2");
                if (part != null)
                {
                    engine.SetValue(__instance, part.Modules.GetModule<ModuleEngines>());
                }
            };
        }
    }
}
