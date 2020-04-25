using Msg.ClientMessage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendDataVO
{
    public int mPlayerId { get; private set; }//�������ID
    public string mName { get; private set; }//�����ǳ�
    public int mHeadId { get; private set; }//����ͷ��ID
    public int mLevel { get; private set; }//���ѵȼ�
    public int mVipLevel { get; private set; }//����VIP�ȼ�
    public int mLastLogin { get; private set; }//�����ϴε�½ʱ��
    public int mFriendPoint { get; private set; }//�����
    public int mLeftGiveSecond { get; private set; }//ʣ������ʱ��
    public int mUnreadMessageNum { get; private set; }//δ����Ϣ����
    public int mZanNum { get; private set; }//������
    public bool mIsZan { get; private set; }//�Ƿ��޹�
    public bool mIsOnLine { get; private set; }//�Ƿ�����


    

    public void OnInit(FriendInfo info)
    {
        mPlayerId = info.PlayerId;
        mName = info.Name;
        mHeadId = info.Head;
        mLevel = info.Level;
        mVipLevel = info.VipLevel;
        mLastLogin = info.LastLogin;
        mFriendPoint = info.FriendPoints;
        mLeftGiveSecond = info.LeftGiveSeconds + (int)Time.realtimeSinceStartup;
        mUnreadMessageNum = info.UnreadMessageNum;
        mZanNum = info.Zan;
        mIsZan = info.IsZan;
        mIsOnLine = info.IsOnline;
    }

    public int LeftGiveSecond
    {
        get { return mLeftGiveSecond - (int)Time.realtimeSinceStartup; }
    }

    public void OnLeftGiveSecond(int time)
    {
        mLeftGiveSecond = time + (int)Time.realtimeSinceStartup;
    }

    public void OnFriendPoint()
    {
        mFriendPoint = 0;
    }

    public void OnZanNum(int num)
    {
        mIsZan = true;
        mZanNum = num;
    }
}
