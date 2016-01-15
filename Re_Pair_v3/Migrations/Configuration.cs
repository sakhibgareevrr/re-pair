namespace Re_Pair_v3.Migrations
{
    using Infrastructure;
    using Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Infrastructure.Repository;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userAddresses = new UserAddress[]
            {
                new UserAddress
                {
                    Id = 1,
                    FirstName="John",
                    LastName="Smith",
                    Phone="555-444-3156",
                    AddressLine1="1234 Broadway St",
                    AddressLine2="",
                    City="Spring",
                    State="Texas",
                    Zipcode=77386
                },
                new UserAddress
                {
                    Id = 2,
                    FirstName="Adam",
                    LastName="Berger",
                    Phone="111-666-2458",
                    AddressLine1="6545 Merak St",
                    AddressLine2="",
                    City="Conroe",
                    State="Texas",
                    Zipcode=77301
                },
                new UserAddress
                {
                    Id = 3,
                    FirstName="Nick",
                    LastName="Fersman",
                    Phone="455-678-7772",
                    AddressLine1="3156 Palm St",
                    AddressLine2="",
                    City="Katy",
                    State="Texas",
                    Zipcode=77449
                },
                new UserAddress
                {
                    Id = 4,
                    FirstName="Bob",
                    LastName="Shulz",
                    Phone="345-233-6768",
                    AddressLine1="7899 Main St",
                    AddressLine2="",
                    City="Pasadena",
                    State="Texas",
                    Zipcode=77501
                },
                new UserAddress
                {
                    Id = 5,
                    FirstName="Greg",
                    LastName="Stein",
                    Phone="655-112-3444",
                    AddressLine1="7860 Main St",
                    AddressLine2="",
                    City="Pasadena",
                    State="Texas",
                    Zipcode=77501
                },
                new UserAddress
                {
                    Id = 6,
                    FirstName="Edward",
                    LastName="Brigg",
                    Phone="112-322-6644",
                    AddressLine1="3345 Mapple St",
                    AddressLine2="",
                    City="Katy",
                    State="Texas",
                    Zipcode=77449
                },
                new UserAddress
                {
                    Id = 7,
                    FirstName="Mark",
                    LastName="Carpenter",
                    Phone="789-456-1233",
                    AddressLine1="4455 Pine St",
                    AddressLine2="",
                    City="Spring",
                    State="Texas",
                    Zipcode=77386
                },
                new UserAddress
                {
                    Id = 8,
                    FirstName="Rick",
                    LastName="White",
                    Phone="333-124-3566",
                    AddressLine1="3311 Hollow St",
                    AddressLine2="",
                    City="Conroe",
                    State="Texas",
                    Zipcode=77501
                }
            };

            var orders = new Order[]
            {
                new Order
                {
                    Id=1,
                    ServiceName="Electricity",
                    OrderDate=new DateTime(2015,11,26,10,30,0),
                    CompletionDate=new DateTime(2015,11,28,12,30,0),
                    Price = 84.53m,
                    ServiceQuality=4,
                    IsApproved=false,
                    IsCompleted=false
                },
                new Order
                {
                    Id=2,
                    ServiceName="Plumbing",
                    OrderDate=new DateTime(2015,10,26,09,17,54),
                    CompletionDate=new DateTime(2015,10,26,17,10,44),
                    Price = 112.31m,
                    ServiceQuality=5,
                    IsApproved=false,
                    IsCompleted=false

                },
                new Order
                {
                    Id=3,
                    ServiceName="Pool",
                    OrderDate=new DateTime(2015,12,04,09,11,32),
                    CompletionDate=new DateTime(2015,12,05,16,22,37),
                    Price = 874.22m,
                    ServiceQuality=4,
                    IsApproved=false,
                    IsCompleted=false

                },
                new Order
                {
                    Id=4,
                    ServiceName="Roof",
                    OrderDate=new DateTime(2015,11,09,09,07,32),
                    CompletionDate=new DateTime(2015,12,04,17,55,21),
                    Price = 1245.14m,
                    ServiceQuality=3,
                    IsApproved=false,
                    IsCompleted=false

                },
                new Order
                {
                    Id=5,
                    ServiceName="Replace Electric Wire",
                    OrderDate=new DateTime(2015,12,09,08,12,46),
                    CompletionDate=new DateTime(2015,12,12,17,33,07),
                    Price = 68.47m,
                    ServiceQuality=4,
                    IsApproved=false,
                    IsCompleted=false
                }
            };

            context.UserAddresses.AddOrUpdate(a => a.Id, userAddresses);

            context.Orders.AddOrUpdate(o => o.Id, orders);

            CustomerRepository customerRepo = new CustomerRepository(context);

            var john = customerRepo.FindByCustomerEmail("john.smith@gmail.com");

            if (john==null)
            {
                john = new CustomerUser()
                {
                    UserName = "john",
                    Email = "john.smith@gmail.com"
                };
                customerRepo.Add(john, "Password!1");
            }

            var adam = customerRepo.FindByCustomerEmail("adam.berger@gmail.com");

            if (adam == null)
            {
                adam = new CustomerUser()
                {
                    UserName = "adam",
                    Email = "adam.berger@gmail.com"
                };
                customerRepo.Add(adam, "Password!2");
            }

            var fersman = customerRepo.FindByCustomerEmail("john.fersman@gmail.com");

            if (fersman == null)
            {
                fersman = new CustomerUser()
                {
                    UserName = "fersman",
                    Email = "john.fersman@gmail.com"
                };
                customerRepo.Add(fersman, "Password!3");
            }

            var bob = customerRepo.FindByCustomerEmail("bob.shulz@gmail.com");

            if (bob == null)
            {
                bob = new CustomerUser()
                {
                    UserName = "bob",
                    Email = "bob.shulz@gmail.com"
                };
                customerRepo.Add(bob, "Password!4");
            }

            BusinessRepository businessRepo = new BusinessRepository(context);

            var greg = businessRepo.FindByBusinessEmail("greg.stein@gmail.com");

            if (greg==null)
            {
                greg = new BusinessUser()
                {
                    UserName = "greg",
                    Email = "greg.stein@gmail.com",
                    CompanyName="Stein Plumbing",
                    ServiceCategory = "Plumbing",
                    Description = "Residential and business plumbing"
                };
                businessRepo.Add(greg, "Password!11");
            }

            var edward = businessRepo.FindByBusinessEmail("edward.brigg@gmail.com");

            if (edward == null)
            {
                edward = new BusinessUser()
                {
                    UserName = "edward",
                    Email = "edward.brigg@gmail.com",
                    CompanyName = "Brigg Electricity",
                    ServiceCategory = "Electricity",
                    Description = "All kinds of electric repairs"
                };
                businessRepo.Add(edward, "Password!12");
            }

            var mark = businessRepo.FindByBusinessEmail("mark.carpenter@gmail.com");

            if (mark == null)
            {
                mark = new BusinessUser()
                {
                    UserName = "mark",
                    Email = "mark.carpenter@gmail.com",
                    CompanyName = "Blue Pools",
                    ServiceCategory = "Pool",
                    Description = "New pools and repair, rennovation"

                };
                businessRepo.Add(mark, "Password!13");
            }

            var rick = businessRepo.FindByBusinessEmail("rick.white@gmail.com");

            if (rick == null)
            {
                rick = new BusinessUser()
                {
                    UserName = "rick",
                    Email = "rick.white@gmail.com",
                    CompanyName = "White Roofing",
                    ServiceCategory = "Roof",
                    Description = "Roof rennovation and repairs"
                };
                businessRepo.Add(rick, "Password!14");
            }

            UserAddressRepository addressRepo = new UserAddressRepository(context);
            var address1 = addressRepo.FindById(1, null);
            var address2 = addressRepo.FindById(2,null);
            var address3 = addressRepo.FindById(3,null);
            var address4 = addressRepo.FindById(4,null);
            var address11 = addressRepo.FindById(5,null);
            var address12 = addressRepo.FindById(6,null);
            var address13 = addressRepo.FindById(7,null);
            var address14 = addressRepo.FindById(8,null);

            address1.User = john;
            address2.User = adam;
            address3.User = fersman;
            address4.User = bob;
            address11.User = greg;
            address12.User = edward;
            address13.User = mark;
            address14.User = rick;

            OrderRepository orderRepo = new OrderRepository(context);

            var order1 = orderRepo.FindById(1, null);
            var order2 = orderRepo.FindById(2, null);
            var order3 = orderRepo.FindById(3, null);
            var order4 = orderRepo.FindById(4, null);
            var order5 = orderRepo.FindById(5, null);
            

            order1.Business = edward;
            order1.Customer = fersman;
            order2.Business = greg;
            order2.Customer = bob;
            order3.Business = mark;
            order3.Customer = adam;
            order4.Business = rick;
            order4.Customer = john;
            order5.Business = edward;
            order5.Customer = john;

            context.SaveChanges();

        }
    }
}
