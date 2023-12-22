using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTodo.Model
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsTaskCompleted { get; set; }
    }
}
