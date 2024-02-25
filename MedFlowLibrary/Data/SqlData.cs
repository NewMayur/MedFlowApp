using MedFlowLibrary.Databases;
using MedFlowLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedFlowLibrary.Data
{
    public class SqlData : IDatabaseData
    {

        private readonly ISqlDataAccess _db;
        public const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<TaskModel> GetTasksByIdAssignment(int userId, bool isAssigned)
        {
            var parameters = new { userId, isAssigned };
            var tasks = _db.LoadData<TaskModel, dynamic>("dbo.spGetTasks_ById&Assignment",
                                                          parameters,
                                                          connectionStringName,
                                                          true);

            return tasks;
        }


        public List<UserModel> GetUsersByAssignment(bool canAssign)
        {
            return _db.LoadData<UserModel, dynamic>("dbo.spGetUsers_ByAssignment",
                                                    new { canAssign },
                                                    connectionStringName,
                                                    true);
        }
        public void CreateTask(string title,
                               bool status,
                               DateTime dateCreated,
                               int creatorId,
                               int assigneeId)
        {
            UserModel creator = _db.LoadData<UserModel, dynamic>("select u.Id from dbo.Users",
                                                                 new { creatorId },
                                                                 connectionStringName,
                                                                 false).First();
            dateCreated = DateTime.Now.Date;

            _db.SaveData("dbo.spInsert_Task",
                         new
                         {
                             title,
                             status = 0,
                             dateCreated = dateCreated.ToString("yyyy-MM-dd"),
                             creator = creator.Id,
                             assigneeId
                         },
                         connectionStringName,
                         true);
        }
        public List<UserModel> GetUserById(int userId)
        {
            return _db.LoadData<UserModel, dynamic>("dbo.spGetUser_ById",
                                                    new { userId = userId },
                                                    connectionStringName,
                                                    true);
        }
    }
}
