//// ***********************************************************************
//// Assembly         : Unity
//// Author           : Kimch
//// Created          : #DATA#
////
//// Last Modified By : Kimch
//// Last Modified On : 
//// ***********************************************************************
//// <copyright file= "TutorialStage" company=""></copyright>
//// <summary></summary>
//// ***********************************************************************
//namespace Game
//{
//    using System.Collections;

//    public class KTutorialStage
//    {
//        public enum Status
//        {
//            kNone = 0,
//            kStarted = 1,//�Ѿ���ʼ
//            kCompleted = 2,
//        }

//        #region Field

//        public int id
//        {
//            get;
//            private set;
//        }

//        public int step
//        {
//            get;
//            private set;

//        }

//        public int group
//        {
//            get;
//            private set;
//        }

//        public int actionId
//        {
//            get;
//            private set;
//        }

//        public int conditionId
//        {
//            get;
//            private set;
//        }

//        public bool isKey
//        {
//            get;
//            private set;
//        }

//        public bool isForce
//        {
//            get;
//            private set;
//        }

//        public string unlockSystem
//        {
//            get;
//            private set;
//        }

//        /// <summary>
//        /// ״̬ 0��ʼ״̬
//        /// </summary>
//        public int status
//        {
//            get;
//            private set;
//        }

//        /// <summary>
//        /// �Ѿ����
//        /// </summary>
//        public bool completed
//        {
//            get
//            {
//                return status == (int)Status.kCompleted;
//            }
//            set
//            {
//                status = (int)Status.kCompleted;
//            }
//        }

//        /// <summary>
//        /// �ѿ�ʼ
//        /// </summary>
//        public bool started
//        {
//            get { return status >= (int)Status.kStarted; }
//        }

//        #endregion

//        #region Method

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public KTutorial GetTutorial()
//        {
//            return KTutorialManager.Instance.GetTutorial(group);
//        }

//        /// <summary>
//        /// ��ȡ��Ϊ
//        /// </summary>
//        /// <returns></returns>
//        public KTutorialAction GetAction()
//        {
//            return KTutorialManager.Instance.GetAction(actionId);
//        }

//        /// <summary>
//        /// ��ȡ����
//        /// </summary>
//        /// <returns></returns>
//        public KTutorialCondition GetCondition()
//        {
//            return KTutorialManager.Instance.GetCondition(conditionId);
//        }

//        /// <summary>
//        /// ��ʼ
//        /// </summary>
//        public void Start()
//        {
//            if (conditionId == 0 || GetCondition().GetResult())
//            {
//                this.status = (int)Status.kStarted;
//                this.GetAction().Execute();
//            }
//        }

//        /// <summary>
//        /// ���
//        /// </summary>
//        public void Complete()
//        {
//            this.status = (int)Status.kCompleted;
//            if (isKey)
//            {
//                Save();
//            }
//        }

//        /// <summary>
//        /// ��������
//        /// </summary>
//        public void Save()
//        {
//            KTutorialManager.Instance.SaveStage(this);
//        }

//        public void Load(Hashtable table)
//        {
//            id = table.GetInt("Id");
//            step = table.GetInt("Step");
//            group = table.GetInt("Group");
//            actionId = table.GetInt("Action");
//            conditionId = table.GetInt("Condition");

//            isKey = table.GetInt("IsKey") != 0;
//            isForce = table.GetInt("IsForce") != 0;

//            unlockSystem = table.GetString("Unlock");
//        }

//        #endregion
//    }
//}
