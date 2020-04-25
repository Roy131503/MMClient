using Game;
using Game.DataModel;
using Game.Match3;
using Msg.ClientMessage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskType
{
    public const int AllTaskData = 0;//������������
    public const int Everyday = 1;//ÿ������
    public const int Achievement = 2;//�ɾ�����
}

public class TaskDataModel : DataModelBase<TaskDataModel>
{
    public Dictionary<int, TaskDataVO> mDictAllTaskData { get; private set; } = new Dictionary<int, TaskDataVO>();
    public int mRewardId { get; private set; } = 0;
    
    //��������
    public void ExeTaskData(S2CTaskDataResponse value)
    {
        TaskDataVO vo = new TaskDataVO();
        vo.OnTaskData(value);
        if (mDictAllTaskData.ContainsKey(value.TaskType))
            mDictAllTaskData[value.TaskType] = vo;
        else
            mDictAllTaskData.Add(value.TaskType, vo);
        DispatchEvent(TaskEvent.TaskData);
    }
    //������
    public void ExeTaskReward(S2CTaskRewardResponse value)
    {
        mDictAllTaskData[XTable.MissionXTable.GetByID(value.TaskId).Type].deleteTask(value.TaskId);
        mRewardId = value.TaskId;
        DispatchEvent(TaskEvent.TaskReward);
    }
    //�������ݱ仯֪ͨ
    public void ExeTaskNotify(S2CTaskValueNotify value)
    {
        if (mDictAllTaskData.ContainsKey(XTable.MissionXTable.GetByID(value.Data.Id).Type))
            mDictAllTaskData[XTable.MissionXTable.GetByID(value.Data.Id).Type].TaskDataRefresh(value.Data);
        DispatchEvent(TaskEvent.TaskNotify);
    }
}
