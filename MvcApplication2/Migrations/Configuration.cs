namespace MvcApplication2.Migrations
{
    using MvcApplication2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication2.DAL.PersonalContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplication2.DAL.PersonalContactContext context)
        {
            var contacts = new List<PersonalContactModel>
            {
            new PersonalContactModel{Id=1,UserName="asd",FirstName="Eugene",LastName="Cernan",HomePhone="123-456-7890",AddressId=1},
            new PersonalContactModel{Id=2,UserName="asd",FirstName="Harrison",LastName="Schmidt",HomePhone="321-654-0987",AddressId=1},
            new PersonalContactModel{Id=3,UserName="asd",FirstName="Scott",LastName="Carpenter",HomePhone="222-444-6868",AddressId=1},
            new PersonalContactModel{Id=4,UserName="asd",FirstName="Charlie",LastName="Duke",HomePhone="131-313-1313",AddressId=1},
            new PersonalContactModel{Id=5,UserName="asd",FirstName="Michael",LastName="Collins",HomePhone="123-785-0000",AddressId=1},
            new PersonalContactModel{Id=6,UserName="asd",FirstName="Buzz",LastName="Aldrin",HomePhone="898-456-4578",AddressId=1},
            new PersonalContactModel{Id=7,UserName="asd",FirstName="Neil",LastName="Armstrong",HomePhone="222-012-7896",AddressId=1},

            new PersonalContactModel{Id=8,UserName="email",FirstName="Tony",LastName="Bennett"},
            new PersonalContactModel{Id=9,UserName="email",FirstName="Frank",LastName="Sinatra"},
            new PersonalContactModel{Id=10,UserName="email",FirstName="Mel",LastName="Torme"},
            new PersonalContactModel{Id=11,UserName="email",FirstName="Frankie",LastName="Avalon"},
            new PersonalContactModel{Id=12,UserName="email",FirstName="Dean",LastName="Martin"},
            new PersonalContactModel{Id=13,UserName="email",FirstName="Sammy",LastName="Davis Jr."},

            new PersonalContactModel{Id=14,UserName="User",FirstName="Mr.",LastName="Email"},
            new PersonalContactModel{Id=15,UserName="User",FirstName="Ascot",LastName="Dingleberry"}
            };

            contacts.ForEach(s => context.PersonalContacts.AddOrUpdate(s));

            context.SaveChanges();

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                    "UserProfile",
                        "UserId",
                            "UserName",
                                autoCreateTables: true);

            var roles = new SimpleRoleProvider ( Roles.Provider );

            var membership = ( SimpleMembershipProvider ) Membership.Provider;

            if ( ! roles.RoleExists( "User" ) )
            {
                roles.CreateRole( "User" );
            }

            if ( membership.GetUser( "asd" , false ) == null )
            {
                membership.CreateUserAndAccount( "asd" , "qwe123" );
            }

            if ( !roles.GetRolesForUser( "asd" ).Contains( "User" ) )
            {
                roles.AddUsersToRoles( new [] { "asd" } , new [] { "User" } );
            }

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("email", false) == null)
            {
                membership.CreateUserAndAccount("email", "sha256");
            }

            if (!roles.GetRolesForUser("email").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "email" }, new[] { "Admin" });
            }
        }
    }
}
