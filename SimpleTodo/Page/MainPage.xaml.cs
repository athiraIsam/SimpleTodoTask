using SimpleTodo.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTodo.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Model.Task> tasks;

        public ObservableCollection<Model.Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        public MainPage()
        {
            InitializeComponent();
            //this.BindingContext = this;

            //Tasks = new ObservableCollection<Model.Task>();

            //Tasks.Add(new Model.Task()
            //{
            //    Name = "Task1",
            //    Description = "Description1",
            //    IsTaskCompleted = false,
            //    Time = DateTime.Now.Date
            //});
            //Tasks.Add(new Model.Task()
            //{
            //    Name = "Task1",
            //    Description = "Description1",
            //    IsTaskCompleted = true,
            //    Time = DateTime.Now.Date
            //});

            //TodoListView.ItemsSource = Tasks;
            //TodoLayout.IsVisible = true;
            InitializeUI();
        }

        private void InitializeUI()
        {
            NoListPlaceholder.IsVisible = true;
            TodoLayout.IsVisible = false;
            if(ConfigurationService.GetTaskData() != null)
            {
                NoListPlaceholder.IsVisible = false;
                TodoLayout.IsVisible = true;

                foreach(var task in ConfigurationService.GetTaskData())
                {
                    Tasks.Add(new Model.Task()
                    {
                        Name = task.Name,
                        Description = task.Description,
                        IsTaskCompleted = task.IsTaskCompleted,
                        Time = task.Time
                    });
                }
                TodoListView.ItemsSource = Tasks;
            }
        }

        private void Add_Clicked(object sender, EventArgs e)
        {

        }
    }
}