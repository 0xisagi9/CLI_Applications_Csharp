
using System.Data;

namespace Clinic_Management_System.Core.Interfaces;

internal interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
