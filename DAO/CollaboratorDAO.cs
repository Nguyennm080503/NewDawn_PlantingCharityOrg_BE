using BussinessObjects.Models;

namespace DAO
{
    public class CollaboratorDAO : BaseDAO<Collaborator> 
    {
        private static CollaboratorDAO instance = null;
        private readonly DataContext dataContext;

        private CollaboratorDAO()
        {
            dataContext = new DataContext();
        }

        public static CollaboratorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CollaboratorDAO();
                }
                return instance;
            }
        }
    }
}
