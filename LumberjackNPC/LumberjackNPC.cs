using Terraria.ModLoader;

namespace LumberjackNPC
{
	class LumberjackNPC : Mod
	{
		public LumberjackNPC()
		{
		}

        public override void PostSetupContent()
        {
            Mod censusMod = ModLoader.GetMod("Census");
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", NPCType("Lumberjack"), "When Eye of Ctulhu has been defeated");
            }
        }
    }
}
