using Msg.ClientMessage;
using UnityEngine;

namespace Game
{
    public class PlayerDataVO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int mPlayerID { get; private set; }
        /// <summary>
        /// �˺�
        /// </summary>
        public string mAcc { get; private set; }
        /// <summary>
        /// �ȼ� 
        /// </summary>
        public int mLevel { get; private set; }
        /// <summary>
        /// ����
        /// </summary>
        public int mExp { get; private set; }
        /// <summary>
        /// ���
        /// </summary>
        public int mGold { get; private set; }
        /// <summary>
        /// ��ʯ
        /// </summary>
        public int mDiamond { get; private set; }
        /// <summary>
        /// ͷ��
        /// </summary>
        public int mHead { get; private set; }
        /// <summary>
        /// VIP�ȼ�
        /// </summary>
        public int mVIPLevel { get; private set; }
        /// <summary>
        /// �ǳ�
        /// </summary>
        public string mName { get; private set; }
        /// <summary>
        /// ϵͳʱ��
        /// </summary>
        public int mSysTime { get; private set; }
        /// <summary>
        /// ��ǰͨ�عؿ���
        /// </summary>
        public int mCurMaxStage { get; private set; }
        /// <summary>
        /// ����ͨ�عؿ���
        /// </summary>
        public int mCurUnlockMaxStage { get; private set; }
        /// <summary>
        /// ����ֵ
        /// </summary>
        public int mCharmVal { get; private set; }
        /// <summary>
        /// ������
        /// </summary>
        public int mStar { get; private set; }
        /// <summary>
        /// ������
        /// </summary>
        public int mZan { get; private set; }
        /// <summary>
        /// è��
        /// </summary>
        public int mCatFood { get; private set; }
        /// <summary>
        /// ����
        /// </summary>
        public int mSpirit { get; private set; }
        /// <summary>
        /// �����
        /// </summary>
        public int mFriendPoints { get; private set; }
        /// <summary>
        /// ��ʯ
        /// </summary>
        public int mSoulStone { get; private set; }
        /// <summary>
        /// ����ѫ��
        /// </summary>
        public int mCharmMetal { get; private set; }
        /// <summary>
        /// ��ʷ���������
        /// </summary>
        public int mHistoricalMaxStar { get; private set; }
        /// <summary>
        /// ��������
        /// </summary>
        public int mChangeNameNum { get; private set; }
        /// <summary>
        /// ������Ѹ�������
        /// </summary>
        public int mChangeNameFreeNum { get; private set; }
        /// <summary>
        /// �����۸�
        /// </summary>
        public int mChangeNameCostDiamond { get; private set; }
        /// <summary>
        /// ��һ�λظ�����ʣ��ʱ��
        /// </summary>
        public int mNextStaminaRemainSecs { get; private set; }

        /// <summary>
        /// �ж��� 
        /// </summary>
        /// <returns></returns>
        public int Vigour
        {
            get { return BagDataModel.Instance.GetItemCountById(ItemIDConst.Vigour); }
        }


        public void OnInit(S2CPlayerInfoResponse value)
        {
            mLevel = value.Level;
            mExp = value.Exp;
            mGold = value.Gold;
            mDiamond = value.Diamond;
            mHead = value.Head;
            mVIPLevel = value.VipLevel;
            mName = value.Name;
            mSysTime = value.SysTime;
            mCurMaxStage = value.CurMaxStage;
            mCurUnlockMaxStage = value.CurUnlockMaxStage;
            mCharmVal = value.CharmVal;
            mStar = value.Star;
            mZan = value.Zan;
            mCatFood = value.CatFood;
            mSpirit = value.Spirit;
            mFriendPoints = value.FriendPoints;
            mSoulStone = value.SoulStone;
            mCharmMetal = value.CharmMetal;
            mHistoricalMaxStar = value.HistoricalMaxStar;
            mChangeNameNum = value.ChangeNameNum;
            mChangeNameFreeNum = value.ChangeNameFreeNum;
            mChangeNameCostDiamond = value.ChangeNameCostDiamond;
            mNextStaminaRemainSecs = value.NextStaminaRemainSecs + (int)Time.realtimeSinceStartup;
        }

