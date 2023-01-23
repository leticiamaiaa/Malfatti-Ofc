using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Sistema;
using System.Data.Entity;
using malfatti.Models.Seguranca;

namespace malfatti
{
    public class IdentityDbContextAplicacao : IdentityDbContext<UsuarioAdm>
    {
        public IdentityDbContextAplicacao() : base("GORDON_STORE_BETA")
        { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(
            new IdentityDbInit());
        }
        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }

        public System.Data.Entity.DbSet<malfatti.Models.Seguranca.Papel> IdentityRoles { get; set; }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges <IdentityDbContextAplicacao>
    {

    }
}