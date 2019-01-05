using Terraria.ModLoader;

namespace LumberjackNPC.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class Lumberhat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Doesn't protect against falling trees.");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 1;
            item.vanity = true;
        }

        public override bool DrawHead()
        {
            return true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = drawAltHair = true;  
        }
    }
}