        public int NextStaminaRemainSecs
        {
            get { return mNextStaminaRemainSecs - (int)Time.realtimeSinceStartup; }
        }

        public void OnGmae(int id, string acc)
        {
            mPlayerID = id;
            mAcc = acc;
        }

        public void ChangeName(string name)
        {
            mName = name;
        }

        public void ChangeHead(int headId)
        {
            mHead = headId;
        }

        #region ����ϵͳ
       
        /// <summary>
        /// 
        /// </summary>
        public static Function[] _functions = new Function[(int)FunctionType.kMax];
        /// <summary>
        /// ����״̬(true ����)
        /// </summary>
        /// <param name="system"></param>
        /// <returns></returns>
        public bool GetFunction(FunctionType type)
        {
            var func = _functions[(int)type];
            if (func != null)
                return func.IsUnlock();
            return true;
        }

        public void RecoverFunction()
        {
            for (int i = _functions.Length - 1; i >= 0; i--)
            {
                var func = _functions[i];
                if (func != null)
                    func.state = FunctionState.fNone;
            }
            UpdateFunction();
        }

        public void UnlockFunction(FunctionType type, bool force)
        {
            var func = _functions[(int)type];
            if (func != null)
                func.Unlock(force);
            UpdateFunction();
        }

        public void LockFunction(FunctionType type, bool force)
        {
            var func = _functions[(int)type];
            if (func != null)
                func.Lock(force);
            UpdateFunction();
        }

        public void UpdateFunction()
        {
            for (int i = _functions.Length - 1; i >= 0; i--)
            {
                var func = _functions[i];
                if (func != null && !func.IsUnlock())
                {
                    bool unlock = true;
                    var conditions = func.conditions;
                    for (int j = 0; j < conditions.Length; j++)
                    {
                        if (conditions[j] == (int)FunctionUnlockType.kGrade)
                        {
                            if (mLevel < func.parameters[j])
                            {
                                unlock = false;
                                break;
                            }
                        }
                        else if (conditions[j] == (int)FunctionUnlockType.kLevel)
                        {
                            if (mCurMaxStage < func.parameters[j])
                            {
                                unlock = false;
                                break;
                            }
                        }
                    }

                    if (unlock)
                        func.Unlock();
                }
            }
        }
        #endregion

    }

    #region ����ϵͳ
    public enum FunctionType : byte
    {
        kNone = 0,
        kBag = 1,
        kCat = 2,
        kShop = 3,
        kBuilding = 4,
        kHandbook = 5,
        kMission = 6,
        kFriend = 7,
        kDrawCard = 8,
        kMatch3 = 9,
        kMail = 10,
        kActivity = 11,
        kRanking = 12,
        kMax,
    }

    public enum FunctionState : byte
    {
        fNone = 0,
        fLock = 1,
        fUnlock = 2,
        fForce = 4,
        fForceLock = 5,
        fForceUnlock = 6,
    }

    public enum FunctionUnlockType
    {
        kNone = 0,
        kGrade = 1,
        kLevel = 2,
    }

    public class Function
    {
        public FunctionType type;
        public FunctionState state;
        public int[] conditions;
        public int[] parameters;

        public void Lock(bool force = false)
        {
            if (force)
                state = FunctionState.fForceLock;
            else
            {
                if ((state & FunctionState.fForce) == 0)
                    state = FunctionState.fUnlock;
            }
        }

        public void Unlock(bool force = false)
        {
            if (force)
                state = FunctionState.fForceUnlock;
            else
            {
                if ((state & FunctionState.fForce) == 0)
                    state = FunctionState.fUnlock;
            }
        }

        public bool IsUnlock()
        {
            return (state & FunctionState.fUnlock) != 0;
        }
    }
    #endregion

}
