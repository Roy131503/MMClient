// ***********************************************************************
// Assembly         : Unity
// Author           : Kimch
// Created          : 
//
// Last Modified By : Kimch
// Last Modified On : 
// ***********************************************************************
// <copyright file= "KLocalization" company=""></copyright>
// <summary></summary>
// ***********************************************************************
namespace Game
{
    public static class KLocalization
    {
        /// <summary>
        /// ��ȡ���ش���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetLocalString(int id, string defaultText = null)
        {
            if (KLanguageManager.Instance)
            {
                return KLanguageManager.Instance.GetLocalString(id);
            }
            return defaultText;
        }

        /// <summary>
        /// ����Ĭ�ϴ���
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static string GetLocalString(string entry)
        {
            if (KLanguageManager.Instance)
            {
                return KLanguageManager.Instance.GetLocalString(entry);
            }
            return entry;
        }

        /// <summary>
        /// ����Id
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public static int GetStringId(string entry)
        {
            if (KLanguageManager.Instance)
            {
                return KLanguageManager.Instance.GetStringId(entry);
            }
            return 0;
        }

        public static bool IsDefaultLanguage()
        {
            if (KLanguageManager.Instance)
            {
                return KLanguageManager.Instance.defaultLanguage == KLanguageManager.Instance.currentLanguage;
            }
            return true;
        }

    }
}