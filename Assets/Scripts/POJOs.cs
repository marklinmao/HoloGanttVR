using System;
using System.Collections.Generic;


namespace HoloGanttVR
{

    /// <summary>
    /// POJO of a person (team member)
    /// </summary>
    public class Member
    {
        private string id;
        private string name;

        public Member(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }
    }

    /// <summary>
    /// POJO of task
    /// </summary>
    public class Task
    {
        private string id;
        private string name;
        private Member owner;
        private DateTime startDateTime;
        private DateTime endDateTime;

        public Task(string id, string name, Member owner, DateTime startDateTime, DateTime endDateTime)
        {
            this.id = id;
            this.name = name;
            this.owner = owner;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
        }

        public DateTime GetStartDateTime()
        {
            return this.startDateTime;
        }

        public void SetStartDateTime(DateTime newDateTime)
        {
            this.startDateTime = newDateTime;
        }

        public DateTime GetEndDateTime()
        {
            return this.endDateTime;
        }

        public void SetEndDateTime(DateTime newDateTime)
        {
            this.endDateTime = newDateTime;
        }

        public string GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public Member GetOwner()
        {
            return this.owner;
        }
    }

    /// <summary>
    /// POJO of task group
    /// </summary>
    public class TaskGroup
    {
        private string id;
        private string name;
        private Dictionary<string, Task> tasks = new Dictionary<string, Task>();

        private DateTime startDateTime;
        private DateTime endDateTime;
        private int duration;

        public TaskGroup(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string GetId()
        {
            return this.id;
        }

        public void AddTask(Task newTask)
        {
            if(newTask != null)
            {
                if(this.tasks.ContainsKey(newTask.GetId()))
                {
                    throw new ArgumentException("Duplicated task ID!");
                }
                this.tasks.Add(newTask.GetId(), newTask);

                //update start/end datetime and duration
                UpdateDurationInfo();
            }
        }

        public void RemoveTask(string taskId)
        {
            if(taskId != null && this.tasks.ContainsKey(taskId))
            {
                this.tasks.Remove(taskId);

                //update start/end datetime and duration
                UpdateDurationInfo();
            }
        }

        private void UpdateDurationInfo()
        {
            if (this.tasks.Count > 0)
            {
                List<string> keyList = new List<string>(this.tasks.Keys);

                DateTime currentMin = this.tasks[keyList[0]].GetStartDateTime();
                DateTime currentMax = this.tasks[keyList[0]].GetEndDateTime();

                for (int i = 0; i < keyList.Count; i++)
                {
                    int compareMinResult = DateTime.Compare(currentMin, this.tasks[keyList[i]].GetStartDateTime());
                    if (compareMinResult > 0)
                        currentMax = this.tasks[keyList[i]].GetStartDateTime();

                    int compareMaxResult = DateTime.Compare(currentMax, this.tasks[keyList[i]].GetEndDateTime());
                    if (compareMinResult < 0)
                        currentMax = this.tasks[keyList[i]].GetEndDateTime();
                }

                this.startDateTime = currentMin;
                this.endDateTime = currentMax;
                this.duration = Utils.GetWorkingDays(currentMin, currentMax);
            }
        }

        public DateTime GetStartDateTime()
        {
            return this.startDateTime;
        }

        public DateTime GetEndDateTime()
        {
            return this.endDateTime;
        }

        public int GetDuration()
        {
            return this.duration;
        }
    }

    /// <summary>
    /// POJO of a project
    /// </summary>
    public class Project
    {
        private string id;
        private string name;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private int duration;

        private Dictionary<string, TaskGroup> taskGroups = new Dictionary<string, TaskGroup>();
        private Dictionary<string, Member> members = new Dictionary<string, Member>();

        public Project(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public Dictionary<string, TaskGroup> GetTaskGroups()
        {
            return this.taskGroups;
        }

        public void AddTaskGroup(TaskGroup taskGroup)
        {
            if(taskGroup != null)
            {
                if (this.taskGroups.ContainsKey(taskGroup.GetId()))
                {
                    throw new ArgumentException("Duplicated task group ID!");
                }
                this.taskGroups.Add(taskGroup.GetId(), taskGroup);

                //update start/end datetime and duration
                UpdateDurationInfo();
            }
        }

        public void RemoveTaskGroup(string taskGroupId)
        {
            if(taskGroupId != null && this.taskGroups.ContainsKey(taskGroupId))
            {
                this.taskGroups.Remove(taskGroupId);

                //update start/end datetime and duration
                UpdateDurationInfo();
            }
        }

        public Dictionary<string, Member> GetMembers()
        {
            return this.members;
        }

        public void AddMember(Member newMember)
        {
            this.members.Add(newMember.GetId(), newMember);
        }

        public void RemoveMember(string memberId)
        {
            if(memberId != null && this.members.ContainsKey(memberId))
                this.members.Remove(memberId);
        }        

        private void UpdateDurationInfo()
        {
            if(this.taskGroups.Count > 0)
            {
                List<string> keyList = new List<string>(this.taskGroups.Keys);

                DateTime currentMin = this.taskGroups[keyList[0]].GetStartDateTime();
                DateTime currentMax = this.taskGroups[keyList[0]].GetEndDateTime();

                for (int i = 0; i < keyList.Count; i++)
                {
                    int compareMinResult = DateTime.Compare(currentMin, this.taskGroups[keyList[i]].GetStartDateTime());
                    if (compareMinResult > 0)
                        currentMax = this.taskGroups[keyList[i]].GetStartDateTime();

                    int compareMaxResult = DateTime.Compare(currentMax, this.taskGroups[keyList[i]].GetEndDateTime());
                    if (compareMinResult < 0)
                        currentMax = this.taskGroups[keyList[i]].GetEndDateTime();
                }

                this.startDateTime = currentMin;
                this.endDateTime = currentMax;
                this.duration = Utils.GetWorkingDays(currentMin, currentMax);
            }
        }

        public DateTime GetStartDateTime()
        {
            return this.startDateTime;
        }

        public DateTime GetEndDateTime()
        {
            return this.endDateTime;
        }

        public int GetDuration()
        {
            return this.duration;
        }
    }


}

