using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla;

namespace Soomla.Example
{
    public class HHAssets : IStoreAssets
    {
        public int GetVersion ()
        {
            return 0;
        }
        
        public VirtualCurrency[] GetCurrencies ()
        {
            return new VirtualCurrency[]{COIN_CURRENCY};
        }
        
        public VirtualCurrencyPack[] GetCurrencyPacks ()
        {
            return new VirtualCurrencyPack[] {TEN_COINS_PACK};
        }

        #region IStoreAssets implementation


        public VirtualGood[] GetGoods ()
        {
            throw new System.NotImplementedException ();
        }


        public VirtualCategory[] GetCategories ()
        {
            throw new System.NotImplementedException ();
        }


        public NonConsumableItem[] GetNonConsumableItems ()
        {
            throw new System.NotImplementedException ();
        }


        #endregion

        /* public VirtualCategory[] GetCategories ()
        {
            return new VirtualCategory[]{GENERAL_CATEGORY};
        }
        
        public NonConsumableItem[] GetNonConsumableItems ()
        {
            return new NonConsumableItem[]{NO_ADDS_NONCONS};
        }*/
        
        public const string TEN_COINS_PACK_PRODUCT_ID = "fplane";
        public const string COIN_CURRENCY_ITEM_ID = "currency_coin";
        
        public static VirtualCurrency COIN_CURRENCY = new VirtualCurrency (
            "Coins",
            "",
            COIN_CURRENCY_ITEM_ID
        );
        
        public static VirtualCurrencyPack TEN_COINS_PACK = new VirtualCurrencyPack (
            "10 Coins",                    // name
            "A pack of 10 coins",      // description
            "coins_10",                    // item id
            10,
            COIN_CURRENCY_ITEM_ID,     // the currency associated with this pack
            new PurchaseWithMarket (TEN_COINS_PACK_PRODUCT_ID, 60.00)
        );
    }
}