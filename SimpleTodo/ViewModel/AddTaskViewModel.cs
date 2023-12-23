using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTodo.ViewModel
{
    public class AddTaskViewModel
    {
        public bool Validate(Model.Task task)
        {
            if(String.IsNullOrEmpty(task.Name)) return false;
 
            return true;

        }
    }
}
