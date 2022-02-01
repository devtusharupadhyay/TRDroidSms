using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Android.Content;
using Xamarin.Forms;
using TRDroidSms.Droid;

[assembly: Dependency(typeof(StartSmsService))]

namespace TRDroidSms.Droid
{
    public class StartSmsService : IStartSmsService
    {
        public async void ChangeNumberAndStartService(string number)
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Sms>();

            if (status != PermissionStatus.Granted)
            {
                var stat = await Permissions.RequestAsync<Permissions.Sms>();

                if (stat == PermissionStatus.Granted)
                {
                    ScheduleJob(number);
                }
            }
            else
            {
                ScheduleJob(number);
            }
        }

        public void ScheduleJob(string number)
        {
            //set parameters
            var jobParameters = new PersistableBundle();
            jobParameters.PutString("MobileNumber", number);

            var jobBuilder = Android.App.Application.Context.CreateJobBuilderUsingJobId<DownloadJob>(1);

            JobInfo jobInfo;
            if (Build.VERSION.SdkInt < BuildVersionCodes.N)
            {
                jobInfo = jobBuilder
               .SetExtras(jobParameters)
               .SetPeriodic(60 * 1000)
               .SetPersisted(true)
               .Build();
            }
            else
            {
                jobInfo = jobBuilder
                .SetExtras(jobParameters)
                .SetMinimumLatency(60 * 1000)
                .SetPersisted(true)
                .Build();
            }


            var jobScheduler = (JobScheduler)Android.App.Application.Context.GetSystemService(Context.JobSchedulerService);
            var scheduleResult = jobScheduler.Schedule(jobInfo);

            if (JobScheduler.ResultSuccess == scheduleResult)
            {


                //SmsManager.Default.SendTextMessage("+919759369904", null, "Hello World", null, null);

                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Success", "Service Started", "Ok");

            }
            else
            {

            }
        }
    }
}