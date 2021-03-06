﻿
namespace Game.Match3
{
    /// <summary>
    /// 1001-【需手动操作，棋盘上可操作性的元素为基础元素，其余元素加一层遮罩】使指定位置的普通元素变成相应猫的颜色，且变色了的猫拥有得分暴击能力（该猫被消除时，得分*N）
    /// 1002-主动释放技能，随机向当前棋盘内发散N个相应颜色猫
    /// 1003-释放技能后，消除所有当前棋盘的相应颜色基础猫，并有一定几率返还随机炸弹（点头、摇头、13消、活力猫）
    /// 1004-引爆棋盘中所有炸弹，并返还N个直线炸弹（4004黑公主）
    /// 1005-主动向棋盘中发散N个随机颜色的礼物盒（4010魔术师）
    /// 1006-释放技能后3个回合内/5秒内进入Super Time，得分变为N倍（4009提琴家）
    /// 1007-步数增加N步/时间增加N秒（4008白公主）
    /// 1008-魔力扫把（N行）（4007女巫）
    /// 1009-【需手动操作，棋盘上可操作的元素为基本元素+特效元素】发射交叉特效，直接引爆，并返还一定能量（4002女警）
    /// 1010-【需手动操作，棋盘上可操作的元素为基本元素+特效元素】发射L型/十字特效，直接引爆，并返还一定比例的能量（4005警官）
    /// 1011-【需手动操作，棋盘上可操作的元素为基本元素+特效元素】发射活力猫，直接引爆，并返还一定比例的能量（4003国王）
    /// 1012-向棋盘发射N个震荡波（优先级为雪块>冰块>附有能量的基础元素>暴击元素>水晶球>基本元素>特效）（4001舞蹈家）
    /// 1013-向棋盘发射N个导弹，随机砸中目标（飞碟>章鱼>牢笼>雪块>冰块>云块>宝藏>毒液>棕毛球>灰毛球>猫窝>银币>能量块>礼物>附有能量的基础元素>暴击元素>水晶球>基础元素>特效）（4006僵尸猫）
    /// 1014-散发特效元素
    /// </summary>
    public enum ESkillType
    {
        /// <summary>
        /// 使指定位置的普通元素变成相应猫的颜色
        /// </summary>
        Transfiguration = 1001,//一阶猫
        /// <summary>
        /// 随机向当前棋盘内发散N个相应颜色猫
        /// </summary>
        Infect = 1002,//二阶猫
        /// <summary>
        /// 消除所有当前棋盘的相应颜色基础猫，并有一定几率返还随机炸弹
        /// </summary>
        Crash = 1003,//三阶猫
        /// <summary>
        /// 引爆棋盘中所有炸弹
        /// </summary>
        DetonateBombs = 1004,//彩1
        /// <summary>
        /// 主动向棋盘中发散N个随机颜色的礼物盒
        /// </summary>
        SendGift = 1005,//彩2
        /// <summary>
        /// 释放技能后3个回合内/5秒内进入Super Time，得分变为N倍
        /// </summary>
        SuperTime = 1006,//彩3
        /// <summary>
        /// 步数增加N步/时间增加N秒
        /// </summary>
        AddStepAndTime = 1007,//彩5
        /// <summary>
        /// 魔力扫把（N行）
        /// </summary>
        WitchMagic = 1008,//彩7
        /// <summary>
        /// 发射交叉特效，直接引爆，并返还一定能量
        /// </summary>
        Cross = 1009,//彩8
        /// <summary>
        /// 发射L型/十字特效，直接引爆
        /// </summary>
        AreaBomb = 1010,//彩9
        /// <summary>
        /// 发射活力猫，直接引爆
        /// </summary>
        MagicBomb = 1011,//彩10
        /// <summary>
        /// 向棋盘发射N个震荡波
        /// </summary>
        ShockWave = 1012,//彩4
        /// <summary>
        /// 向棋盘发射N个导弹，随机砸中目标
        /// </summary>
        Missile = 1013,//彩6
        /// <summary>
        /// 散发特效元素
        /// </summary>
        ChangeSpecial = 1014,
    }

    /// <summary>
    /// 技能作用颜色类型
    /// </summary>
    public enum ESkillColorType
    {
        None = 0,
        Green = 1,
        Blue = 2,
        Purple = 3,
        Brown = 4,
        Red = 5,
        Yellow = 6,
        Energy = 7,
        Coin = 8,
        CatColor = 90,
        Random = 99,
    }

    public enum SkillOperationType
    {
        None,
        PointTouch,
        Drag,
    }

}