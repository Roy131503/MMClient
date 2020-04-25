using Game.DataModel;
using Msg.ClientMessage;
using System.Collections.Generic;
using UnityEngine;



public class ShopDataVO
{
    public int mItemId { get; private set; }//��ƷID
    public int mItemNum { get; private set; }//��Ʒ����
    public int mNameId { get; private set; }//��Ʒ����ID
    public int mCommodityId { get; private set; }//��ƷID
    public int mNumber { get; private set; }//��Ʒ����
    public int mItemType { get; private set; }//��Ʒ����
    public string mIcon { get; private set; }//��ƷIcon
    public ItemInfo mByCost { get;private set; }//��������
    public int mLimitedType { get; private set; }//��Ʒ��������
    public int mLimitedTime { get; private set; }//��Ʒ����ʱ��(��)
    public int mLimitedNum { get; private set; }//��Ʒ��������
    public List<ItemInfo> mShow { get; private set; }//��Ʒչʾ
    public int mPayID { get; private set; }//BundleID
    public ItemXDM itemXDM { get; private set; }



    public void OnInit(S2CShopItem value)
    {
        mItemId = value.ItemId;
        mItemNum = value.LeftNum;
        ShopXDM xdm = XTable.ShopXTable.GetByID(mItemId);
        mNameId = xdm.Name;
        mCommodityId = xdm.CommodityId;
        mNumber = xdm.Number;
        mItemType = xdm.CommodityType;
        if (mItemType == 14)
            itemXDM = XTable.ItemXTable.GetByID(xdm.CommodityId);
        mIcon = xdm.Icon;
        mByCost = new ItemInfo();
        if (xdm.BuyCost != null && xdm.BuyCost.Count % 2 == 0)
        {
            for (int i = 0; i < xdm.BuyCost.Count; i += 2)
            {
                mByCost.ItemCfgId = xdm.BuyCost[i];
                mByCost.ItemNum = xdm.BuyCost[i + 1];
            }
        }
        mLimitedType = xdm.LimitedType;
        mLimitedTime = xdm.LimitedTime;
        mLimitedNum = xdm.LimitedNumber;
        mShow = new List<ItemInfo>();
        if (xdm.Show != null && xdm.Show.Count % 2 == 0)
        {
            for (int i = 0; i < xdm.Show.Count; i += 2)
            {
                ItemInfo info = new ItemInfo();
                info.ItemCfgId = xdm.Show[i];
                info.ItemNum = xdm.Show[i + 1];
                mShow.Add(info);
            }
        }
        mPayID = xdm.PayID;
    }

    public void OnItemNum(int num)
    {
        mItemNum -= num;
    }
}
