namespace Domain.Utilities.Enums
{
    public class Enums
    {
        public enum StatusEnum
        {
            FailedToSave,
            SavedSuccessfully,
            Exception,
            Success,
            Failed,
            FailedToFindTheObject,
            AlreadyExisting
        }
        public enum State
        {
            NotDeleted,
            Deleted
        }
        public enum OrgCategory
        {
            Sector = 1,
            Organization = 2,
            Employee = 3
        }
        public enum UserType
        {
            Local,
            Domain
        }
        public enum Table
        {
            User,
            Job,
            Card,
            Role,
            Org
        }

        public enum TableColumn
        {
            UserTypeId = 1,
            JobDegreeId = 2,
            CardSetting = 3,
            CategoryRoleId = 4,
            UserJobTitle = 5,
            OrgCategoryId = 6
        }
        public enum SignInMode
        {
            Standard = 0,
            Dynamic = 1,
        }
        public enum ThemMode
        {
            Standard ,
            Development,
        }
    }
}
