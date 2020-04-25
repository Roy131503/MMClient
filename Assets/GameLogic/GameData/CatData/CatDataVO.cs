using Game.DataModel;
using Msg.ClientMessage;

namespace Game
{
    public class CatDataVO : IEventData
    {
        public CatInfo mCatInfo { get; private set; }
        public CatXDM mCatXDM { get; private set; }
        public ItemInfo mPiece { get; private set; }//��Ƭ�ϳ�
        public int mCatScore { get; private set; }//ŷ��ֵ
        public string mName { get; private set; }
        public string mNickName { get; private set; }


        public void OnInit(CatInfo info)
        {
            mCatInfo = info;
            mCatXDM = XTable.CatXTable.GetByID(mCatInfo.CatCfgId);
            if (mCatXDM.Piece != null && mCatXDM.Piece.Count > 0)
            {
                mPiece = new ItemInfo();
                mPiece.ItemCfgId = mCatXDM.Piece[0];
                mPiece.ItemNum = mCatXDM.Piece[1];
            }
            mCatScore = mCatInfo.CoinAbility + mCatInfo.ExploreAbility + mCatInfo.MatchAbility + mCatXDM.SkillScore;
            mName = mCatXDM.Name;
            mNickName = mCatInfo.Nick;
            if (mNickName == null || mNickName == "")
                mNickName = mCatXDM.Name;
        }
    }
}
