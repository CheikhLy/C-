using MySql.Data.MySqlClient;
namespace Cours.Core{
    public interface IDataAcess{
         MySqlConnection getConnection();
        void closeConnection();

    }
}