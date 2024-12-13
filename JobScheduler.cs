using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using RabbittAPI.App_Data;
using RabbittAPI.Models;
using RabbittAPI.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;


namespace RabbittAPI
{
    public class JobScheduler

    {
        public static void Start()
        {
            
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<JobReminder>().Build();
            IJobDetail job2 = JobBuilder.Create<JobReminder2>().Build();
            IJobDetail job3 = JobBuilder.Create < Weeklytimesheet>().Build();
            IJobDetail job4 = JobBuilder.Create<leave24>().Build();
            IJobDetail job5 = JobBuilder.Create<PendingTimesheet>().Build();



            ITrigger trigger = TriggerBuilder.Create()

                .WithIdentity("JobReminder", "IJob")

                 .WithCronSchedule("0 00 07 ? * MON-FRI")
                 //.WithCronSchedule("0 0/5 * 1/1 * ? *")
                 .UsingJobData("batch-size", "5")

               .StartAt(DateTime.UtcNow)

               .WithPriority(1)

               .Build();
            scheduler.ScheduleJob(job, trigger);
            
            ITrigger trigger2 = TriggerBuilder.Create()

               .WithIdentity("JobReminder2", "IJob")


                 .WithCronSchedule("0 00 16 ? * MON-FRI")
                  //.WithCronSchedule("0 39 13 ? * MON-FRI")
                  .UsingJobData("batch-size", "5")

              //0 15 10 ? *MON - FRI

              .StartAt(DateTime.UtcNow)

              .WithPriority(2)

              .Build();
            scheduler.ScheduleJob(job2, trigger2);





            ITrigger trigger3 = TriggerBuilder.Create()

               .WithIdentity("Weeklytimesheet", "IJob")


                 .WithCronSchedule("0 27 14 ? * FRI")
                  //.WithCronSchedule("0 39 13 ? * MON-FRI")
                  .UsingJobData("batch-size", "5")

              //0 15 10 ? *MON - FRI

              .StartAt(DateTime.UtcNow)

              .WithPriority(2)

              .Build();
            scheduler.ScheduleJob(job3, trigger3);


            ITrigger trigger4 = TriggerBuilder.Create()

              .WithIdentity("leave24", "IJob")


                .WithCronSchedule("0 23 14 ? * FRI")
                 //.WithCronSchedule("0 39 13 ? * MON-FRI")
                 .UsingJobData("batch-size", "5")

             //0 15 10 ? *MON - FRI

             .StartAt(DateTime.UtcNow)

             .WithPriority(2)

             .Build();
            scheduler.ScheduleJob(job4, trigger4);


            ITrigger trigger5 = TriggerBuilder.Create()

             .WithIdentity("PendingTimesheet", "IJob")


               .WithCronSchedule("0 23 14 ? * MON")
                //.WithCronSchedule("0 39 13 ? * MON-FRI")
                .UsingJobData("batch-size", "5")

            //0 15 10 ? *MON - FRI

            .StartAt(DateTime.UtcNow)

            .WithPriority(2)

            .Build();
            scheduler.ScheduleJob(job5, trigger5);

            ITrigger trigger6= TriggerBuilder.Create()

            .WithIdentity("PendingTimesheet", "IJob")


              .WithCronSchedule("0 23 14 ? * MON")
               //.WithCronSchedule("0 39 13 ? * MON-FRI")
               .UsingJobData("batch-size", "5")

           //0 15 10 ? *MON - FRI

           .StartAt(DateTime.UtcNow)

           .WithPriority(2)

           .Build();
            scheduler.ScheduleJob(job5, trigger6);
            //testing


            //IScheduler scheduler2 = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            ////IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler2.Start();

            //IJobDetail job2 = JobBuilder.Create<JobReminder>().Build();

            //ITrigger trigger2 = TriggerBuilder.Create()

            //    .WithIdentity("JobReminder", "IJob")

            //    .WithCronSchedule("0 30 17 ? * *")

            //   .StartAt(DateTime.UtcNow)

            //   .WithPriority(1)

            //   .Build();


            //scheduler2.ScheduleJob(job2, trigger2);



        }

    }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //services.AddControllersWithViews();
        //    services.AddHostedService<QuartzHostedService>();
        //    services.AddSingleton<IJobFactory, SingletonJobFactory>();
        //    services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

        //    services.AddSingleton<JobReminder>();
        //    //services.AddSingleton(new MyJob(type: typeof(JobReminder), expression: "0/30 0/1 * 1/1 * ? *"));
        //    //services.AddSingleton(new MyJob(type: typeof(JobReminder), expression: "0 50 15 ? * *"));
        //}
    
}
    

    