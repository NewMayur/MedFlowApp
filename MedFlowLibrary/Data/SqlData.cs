using MedFlowLibrary.Databases;
using MedFlowLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedFlowLibrary.Data
{
    public class SqlData
    {

        private readonly ISqlDataAccess _db;
        public const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<TaskModel> GetCreatedTasks(int UserId)
        {
            return _db.LoadData<TaskModel, dynamic>("dbo.spGet_CreatedTasks",
                                             new { UserId },
                                             connectionStringName,
                                             true);
        }
        
        public void GetAssignedTasks(int UserId)
        {

        }
    }
}
