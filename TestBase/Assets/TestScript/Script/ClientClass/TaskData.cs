namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class TaskData
    {
        private Dictionary<int, Task> dic_tasks = new Dictionary<int, Task>();
        private int newTaskAmount;
        private List<Task> tasks;

        public Task GetTaskById(int taskId)
        {
            if (this.dic_tasks.ContainsKey(taskId))
            {
                return this.dic_tasks[taskId];
            }
            return null;
        }

        public void SetTasks(List<Task> tasks)
        {
            this.tasks = tasks;
            this.dic_tasks.Clear();
            foreach (Task task in tasks)
            {
                if (!this.dic_tasks.ContainsKey(task.taskId))
                {
                    this.dic_tasks.Add(task.taskId, task);
                }
            }
        }

        public int NewTaskAmount
        {
            get
            {
                return this.newTaskAmount;
            }
            set
            {
                this.newTaskAmount = value;
            }
        }

        public List<Task> Tasks
        {
            get
            {
                return this.tasks;
            }
        }
    }
}

