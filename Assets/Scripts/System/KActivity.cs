// ***********************************************************************
// Assembly         : Unity
// Author           : Kimch
// Created          : 2017-11-14
//
// Last Modified By : Kimch
// Last Modified On : 
// ***********************************************************************
// <copyright file= "KActivity" company=""></copyright>
// <summary></summary>
// ***********************************************************************
namespace Game
{
    using System.Collections;

    public class KActivity
    {
        public class SubInfo
        {
            /// <summary>
            /// �ӻID
            /// </summary>
            public int subID;
            /// <summary>
            /// �ӻ����
            /// </summary>
            public string description;
            /// <summary>
            /// �ӻĿ��ͼ��
            /// </summary>
            public string iconName;
            /// <summary>
            /// �ӻ��ǰ�������
            /// </summary>
            public int curValue;
            /// <summary>
            /// �ӻ����������
            /// </summary>
            public int maxValue;
            /// <summary>
            /// ����
            /// </summary>
            public KItem.ItemInfo[] rewardInfos;
            /// <summary>
            /// ��ǩ����:0.���ڽ���;1.�Ѿ�����;2.��δ����
            /// </summary>
            public int tagState;
            /// <summary>
            /// �ӻ״̬:0.δ���;1.�����;2.����ȡ
            /// </summary>
            public int status;
        }

        /// <summary>
        /// �ID
        /// </summary>
        public int id;
        /// <summary>
        /// 
        /// </summary>
        public int type;
        /// <summary>
        /// 
        /// </summary>
        public int nameId;
        /// <summary>
        /// 
        /// </summary>
        public int descriptionId;
        /// <summary>
        /// ͼƬ
        /// </summary>
        public string iconName;
        /// <summary>
        /// ��ǩ����
        /// </summary>
        public int flagState;
        /// <summary>
        /// �����
        /// </summary>
        public string displayName
        {
            get { return KLocalization.GetLocalString(nameId); }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string description
        {
            get { return KLocalization.GetLocalString(descriptionId); }
        }
        /// <summary>
        /// ���ǰ�������
        /// </summary>
        public int curValue;
        /// <summary>
        /// �����������
        /// </summary>
        public int maxValue;
        /// <summary>
        /// ���ʼʱ��
        /// </summary>
        public int startTimeStamp;
        /// <summary>
        /// �����ʱ��
        /// </summary>
        public int endTimeStamp;
        /// <summary>
        /// �ʣ��ʱ��
        /// </summary>
        public int leftTimeStamp;
        /// <summary>
        /// tips״̬:0.�ر�;1.����
        /// </summary>
        public int tipsStatus;
        /// <summary>
        /// ����б�
        /// </summary>
        public SubInfo[] subInfos;
        /// <summary>
        /// ����
        /// </summary>
        public KItem.ItemInfo[] rewardInfos;
        /// <summary>
        /// �״̬:0.δ���;1.�����;2.����ȡ
        /// </summary>
        public int status;
    }
}
