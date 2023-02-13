using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.NetworkInformation;

using System.Linq;
using System.Threading.Tasks;



namespace Экзамен.Models
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ForumContext contextForum,
            AccountDbContext accountContext,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)


        {

            if (!contextForum.Topics.Any())
            {
                var topics = new Topic[] {
                    new Topic
                    {
                              TitleTopic = "Topic 1",
                             
                    },
                    new Topic
                    {
                              TitleTopic = "Topic 2",
                    },
                     new Topic
                     {
                          TitleTopic = "Topic 3",
                     },
                
                };
                contextForum.Topics.AddRange(topics);
                contextForum.SaveChanges();
            }
       
            if (!contextForum.Posts.Any())
            {
                var posts = new Post[] {
                new Post
                {
                    //Id= 1,
                    TextPost = "post 1",
                    DateTime = new DateTime(2020, 01, 31, 19, 30, 00),
                    TopicId= 1,
                    UserName="eeee"
            },
                   new Post
                   {
                       //Id= 2,
                       TextPost = "post 2",
                       DateTime = new DateTime(2021, 04, 15, 13, 30, 00), 
                       TopicId= 2,
                       UserName="ttttttt"
                   },
                   new Post
                   {
                      // Id= 3,
                       TextPost = "post 3",
                       DateTime = new DateTime(2020, 02, 02, 12, 00, 00),
                       TopicId = 3,
                       UserName="poiuyftdrdszxcv"
                   },
                   new Post
                   {
                       //Id= 4,
                       TextPost = "post 4",
                       DateTime = new DateTime(2020, 02, 02, 15, 23, 00),
                       TopicId = 3,
                       UserName="iouy"
                   },
                   new Post
                   {

                       //Id= 5,
                       TextPost = "post 5",
                       DateTime = new DateTime(2020, 01, 31, 19, 33, 00),
                       TopicId= 1,
                       UserName="iouy"
                   },
                   new Post
                   {

                       //Id= 6,
                       TextPost = "post 6",
                       DateTime = new DateTime(2020, 01, 31, 19, 40, 00),
                      TopicId= 1,
                      UserName="hgjhgj"

                   },
                   new Post
                   {

                       //Id= 7,
                       TextPost = "post 7",
                       DateTime = new DateTime(2020, 12, 12, 01, 10, 00),
                       TopicId= 2,
                       UserName="eeee"
                   }


                };
                contextForum.Posts.AddRange(posts);
                contextForum.SaveChanges();

                

            }
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
                accountContext.SaveChanges();
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
                accountContext.SaveChanges();
            }
            string adminNik = "Boss";
            string password = "&Aa1234";
            if (await userManager.FindByNameAsync(adminNik) == null)
            {
                User admin = new User
                {
                    UserName = adminNik,
                    Lastname = adminNik,
                   
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                    accountContext.SaveChanges();
                }

            }

        }
    }

}
