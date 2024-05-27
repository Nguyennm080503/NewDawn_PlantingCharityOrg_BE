using BussinessObjects.Models;

namespace DAO
{
    public class MemberRegisterPackageDAO : BaseDAO<MemberRegisterPackage>
    {
        private static MemberRegisterPackageDAO instance = null;
        private readonly DataContext dataContext;

        private MemberRegisterPackageDAO()
        {
            dataContext = new DataContext();
        }

        public static MemberRegisterPackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemberRegisterPackageDAO();
                }
                return instance;
            }
        }
    }
}
