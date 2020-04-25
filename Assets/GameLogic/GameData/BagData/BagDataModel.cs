using Game.DataModel;
using Msg.ClientMessage;
using System.Collections.Generic;

namespace Game
{
    public class BagDataModel : DataModelBase<BagDataModel>
    {
        private Dictionary<int, ItemInfo> _dictAllItems = new Dictionary<int, ItemInfo>();

        public void ExeUpdateItem(S2CItemsInfoUpdate value)
        {
            if (value.Items == null || value.Items.Count == 0)
                return;
            List<int> changeIds = new List<int>();
            ItemInfo info;
            for (int i = 0; i < value.Items.Count; i++)
            {
                info = value.Items[i];
                if (!changeIds.Contains(info.ItemCfgId))
                    changeIds.Add(info.ItemCfgId);
                if (_dictAllItems.ContainsKey(info.ItemCfgId))
                {
                    _dictAllItems[info.ItemCfgId].ItemNum = info.ItemNum;
                    if (_dictAllItems[info.ItemCfgId].ItemNum <= 0)
                        _dictAllItems.Remove(info.ItemCfgId);
                }
                else
                    _dictAllItems.Add(info.ItemCfgId, info);
            }
            DispatchEvent(BagEvent.BagDataRefresh);
        }

        public void ExeBagData(S2CGetItemInfos value)
        {
            _dictAllItems.Clear();
            for (int i = 0; i < value.Items.Count; i++)
            {
                if (value.Items[i].ItemNum > 0)
                    _dictAllItems.Add(value.Items[i].ItemCfgId, value.Items[i]);
            }
            DispatchEvent(BagEvent.BagAllDataRefresh);
        }

        public void ExeSellItem(S2CSellItemResult value)
        {
            DispatchEvent(BagEvent.BagSellItem);
        }

        public void ExeUseItem(S2CUseItem value)
        {
            EventData eventData = new EventData();
            eventData.Data = value.CostItem;
            DispatchEvent(BagEvent.BagUseItem, eventData);
        }

        public List<ItemInfo> GetFormByType(int type)
        {
            List<ItemInfo> lstItemInfo = new List<ItemInfo>();
            Dictionary<int, ItemInfo>.ValueCollection valColl = _dictAllItems.Values;
            ItemXDM itemXDM;
            foreach (ItemInfo info in valColl)
            {
                itemXDM = XTable.ItemXTable.GetByID(info.ItemCfgId);
                if (itemXDM.Tag == ItemTagConst.Attire && itemXDM.EquipType == type)
                    lstItemInfo.Add(info);
            }
            lstItemInfo.Sort((x, y) => x.ItemCfgId.CompareTo(y.ItemCfgId));
            return lstItemInfo;
        }

        public List<ItemInfo> GetBagItemDataByType(int tagType)
        {
            List<ItemInfo> lstItemInfo = new List<ItemInfo>();
            Dictionary<int, ItemInfo>.ValueCollection valColl = _dictAllItems.Values;
            ItemXDM itemXDM;
            if (tagType > 0)
            {
                foreach (ItemInfo info in valColl)
                {
                    itemXDM = XTable.ItemXTable.GetByID(info.ItemCfgId);
                    if (itemXDM.Tag == tagType && itemXDM.Type != ItemTypeConst.Resource && itemXDM.Type != ItemTypeConst.ThreeIntoProp)
                        lstItemInfo.Add(info);
                }
            }
            else
            {
                foreach (ItemInfo info in valColl)
                {
                    itemXDM = XTable.ItemXTable.GetByID(info.ItemCfgId);
                    if (itemXDM.Type != ItemTypeConst.Resource && itemXDM.Type != ItemTypeConst.ThreeIntoProp && itemXDM.Type != ItemTypeConst.Head && itemXDM.Type != ItemTypeConst.Attire)
                        lstItemInfo.Add(info);
                }
            }
            lstItemInfo.Sort(OnSortInfo);
            return lstItemInfo;
        }

        public int OnSortInfo(ItemInfo v1, ItemInfo v2)
        {
            ItemXDM xdm1 = XTable.ItemXTable.GetByID(v1.ItemCfgId);
            ItemXDM xdm2 = XTable.ItemXTable.GetByID(v2.ItemCfgId);
            int index = xdm2.Tag.CompareTo(xdm1.Tag);
            if (index != 0)
                return index;
            index = xdm2.Rarity.CompareTo(xdm1.Rarity);
            if (index != 0)
                return index;
            index = xdm1.ID.CompareTo(xdm2.ID);
            return index;
        }

        public int GetItemCountById(int itemCfgId)
        {
            if (_dictAllItems.ContainsKey(itemCfgId))
                return _dictAllItems[itemCfgId].ItemNum;
            return 0;
        }

        public ItemInfo GetItemById(int itemCfgId)
        {
            if (_dictAllItems.ContainsKey(itemCfgId))
                return _dictAllItems[itemCfgId];
            return null;
        }
    }

    public class ItemIDConst
    {
        /// <summary>
        /// ���
        /// </summary>
        public const int Gold = 2;
        /// <summary>
        /// ��ʯ
        /// </summary>
        public const int Diamond = 3;
        /// <summary>
        /// �����
        /// </summary>
        public const int FriendPoint = 6;
        /// <summary>
        /// ����ֵ
        /// </summary>
        public const int Charm = 7;
        /// <summary>
        /// ��ʯ
        /// </summary>
        public const int SoulStone = 9;
        /// <summary>
        /// ��������
        /// </summary>
        public const int CharmBadge = 10;
        /// <summary>
        /// �������Ļ���
        /// </summary>
        public const int TimeProp = 11;
        /// <summary>
        /// �ж���
        /// </summary>
        public const int Vigour = 14;
        /// <summary>
        /// �ͼ��鿨��
        /// </summary>
        public const int LowCard = 201;
        /// <summary>
        /// �м��鿨��
        /// </summary>
        public const int MidCard = 202;
        /// <summary>
        /// �߼��鿨��
        /// </summary>
        public const int HighCard = 203;
    }

    public class ItemTypeConst
    {
        public const int Resource = 1;//��Դ
        public const int DrawCard = 2;//�鿨��
        public const int RemoProp = 3;//�������
        public const int ObstacleProp = 4;//�ϰ������
        public const int OrnamentMaterial = 5;//װ�������
        public const int FosterCard = 6;//������
        public const int CatFragment = 7;//è����Ƭ
        public const int PhysicalProp = 8;//��������
        public const int PopProp = 9;//��������
        public const int ThreeIntoProp = 10;//��������
        public const int Head = 11;//ͷ��
        public const int Attire = 12;//װ��
    }

    public class ItemRarityConst
    {
        public const int RarityOne = 1;
        public const int RarityTwo = 2;
        public const int RarityThree = 3;
        public const int RarityFour = 4;
        public const int RarityFive = 5;
    }

    public class ItemTagConst
    {
        public const int AllItem = 0;//ȫ��
        public const int Fragment = 1;//��Ƭ
        public const int Material = 2;//����
        public const int Consumable = 3;//����Ʒ
        public const int Head = 4;//ͷ��
        public const int Attire = 5;//װ��
    }

}
