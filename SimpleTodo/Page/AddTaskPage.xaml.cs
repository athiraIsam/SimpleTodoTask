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
    public partial class AddTaskPage : ContentPage
    {
        AddTaskViewModel model = new AddTaskViewModel();
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            var newTask = new Model.Task{
                Id = Guid.NewGuid(),
                Name = NameEntry.Text,
                Description = DescriptionEntry.Text,
                Time = DatePicker_.Date
            };

            var isValid = model.Validate(newTask);
            if(isValid)
            {
                if(ConfigurationService.GetTaskData() == null)
                {
                    List<Model.Task> tasks = new List<Model.Task>();
                    tasks.Add(newTask);

                    ConfigurationService.SetTaskData(tasks);
                }
                else
                {
                    var tasks = ConfigurationService.GetTaskData();
                    tasks.Add(newTask);

                    ConfigurationService.SetTaskData(tasks);
                }

                await DisplayAlert("Add Task", "Successful.", "Ok");

                MessagingCenter.Send<AddTaskPage>(this, ApplicationConst.AddTask);
                ClearUI();
            }
            else
            {
                await DisplayAlert("Error Add new task", "Please make sure all input is not empty", "Ok");
            }
        }

        private void ClearUI()
        {
            NameEntry.Text = string.Empty;
            DescriptionEntry.Text = string.Empty;
            DatePicker_.Date = DateTime.Now;
        }
    }
}