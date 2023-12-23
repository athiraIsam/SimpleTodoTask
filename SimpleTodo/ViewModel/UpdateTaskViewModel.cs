using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTodo.ViewModel
{
    public class UpdateTaskViewModel
    {
        public bool Validate (Model.Task task)
        {
            if(string.IsNullOrEmpty(task.Name)) { return false; }

            return true;

        }
    }
}
