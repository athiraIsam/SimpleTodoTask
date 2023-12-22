using Newtonsoft.Json;
using SimpleTodo.Const;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.Controller
{
    public  class ConfigurationService
    {
        public static List<Model.Task> Task
        {
            get { return ConfigurationService.GetTaskData(); }
            set { ConfigurationService.SetTaskData(value); }
        }
        public static List<Model.Task> GetTaskData()
        {
            var app = App.Current;
            if (app.Properties.ContainsKey(ApplicationConst.TaskData))
            {
                var result = app.Properties[ApplicationConst.TaskData].ToString();
                return JsonConvert.DeserializeObject<List<Model.Task>>(result);
            }
            else { return null; }
        }

        public async static void SetTaskData(List<Model.Task> task)
        {
            var data = JsonConvert.SerializeObject(task);
            var app = App.Current;
            app.Properties[ApplicationConst.TaskData] = data;
            await app.SavePropertiesAsync();
        }
    }
}
