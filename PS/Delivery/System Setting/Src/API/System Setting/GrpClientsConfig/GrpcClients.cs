using ControlPanel.ControlPanel.WorkSpace.Protos;

namespace System_Setting.GrpClientsConfig
{

    public static class GrpcClients
    {
        #region UserManagement
        public static void AddUserManagementGrpcClients(
            this IServiceCollection services,
            string UserManagmentUrl)
        {
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(UserManagmentUrl);
        }
        #endregion
        #region UserManagement
        public static void AddWorkspaceGrpcClients(
            this IServiceCollection services,
            string workspaceUrl)
        {
            services.AddGrpcServiceClient<WorkSpaceProtoService.WorkSpaceProtoServiceClient>(workspaceUrl);
        }
        #endregion

    }
}
