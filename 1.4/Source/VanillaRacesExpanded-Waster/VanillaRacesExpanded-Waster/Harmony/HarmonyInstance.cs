using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;

namespace VanillaRacesExpandedWaster
{

    public class HarmonyInstance : Mod
    {
        public HarmonyInstance(ModContentPack content) : base(content)
        {
            harmonyInstance = new Harmony("OskarPotocki.VREWaster");
            harmonyInstance.PatchAll();
        }

        public static Harmony harmonyInstance;
    }

}
