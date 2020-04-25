//// ***********************************************************************
//// Assembly         : Unity
//// Author           : Kimch
//// Created          : #DATA#
////
//// Last Modified By : Kimch
//// Last Modified On : 
//// ***********************************************************************
//// <copyright file= "TutorialManager" company=""></copyright>
//// <summary></summary>
//// ***********************************************************************
//namespace Game
//{
//    using System.Collections;
//    using System.Collections.Generic;
//    using UnityEngine;

//    /// <summary>
//    /// ��������������
//    /// </summary>
//    public class KTutorialManager : KGameModule
//    {
//        #region Field

//        /// <summary>
//        /// �رս̳�
//        /// </summary>
//        public bool closeTutorial;

//        Dictionary<int, KTutorial> _tutorials = new Dictionary<int, KTutorial>();
//        Dictionary<int, KTutorialStage> _tutorialStages = new Dictionary<int, KTutorialStage>();
//        Dictionary<int, KTutorialAction> _tutorialActions = new Dictionary<int, KTutorialAction>();
//        Dictionary<int, KTutorialCondition> _tutorialConditions = new Dictionary<int, KTutorialCondition>();

//        /// <summary>
//        /// ��ǰ
//        /// </summary>
//        private KTutorial _currTutorial;
//        /// <summary>
//        /// ��Ծ��
//        /// </summary>
//        private List<KTutorial> _validTutorials = new List<KTutorial>();
//        /// <summary>
//        /// �Ѿ�������
//        /// </summary>
//        private List<KTutorial> _triggeredTutorials = new List<KTutorial>();

//        #endregion

//        #region Property

//        /// <summary>
//        /// ��ǰ����
//        /// </summary>
//        public KTutorial currTutorial
//        {
//            get { return _currTutorial; }
//        }

//        #endregion

//        #region Method

//        /// <summary>
//        /// ��������(����)
//        /// </summary>
//        /// <param name="condition"></param>
//        public void TriggerCondition(int condition)
//        {
//            if (closeTutorial)
//            {
//                return;
//            }

//            foreach (var item in _validTutorials)
//            {
//                if (!item.completed && item.Check(condition))
//                {
//                    //Debug.Log(item.id + "condition  gropId");
//                    if (_triggeredTutorials.Contains(item))
//                        continue;
//                    _triggeredTutorials.Add(item);
//                }
//            }
//        }

//        /// <summary>
//        /// ���
//        /// </summary>
//        public void CompleteStage()
//        {
//            if (_currTutorial != null)
//            {
//                _currTutorial.CompleteStep();
//                if (_currTutorial.completed)
//                {
//                    _validTutorials.Remove(_currTutorial);
//                    _currTutorial = null;
//                }
//            }
//        }

//        /// <summary>
//        /// ��ȡָ����
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        internal KTutorial GetTutorial(int id)
//        {
//            KTutorial ret;
//            _tutorials.TryGetValue(id, out ret);
//            return ret;
//        }

//        /// <summary>
//        /// ��ȡָ����
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        internal KTutorialStage GetStage(int id)
//        {
//            KTutorialStage ret;
//            _tutorialStages.TryGetValue(id, out ret);
//            return ret;
//        }

//        /// <summary>
//        /// ��ȡָ�����в�
//        /// </summary>
//        /// <param name="group"></param>
//        /// <param name="stages"></param>
//        internal void GetAllStages(int group, List<KTutorialStage> stages)
//        {
//            foreach (var kv in _tutorialStages)
//            {
//                var item = kv.Value;
//                if (item.group == group)
//                {
//                    stages.Add(item);
//                }
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        internal KTutorialAction GetAction(int id)
//        {
//            KTutorialAction ret;
//            _tutorialActions.TryGetValue(id, out ret);
//            return ret;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        internal KTutorialCondition GetCondition(int id)
//        {
//            KTutorialCondition ret;
//            _tutorialConditions.TryGetValue(id, out ret);
//            return ret;
//        }

//        public void Load(Hashtable table)
//        {
//            _tutorialConditions.Clear();
//            var conditionList = table.GetList("condition");
//            conditionList.Resolve((t) =>
//            {
//                var tmp = new KTutorialCondition();
//                tmp.Load(t);
//                _tutorialConditions.Add(tmp.id, tmp);
//            });

//            _tutorialActions.Clear();
//            var actionList = table.GetList("action");
//            actionList.Resolve((t) =>
//            {
//                var type = t.GetInt("Type");
//                var tmp = KTutorialAction.CreateAction(type);
//                tmp.Load(t);
//                _tutorialActions.Add(tmp.id, tmp);
//            });

//            _tutorialStages.Clear();
//            var stageList = table.GetList("stage");
//            stageList.Resolve((t) =>
//            {
//                var tmp = new KTutorialStage();
//                tmp.Load(t);
//                _tutorialStages.Add(tmp.id, tmp);
//            });

//            _tutorials.Clear();
//            var groupList = table.GetList("group");
//            groupList.Resolve((t) =>
//            {
//                var tmp = new KTutorial();
//                tmp.Load(t);
//                _tutorials.Add(tmp.id, tmp);
//            });
//        }

//        public void SaveStage(KTutorialStage stage)
//        {
//            string key = "p_" + KUser.SelfPlayer.id + "_ts_" + stage.id;
//            PlayerPrefs.SetInt(key, 1);
//            PlayerPrefs.Save();
//        }

//        public void ProcessData(object data)
//        {
//            foreach (var kv in _tutorialStages)
//            {
//                var item = kv.Value;
//                var key = "p_" + KUser.SelfPlayer.id + "_ts_" + item.id;
//                bool complete = PlayerPrefs.HasKey(key);
//                if (complete)
//                {
//                    item.completed = complete;
//                }
//            }

//            _validTutorials.Clear();
//            foreach (var kv in _tutorials)
//            {
//                var item = kv.Value;
//                if (item.HasValidStage())
//                {
//                    _validTutorials.Add(item);
//                }
//            }
//            _validTutorials.Sort((a, b) => a.priority.CompareTo(b.priority));
//        }

//        #endregion

//        #region Unity

//        public static KTutorialManager Instance;

//        private void Awake()
//        {
//            Instance = this;
//        }

//        // Use this for initialization
//        public override void Load()
//        {
//            TextAsset tmpText;
//            if (KAssetManager.Instance.TryGetExcelAsset("tutorials", out tmpText))
//            {
//                if (tmpText)
//                {
//                    var tmpJson = tmpText.bytes.ToJsonTable();
//                    Load(tmpJson);
//                }
//            }

//            //���ش�           
//        }

//        private void Update()
//        {
//            if (_currTutorial == null && _triggeredTutorials.Count > 0)
//            {
//                _currTutorial = _triggeredTutorials[0];
//                _currTutorial.Trigger();
//                _triggeredTutorials.Clear();
//            }

//            if (_currTutorial != null)
//            {
//                _currTutorial.Update();
//                if (_currTutorial.completed)
//                {
//                    _currTutorial = null;
//                }
//            }

//            for (int i = _validTutorials.Count - 1; i >= 0; i--)
//            {
//                var tutorial = _validTutorials[i];
//                if (tutorial.Jump())
//                {
//                    _validTutorials.RemoveAt(i);
//                }
//            }
//        }

//        #endregion
//    }
//}
