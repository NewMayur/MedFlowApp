using MedFlowLibrary.Models;

namespace MedFlowLibrary.Data
{
    public interface IDatabaseData
    {
        void CreateTask(string title, bool status, DateTime dateCreated, int creatorId, int assigneeId);
        List<TaskModel> GetTasksByIdAssignment(int userId, bool isAssgined);
        List<UserModel> GetUserById(int userId);
        List<UserModel> GetUsersByAssignment(bool canAssign);
        void UpdateTaskStatus(int taskId);
    }
}