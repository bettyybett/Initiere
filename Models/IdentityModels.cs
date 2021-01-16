using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;


namespace Initiere.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new Initbd());
        }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Antrenori> Antrenori { get; set; }
        public DbSet<Programari> Programari { get; set; }
        public DbSet<Cont> Cont { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        } 
    }
        public class Initbd : DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext ctx)
            {
            Antrenori antrenor_principal = new Antrenori { IdAntrenori = 1, Nume = "Rusu Eduard" ,
                Clnt = new List<Client> { 
                    new Client { IdClient = 3, Nume = "Vasile Ion" } , 
                    new Client { IdClient = 4, Nume = "Gheorghe Rodica"} 
                }
            };
            Antrenori antrenor_secundar1 = new Antrenori { IdAntrenori = 2, Nume = "Olteanu Alina" };
            Cont cont1 = new Cont
            {
                IdCont = 1,
                UserName = "bettyybett87@yahoo.com",
                Password = "Bettyesuper",
                };
                Client client1 = new Client { IdClient = 1, Nume = "Betty Bet"};
            // ctx.Clienti.Add(new Client { IdClient = 1, Nume = "Vasile Ion", AreCont = false });
                ctx.Cont.Add( cont1);
                ctx.Clienti.Add(client1);
                ctx.Clienti.Add(new Client { IdClient = 2, Nume = "Popescu Maria" });
                ctx.Antrenori.Add(antrenor_principal);
                ctx.Antrenori.Add(antrenor_secundar1);
                ctx.Programari.Add(new Programari { IdProgramari = 1, Zi = 16, Luna = 2, An = 2021,Antrenori = antrenor_principal, Client = client1 });
                ctx.Programari.Add(new Programari { IdProgramari = 2, Zi = 12, Luna = 2, An = 2021,Antrenori = antrenor_principal, Client = client1 });
                ctx.SaveChanges();
                base.Seed(ctx);
            
        }
    }
}