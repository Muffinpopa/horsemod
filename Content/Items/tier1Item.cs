using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using horsemod.Content.Buffs;
using horsemod.Content.Projectiles.tier1;
using System.Collections.Generic;

namespace horsemod.Content.Items
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class tier1Item : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.horsemod.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Summon;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.mana = 8;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<tier1pony>();
			Item.buffType = ModContent.BuffType<tier1buff>();
			
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
            position = Main.MouseWorld;
            player.AddBuff(Item.buffType, 2);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltip to the gel to let the player know what will happen
            tooltips.Add(new(Mod, "Tier", "[Tier1]"));
            tooltips.Add(new(Mod, "Right-click", "Right-click with this item to change its attack type!"));
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 30);
			recipe.AddIngredient(ItemID.TungstenBar, 30);
			recipe.AddTile(TileID.Anvils);
		}
	}
}
