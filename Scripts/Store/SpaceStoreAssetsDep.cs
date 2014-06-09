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
	public class SpaceStoreAssetsDep : IStoreAssets
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
/* EquippableVGs    --> */    SHIP_1_GOOD, SHIP_2_GOOD, SHIP_3_GOOD, SHIP_4_GOOD,
/* SingleUsePackVGs --> */
/* UpgradeVGs       --> */
			};
		}

		public VirtualCurrencyPack[] GetCurrencyPacks ()
		{
			return new VirtualCurrencyPack[] {
				ORANGE_POWER_PACK, BLUE_POWER_PACK, GREEN_POWER_PACK
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
		public const string SHIP_1_GOOD_ITEM_ID = "ship_1";
		public const string SHIP_2_GOOD_ITEM_ID = "ship_2";
		public const string SHIP_3_GOOD_ITEM_ID = "ship_3";
		public const string SHIP_4_GOOD_ITEM_ID = "ship_4";
		public const string PURPLE_BLAST_GOOD_ITEM_ID = "purple_blast";
		public const string GREEN_RADAR_GOOD_ITEM_ID = "green_radar";
		public const string SUPER_CHARGE_GOOD_ITEM_ID = "super_charge";
		public const string DEATH_SUN_GOOD_ITEM_ID = "death_sun";
		public const string ROCKET_LAUNCHER_GOOD_ITEM_ID = "rocket_launcher";
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
			                                                       "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                                       ROCKET_LAUNCHER_GOOD_ITEM_ID, // item id
			                                                       new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 2500)
		                                                       );
		// the way this virtual good is purchased
		/* LifetimeVGs */
		/* EquippableVGs */
		public static VirtualGood SHIP_1_GOOD = new EquippableVG (
			                                              EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                              "Ship 1", // name
			                                              "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                              SHIP_1_GOOD_ITEM_ID, // item id
			                                              new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 250)
		                                              );
		// the way this virtual good is purchased
		public static VirtualGood SHIP_2_GOOD = new EquippableVG (
			                                              EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                              "Ship 2", // name
			                                              "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                              SHIP_2_GOOD_ITEM_ID, // item id
			                                              new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 250)
		                                              );
		// the way this virtual good is purchased
		public static VirtualGood SHIP_3_GOOD = new EquippableVG (
			                                              EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                              "Ship 3", // name
			                                              "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                              SHIP_3_GOOD_ITEM_ID, // item id
			                                              new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 250)
		                                              );
		// the way this virtual good is purchased
		public static VirtualGood SHIP_4_GOOD = new EquippableVG (
			                                              EquippableVG.EquippingModel.CATEGORY, // The equipping type
			                                              "Ship 4", // name
			                                              "In publishing and graphic design, lorem ipsum is placeholder text (filler text)", // description
			                                              SHIP_4_GOOD_ITEM_ID, // item id
			                                              new PurchaseWithVirtualItem (POWER_CURRENCY_ITEM_ID, 2500)
		                                              );
		// the way this virtual good is purchased
		/* SingleUsePackVGs */
		/* UpgradeVGs */
		/** Virtual Categories **/

        
		public static VirtualCategory STARSHIPS_CATEGORY = new VirtualCategory (
			                                                         "Starships", // name
			                                                         new List<string> (
				                                                         new string[] {
					SHIP_1_GOOD_ITEM_ID,
					SHIP_2_GOOD_ITEM_ID,
					SHIP_3_GOOD_ITEM_ID,
					SHIP_4_GOOD_ITEM_ID
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
					DEATH_SUN_GOOD_ITEM_ID
				}
			                                                       )
		                                                       );
		public static VirtualCategory UPGRADES_CATEGORY = new VirtualCategory (
			                                                        "Upgrades", // name
			                                                        new List<string> (
				                                                        new string[] { ROCKET_LAUNCHER_GOOD_ITEM_ID }
			                                                        )
		                                                        );
		/** Non Consumable Items **/
	}
}