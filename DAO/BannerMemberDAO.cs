using BussinessObjects.Models;

namespace DAO
{
    public class BannerMemberDAO : BaseDAO<BannerMember>
    {
        private static BannerMemberDAO instance = null;
        private readonly DataContext dataContext;

        private BannerMemberDAO()
        {
            dataContext = new DataContext();
        }

        public static BannerMemberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BannerMemberDAO();
                }
                return instance;
            }
        }
    }
}
