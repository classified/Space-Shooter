/*
 * Copyright (C) 2012 Soomla Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Example
{
	public class SpaceStoreAssets : IStoreAssets
	{
		// Make sure to change to your actual class name

		public int GetVersion ()
		{
			return 0;
		}

		public VirtualCurrency[] GetCurrencies ()
		{
			return  new VirtualCurrency[] {
				POWER_CURRENCY
			};
		}

		public VirtualGood[] GetGoods ()
		{
			return new VirtualGood[] {
				/* SingleUseVGs     --> */    PURPLE_BLAST_GOOD, GREEN_RADAR_GOOD, SUPER_CHARGE_GOOD, DEATH_SUN_GOOD, ROCKET_LAUNCHER_GOOD,
				/* LifetimeVGs      --> */
				/* EquippableVGs    --> */    TORPIDO_GOOD, RED_CARNAGE_GOOD, SILVER_ELITE_GOOD, YELLOW_MOZAIC_GOOD, BLOWING_HORNET_GOOD, STAR_BUCK_GOOD,
				/* SingleUsePackVGs --> */    DEATH_SUN_PACK_GOOD, ROCKET_LAUNCHER_PACK_GOOD,
				/* UpgradeVGs       --> */
			};
		}

		public VirtualCurrencyPack[] GetCurrencyPacks ()
		{
			return new VirtualCurrencyPack[] {
				ORANGE_POWER_PACK, BLUE_POWER_PACK, GREEN_POWER_PACK, ARROW_HEAD_PACK
			};
		}

		public VirtualCategory[] GetCategories ()
		{
			return new VirtualCategory[] {
				STARSHIPS_CATEGORY, WEAPONS_CATEGORY, UPGRADES_CATEGORY
			};
		}

		public NonConsumableItem[] GetNonConsumableItems ()
		{
			return new NonConsumableItem[] {

			};
		}


		/** Static Final members **/

		// Currencies
		public const string POWER_CURRENCY_ITEM_ID = "currency_power";

		// Goods
		public const string TORPIDO_GOOD_ITEM_ID = "ship_1";

		public const string RED_CARNAGE_GOOD_ITEM_ID = "ship_2";

		public const string SILVER_ELITE_GOOD_ITEM_ID = "ship_3";

		public const string YELLOW_MOZAIC_GOOD_ITEM_ID = "ship_4";

		public const string BLOWING_HORNET_GOOD_ITEM_ID = "item_150";

		public const string STAR_BUCK_GOOD_ITEM_ID = "item_135";

		public const string PURPLE_BLAST_GOOD_ITEM_ID = "purple_blast";

		public const string GREEN_RADAR_GOOD_ITEM_ID = "green_radar";

		public const string SUPER_CHARGE_GOOD_ITEM_ID = "super_charge";

		public const string DEATH_SUN_GOOD_ITEM_ID = "death_sun";

		public const string ROCKET_LAUNCHER_GOOD_ITEM_ID = "rocket_launcher";

		public const string DEATH_SUN_PACK_GOOD_ITEM_ID = "item_170";
		#if UNITY_ANDROID
		public const string DEATH_SUN_PACK_PRODUCT_ID = "item_170";
		#else
        public const string DEATH_SUN_PACK_PRODUCT_ID = "item_170";
        #endif

		public const string ROCKET_LAUNCHER_PACK_GOOD_ITEM_ID = "item_189";
		#if UNITY_ANDROID
		public const string ROCKET_LAUNCHER_PACK_PRODUCT_ID = "item_189";
		#else
        public const string ROCKET_LAUNCHER_PACK_PRODUCT_ID = "item_189";
        #endif


		// Currency Packs
		public const string ORANGE_POWER_PACK_ITEM_ID = "orange_power";
		#if UNITY_ANDROID
		public const string ORANGE_POWER_PRODUCT_ID = "android.test.purchased";
		#else
        public const string ORANGE_POWER_PRODUCT_ID = "orange_power";
        #endif
		public const string BLUE_POWER_PACK_ITEM_ID = "blue_power";
		#if UNITY_ANDROID
		public const string BLUE_POWER_PRODUCT_ID = "blue_power";
		#else
        public const string BLUE_POWER_PRODUCT_ID = "blue_power";
        #endif
		public const string GREEN_POWER_PACK_ITEM_ID = "green_power";
		#if UNITY_ANDROID
		public const string GREEN_POWER_PRODUCT_ID = "green_power";
		#else
        public const string GREEN_POWER_PRODUCT_ID = "green_power";
        #endif
		public const string ARROW_HEAD_PACK_ITEM_ID = "item_105";
		#if UNITY_ANDROID
		public const string ARROW_HEAD_PRODUCT_ID = "untitled_currency_pack";
		#else
        public const string ARROW_HEAD_PRODUCT_ID = "untitled_currency_pack";
        #endif

		// Non Consumables


		/** Virtual Currencies **/


		public static VirtualCurrency POWER_CURRENCY = new VirtualCurrency (
			                                                     "POWER", // name
			                                                     "", // description
			                                                     POWER_CURRENCY_ITEM_ID);
		// item id



		/** Virtual Currency Packs **/


		public static VirtualCurrencyPack ORANGE_POWER_PACK = new VirtualCurrencyPack (
			                                                            "Orange Power", // name
			                                                            "", // description
			                                                            ORANGE_POWER_PACK_ITEM_ID, // item id
			                                                            20000, // number of currencies in the pack
			                                                            POWER_CURRENCY_ITEM_ID, // the associated currency
			                                                            new PurchaseWithMarket (new MarketItem (ORANGE_POWER_PRODUCT_ID, MarketItem.Consumable.CONSUMABLE, 0.99))
		                                                            );

		public static VirtualCurrencyPack BLUE_POWER_PACK = new VirtualCurrencyPack (
			                                                          "Blue Power", // name
			                                                          "", // description
			                                                          BLUE_POWER_PACK_ITEM_ID, // item id
			                                                          50000, // number of currencies in the pack
			                                                          POWER_CURRENCY_ITEM_ID, // the associated currency
			                                                          new PurchaseWithMarket (new MarketItem (BLUE_POWER_PRODUCT_ID, MarketItem.Consumable.CONSUMABLE, 1.99))
		                                                          );

		public static VirtualCurrencyPack GREEN_POWER_PACK = new VirtualCurrencyPack (
			                                                           "Green Power", // name
			                                                           "", // description
			                                                           GREEN_POWER_PACK_ITEM_ID, // item id
			                                                           100000, // number of currencies in the pack
			                                                           POWER_CURRENCY_ITEM_ID, // the associated currency
			                                                           new PurchaseWithMarket (new MarketItem (GREEN_POWER_PRODUCT_ID, MarketItem.Consumable.CONSUMABLE, 2.99))
		                                                           );

		public static VirtualCurrencyPack ARROW_HEAD_PACK = new VirtualCurrencyPack (
			                                                          "Arrow Head", // name
			                                                          "Blow your Enemies with only one weapon", // description
			                                                          ARROW_HEAD_PACK_ITEM_ID, // item id
			                                                          100, // number of currencies in the pack
			                                                          POWER_CURRENCY_ITEM_ID, // the associated currency
			                                                          new PurchaseWithMarket (new MarketItem (ARROW_HEAD_PRODUCT_ID, MarketItem.Consumable.CONSUMABLE, 20.99))
		                                                          );



		/** Virtual Goods **/

		/* SingleUseVGs */

		public static VirtualGood PURPLE_BLAST_GOOD = new SingleUseVG (
			                                                    "Purple Blast", // name
			                                                    "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                    PURPLE_BLAST_GOOD_ITEM_ID, // item id
			                                                    new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 5000)
		                                                    );
		// the way this virtual good is purchased

		public static VirtualGood GREEN_RADAR_GOOD = new SingleUseVG (
			                                                   "Green Radar", // name
			                                                   "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                   GREEN_RADAR_GOOD_ITEM_ID, // item id
			                                                   new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 5000)
		                                                   );
		// the way this virtual good is purchased

		public static VirtualGood SUPER_CHARGE_GOOD = new SingleUseVG (
			                                                    "Super Charge", // name
			                                                    "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                    SUPER_CHARGE_GOOD_ITEM_ID, // item id
			                                                    new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 5000)
		                                                    );
		// the way this virtual good is purchased

		public static VirtualGood DEATH_SUN_GOOD = new SingleUseVG (
			                                                 "Death Sun", // name
			                                                 "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                 DEATH_SUN_GOOD_ITEM_ID, // item id
			                                                 new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 5000)
		                                                 );
		// the way this virtual good is purchased

		public static VirtualGood ROCKET_LAUNCHER_GOOD = new SingleUseVG (
			                                                       "Rocket Launcher", // name
			                                                       "Use Rockets against Enemy.", // description
			                                                       ROCKET_LAUNCHER_GOOD_ITEM_ID, // item id
			                                                       new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 2500)
		                                                       );
		// the way this virtual good is purchased

		/* LifetimeVGs */

		/* EquippableVGs */

		public static VirtualGood TORPIDO_GOOD = new EquippableVG (
			                                               EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                               "Torpido", // name
			                                               "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                               TORPIDO_GOOD_ITEM_ID, // item id
			                                               new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 2500)
		                                               );
		// the way this virtual good is purchased

		public static VirtualGood RED_CARNAGE_GOOD = new EquippableVG (
			                                                   EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                                   "Red Carnage", // name
			                                                   "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                   RED_CARNAGE_GOOD_ITEM_ID, // item id
			                                                   new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 2500)
		                                                   );
		// the way this virtual good is purchased

		public static VirtualGood SILVER_ELITE_GOOD = new EquippableVG (
			                                                    EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                                    "Silver Elite", // name
			                                                    "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                    SILVER_ELITE_GOOD_ITEM_ID, // item id
			                                                    new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 5000)
		                                                    );
		// the way this virtual good is purchased

		public static VirtualGood YELLOW_MOZAIC_GOOD = new EquippableVG (
			                                                     EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                                     "Yellow Mozaic", // name
			                                                     "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                     YELLOW_MOZAIC_GOOD_ITEM_ID, // item id
			                                                     new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 5000)
		                                                     );
		// the way this virtual good is purchased

		public static VirtualGood BLOWING_HORNET_GOOD = new EquippableVG (
			                                                      EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                                      "Blowing Hornet", // name
			                                                      "", // description
			                                                      BLOWING_HORNET_GOOD_ITEM_ID, // item id
			                                                      new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 10000)
		                                                      );
		// the way this virtual good is purchased

		public static VirtualGood STAR_BUCK_GOOD = new EquippableVG (
			                                                 EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                                 "Star Buck", // name
			                                                 "FLY WITH BUCKSHOT", // description
			                                                 STAR_BUCK_GOOD_ITEM_ID, // item id
			                                                 new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 10000)
		                                                 );
		// the way this virtual good is purchased

		/* SingleUsePackVGs */

		public static VirtualGood DEATH_SUN_PACK_GOOD = new SingleUsePackVG (
			                                                      DEATH_SUN_GOOD_ITEM_ID, // associated SingleUseVG
			                                                      25, // amount of virtual goods in the pack
			                                                      "Death Sun Pack", // name
			                                                      "", // description
			                                                      DEATH_SUN_PACK_GOOD_ITEM_ID, // item id
			                                                      new PurchaseWithMarket (new MarketItem (DEATH_SUN_PACK_PRODUCT_ID, MarketItem.Consumable.CONSUMABLE, 50))
		                                                      );
		// the way this virtual good is purchased

		public static VirtualGood ROCKET_LAUNCHER_PACK_GOOD = new SingleUsePackVG (
			                                                            ROCKET_LAUNCHER_GOOD_ITEM_ID, // associated SingleUseVG
			                                                            50, // amount of virtual goods in the pack
			                                                            "Rocket Launcher Pack", // name
			                                                            "Get the ultimate power", // description
			                                                            ROCKET_LAUNCHER_PACK_GOOD_ITEM_ID, // item id
			                                                            new PurchaseWithMarket (new MarketItem (ROCKET_LAUNCHER_PACK_PRODUCT_ID, MarketItem.Consumable.CONSUMABLE, 100))
		                                                            );
		// the way this virtual good is purchased

		/* UpgradeVGs */



		/** Virtual Categories **/


		public static VirtualCategory STARSHIPS_CATEGORY = new VirtualCategory (
			                                                         "Starships", // name
			                                                         new List<string> (
				                                                         new string[] {
					TORPIDO_GOOD_ITEM_ID,
					RED_CARNAGE_GOOD_ITEM_ID,
					SILVER_ELITE_GOOD_ITEM_ID,
					YELLOW_MOZAIC_GOOD_ITEM_ID,
					BLOWING_HORNET_GOOD_ITEM_ID
				}
			                                                         )
		                                                         );

		public static VirtualCategory WEAPONS_CATEGORY = new VirtualCategory (
			                                                       "Weapons", // name
			                                                       new List<string> (
				                                                       new string[] {
					PURPLE_BLAST_GOOD_ITEM_ID,
					GREEN_RADAR_GOOD_ITEM_ID,
					SUPER_CHARGE_GOOD_ITEM_ID,
					DEATH_SUN_GOOD_ITEM_ID,
					STAR_BUCK_GOOD_ITEM_ID,
					DEATH_SUN_PACK_GOOD_ITEM_ID
				}
			                                                       )
		                                                       );

		public static VirtualCategory UPGRADES_CATEGORY = new VirtualCategory (
			                                                        "Upgrades", // name
			                                                        new List<string> (
				                                                        new string[] {
					ROCKET_LAUNCHER_GOOD_ITEM_ID,
					ROCKET_LAUNCHER_PACK_GOOD_ITEM_ID
				}
			                                                        )
		                                                        );



		/** Non Consumable Items **/


	}

}

