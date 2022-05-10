using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using BookStore.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Data.BookStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore.Data.BookStoreDbContext context)
        {
            CreatCategory(context);
            CreateSlide(context);
            CreateContactDetail(context);
            //  This method will be called after migrating to the latest version.


        }

        private void CreateUser(BookStoreDbContext context)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BookStoreDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BookStoreDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "son",
            //    Email = "winbaluan@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Nguyen Cong Son"
            //};

            //manager.Create(user, "123456!");
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole {Name = "Admin"});
            //    roleManager.Create(new IdentityRole {Name = "User"});

            //}
            //var adminUser = manager.FindByEmail("winbaluan@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] {"Admin", "User"});
        }
        private void CreatCategory(BookStore.Data.BookStoreDbContext context)
        {
            if (context.Categories.Count() == 0)
            {
                List<Category> listCategory = new List<Category>()
            {
                new Category()
                {
                    Name = "Văn Học",
                    Alias = "van-hoc",
                    Status = true
                }
            };
                context.Categories.AddRange(listCategory);
                context.SaveChanges();
            }
        }

        private void CreateSlide(BookStoreDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content =@"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur 
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                        <span class=""on-get"">GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                        Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>

                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >

                                <span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
        private void CreateContactDetail(BookStoreDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new BookStore.Model.Models.ContactDetail()
                    {
                        Name = "BookStore",
                        Address = "12 Ỷ Lan Nguyên Phi",
                        Email = "winbaluan@gmail.com",
                        Lat = 16.040803,
                        Lng = 105.8053274,
                        Phone = "108.2132903",
                        Website = "http://zing.vn",
                        Other = "",
                        Status = true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
    }
}
