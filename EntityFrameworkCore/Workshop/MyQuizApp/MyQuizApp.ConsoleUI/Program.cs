using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyQuizApp.Data;
using MyQuizApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MyQuizApp.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            dbContext.Database.Migrate();

            var answerService = serviceProvider.GetService<IAnswerService>();
            var questionService = serviceProvider.GetService<IQuestionService>();
            var quizService = serviceProvider.GetService<IQuizService>();
   

            var json = File.ReadAllText("EF-Core-Quiz.json");
            var questions = JsonConvert.DeserializeObject<IEnumerable<JsonObjectImport>>(json);

            var quizId = quizService.Add("EF Core Test");

            foreach (var q in questions)
            {
                var questionId = questionService.Add(q.Question, quizId);

                foreach (var answer in q.Answers)
                {
                    answerService.Add(answer.Answer, questionId, answer.Correct ? 1 : 0, answer.Correct);
                }
            }


            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //answerService.Add("70 PROCENTA", 1, 3, true);
            //userAnswerService.AddUserAnswer("a5b87fe1-4860-4a27-b536-3499a9be93f0",1,3);

            //var result = userAnswerService.GetUserResult("a5b87fe1-4860-4a27-b536-3499a9be93f0", 1);
            //Console.WriteLine(result);

        }


        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options
                => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
        }
    }
}
