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
            var parameters = new { userId = userId, isAssigned = isAssigned };
            var tasks = _db.LoadData<TaskModel, dynamic>("select * from dbo.Tasks",
                                                          parameters,
                                                          connectionStringName,
                                                          false);

            return tasks;
        }



        public List<UserModel> GetUsersByAssignment(bool canAssign)
        {
            return _db.LoadData<UserModel, dynamic>("select * from dbo.Users",
                                                    new { canAssignTask = canAssign },
                                                    connectionStringName,
                                                    false);
        }
        public void CreateTask(string title, bool status, DateTime dateCreated, int creatorId, int assigneeId)
        {
            // Check if the creatorId exists in the Users table
            bool creatorExists = _db.LoadData<int, dynamic>("SELECT TOP 1 Id FROM dbo.Users WHERE Id = @Id", new { Id = creatorId }, connectionStringName, false).Any();

            if (!creatorExists)
            {
                throw new Exception("CreatorId does not exist in the Users table.");
            }

            // Proceed with inserting the task
            _db.SaveData("dbo.spInsert_Task",
                         new
                         {
                             title,
                             dateCreated = dateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                             createdBy = creatorId,
                             assignedTo = assigneeId
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
        public void UpdateTaskStatus(int taskId)
        {
            _db.SaveData("dbo.spUpdate_TaskStatus",
                         new
                         {
                             taskId
                         },
                         connectionStringName,
                         true);
        }

    }

}
