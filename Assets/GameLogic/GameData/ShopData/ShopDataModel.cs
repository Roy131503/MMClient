using Game;
using Game.DataModel;
using Msg.ClientMessage;
using System.Collections.Generic;

public class ShopIDConst
{
    public const int Special = 1;//�����̵�
    public const int FriendPoint = 2;//������̵�
    public const int CharmMedal = 3;//����ѫ���̵�
    public const int Diamond = 4;//��ʯ�̵�
    public const int SoulStone = 5;//��ʯ�̵�
    public const int Other = 6;//�����̵�
    public const int Attire = 7;//װ���̵�
    public const int BodyPower = 8;//�����̵�
}
public class ShopTypeConst
{
    public const int Prop = 0;//����
    public const int SoulStone = 1;//��ʯ�̵�
    public const int Diamond = 2;//��ʯ�̵�
    public const int Attire = 3;//װ���̵�
}
public class PropShopConst
{
    public const int Special = 1;//�����̵�
    public const int FriendPoint = 2;//������̵�
    public const int CharmMedal = 3;//����ѫ���̵�
}
public class SoulStoneConst
{
    public const int SoulStoneExchange = 0;//��ʯ�һ�
    public const int SoulStoneObtain = 1;//��ʯ��ȡ
}


public class ShopDataModel : DataModelBase<ShopDataModel>
{
    public Dictionary<int, List<ShopDataVO>> _allShop { get; private set; } = new Dictionary<int, List<ShopDataVO>>();

    public void ExeShopData(S2CShopItemsResult value)
    {
        List<ShopDataVO> lstVO = new List<ShopDataVO>();
        ShopDataVO vo;
        if (value.Items != null && value.Items.Count > 0)
        {
            for (int i = 0; i < value.Items.Count; i++)
            {
                vo = new ShopDataVO();
                vo.OnInit(value.Items[i]);
                lstVO.Add(vo);
            }
            lstVO.Sort((x, y) => x.mItemId.CompareTo(y.mItemId));
            if (_allShop.ContainsKey(value.ShopId))
                _allShop[value.ShopId] = lstVO;
            else
                _allShop.Add(value.ShopId, lstVO);
            EventData eventData = new EventData();
            eventData.Integer = value.ShopId;
            DispatchEvent(ShopEvent.ShopData, eventData);
        }
    }

    public void ExeBuyItem(S2CBuyShopItemResult value)
    {
        if (_allShop.ContainsKey(value.ShopId))
        {
            for (int i = 0; i < _allShop[value.ShopId].Count; i++)
            {
                if (_allShop[value.ShopId][i].mItemId == value.ItemId && _allShop[value.ShopId][i].mItemNum >= 0)
                    _allShop[value.ShopId][i].OnItemNum(value.ItemNum);
            }
            DispatchEvent(ShopEvent.BuyItem);
        }
    }
}
