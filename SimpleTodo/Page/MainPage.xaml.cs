using SimpleTodo.Const;
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

            MessagingCenter.Subscribe<AddTaskPage>(this, ApplicationConst.AddTask, (sender) =>
            {
                UpdateUI();
            });
            MessagingCenter.Subscribe<UpdateTaskPage>(this, ApplicationConst.UpdateTask, (sender) =>
            {
                UpdateUI();
            });
            MessagingCenter.Subscribe<UpdateTaskPage>(this, ApplicationConst.DeleteTask, (sender) =>
            {
                UpdateUI();
            });
            InitializeUI();
        }

        private void UpdateUI()
        {
            Tasks = new ObservableCollection<Model.Task>();
            NoListPlaceholder.IsVisible = true;
            TodoLayout.IsVisible = false;
            if (ConfigurationService.GetTaskData() != null && ConfigurationService.Task.Count()!=0)
            {
                NoListPlaceholder.IsVisible = false;
                TodoLayout.IsVisible = true;

                foreach (var task in ConfigurationService.GetTaskData())
                {
                    Tasks.Add(new Model.Task()
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Time = task.Time
                    });
                }
                TodoListView.ItemsSource = Tasks;
            }
        }

        private void InitializeUI()
        {
            Tasks = new ObservableCollection<Model.Task>();
            NoListPlaceholder.IsVisible = true;
            TodoLayout.IsVisible = false;
            if (ConfigurationService.GetTaskData() != null && ConfigurationService.Task.Count() != 0)
            {
                NoListPlaceholder.IsVisible = false;
                TodoLayout.IsVisible = true;

                foreach(var task in ConfigurationService.GetTaskData())
                {
                    Tasks.Add(new Model.Task()
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Time = task.Time
                    });
                }
                TodoListView.ItemsSource = Tasks;
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage());
        }

        private async void TodoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Model.Task;
            await Navigation.PushAsync(new UpdateTaskPage(item));
            TodoListView.SelectedItem = null;
        }
    }
}