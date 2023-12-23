using SimpleTodo.Const;
using SimpleTodo.Controller;
using SimpleTodo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTodo.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateTaskPage : ContentPage
	{
		Model.Task task= null;
        UpdateTaskViewModel model = new UpdateTaskViewModel();
		public UpdateTaskPage (Model.Task task)
		{
			InitializeComponent ();
			this.task = task;
            InitializeUI();
		}

        private void InitializeUI()
        {
			Title = task.Name;
			NameEntry.Text = task.Name;
			DescriptionEntry.Text = task.Description;
			DatePicker_.Date = task.Time;
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            task.Name = NameEntry.Text;
            task.Description = DescriptionEntry.Text;
            task.Time = DatePicker_.Date;

            var isValid = model.Validate(task);
            if (isValid)
            {
                var tasks = ConfigurationService.GetTaskData();
               foreach(var _task in tasks)
                {
                    if(_task.Id == task.Id)
                    {
                        _task.Name = task.Name;
                        _task.Description = task.Description;
                        _task.Time = task.Time;

                        break;
                    }
                }
                
                ConfigurationService.SetTaskData(tasks);

                await DisplayAlert("Update Task", "Successful.", "Ok");

                MessagingCenter.Send<UpdateTaskPage>(this, ApplicationConst.UpdateTask);
            }
            else
            {
                await DisplayAlert("Error Update new task", "Please make sure all input is not empty", "Ok");
            }
        }
    }
}