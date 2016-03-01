using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateMVC.Models
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Employee.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}