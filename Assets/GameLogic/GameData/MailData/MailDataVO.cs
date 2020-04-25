using Game;
using Game.DataModel;
using Msg.ClientMessage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailDataVO
{
    public int mMailID { get; private set; }//�ʼ�ID
    public int mMailType { get; private set; }//�ʼ�����
    public int mMailSubType { get; private set; }//�ʼ�������
    public string mTitle { get; private set; }//�ʼ�����
    public string mSendName { get; private set; }//����������
    public int mSendTime { get; private set; }//����ʱ��
    public int mLeftSecsTime { get; private set; }//ʣ��ʱ��
    public bool mIsRead { get; private set; }//�Ƿ��Ѷ�
    public bool mIsGetAtt { get; private set; }//�Ƿ�����ȡ
    public bool mIsHasAtt { get; private set; }//�Ƿ��и���
    public int mValue { get; private set; }//��������
    public string mContent { get; private set; }//�ʼ�����
    public List<ItemInfo> mLstAtt { get; private set; }//����
    public MailXDM mMailXDM { get; private set; }
    public bool mIsDetail { get; private set; }
    

    public void OnInit(MailBasicData value)
    {
        mMailID = value.Id;
        mMailType = value.Type;
        mMailSubType = value.Subtype;
        mSendName = value.SenderName;
        mSendTime = value.SendTime;
        mLeftSecsTime = value.LeftSecs + (int)Time.realtimeSinceStartup;
        mIsRead = value.IsRead;
        mIsGetAtt = value.IsGetAttached;
        mIsHasAtt = value.HasAttached;
        mValue = value.Value;
        if (mMailSubType > 0)
        {
            mMailXDM = XTable.MailXTable.GetByID(mMailSubType);
            if (mMailXDM == null)
            {
                mTitle = value.Title;
                Debuger.LogError("ID:" + mMailSubType);
            }
            else
            {
                mTitle = KLocalization.GetLocalString(mMailXDM.MailTitleID);
            }
        }
        else
        {
            mTitle = value.Title;
        }
        mIsDetail = false;
    }

    public int LeftSecsTime
    {
        get { return mLeftSecsTime - (int)Time.realtimeSinceStartup; }
    }

    public void OnDetail(MailDetail value)
    {
        mIsDetail = true;
        if (mMailSubType > 0)
        {
            if (mMailXDM == null)
            {
                mContent = value.Content;
                Debuger.LogError("ID:" + mMailSubType);
            }
            else
            {
                mContent = KLocalization.GetLocalString(mMailXDM.MailContentID);
            }
        }
        else
        {
            mContent = value.Content;
        }
        mLstAtt = new List<ItemInfo>();
        mLstAtt.AddRange(value.AttachedItems);
        mIsRead = true;
    }

    public void OnIsGetAtt()
    {
        mIsRead = true;
        mIsGetAtt = true;
    }
}
