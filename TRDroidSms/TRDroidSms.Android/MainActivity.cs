
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.App.Job;
using Android.Content;
using Xamarin.Essentials;

namespace TRDroidSms.Droid
{
    [Activity(Label = "TRDroidSms", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public static Intent getStartIntent(Context context)
        {
            Intent intent = new Intent(context, Android.App.Application.Context.Class);
            return intent;
        }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App());

            //PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Sms>();

            //if (status != PermissionStatus.Granted)
            //{
            //    var stat = await Permissions.RequestAsync<Permissions.Sms>();

            //    if (stat == PermissionStatus.Granted)
            //    {
            //        ScheduleJob();
            //    }

            //}
            //else
            //{
            //    ScheduleJob();
            //}

        }


        //public void ScheduleJob()
        //{
        //    //set parameters
        //    var jobParameters = new PersistableBundle();
        //    jobParameters.PutInt("LoopCount", 11);

        //    var jobBuilder = this.CreateJobBuilderUsingJobId<DownloadJob>(1);

        //    JobInfo jobInfo;
        //    if (Build.VERSION.SdkInt < BuildVersionCodes.N)
        //    {
        //        jobInfo = jobBuilder
        //       .SetExtras(jobParameters)
        //       .SetPeriodic(60 * 1000)
        //       .SetPersisted(true)
        //       .Build();
        //    }
        //    else
        //    {
        //        jobInfo = jobBuilder
        //        .SetExtras(jobParameters)
        //        .SetMinimumLatency(60 * 1000)
        //        .SetPersisted(true)
        //        .Build();
        //    }


        //    var jobScheduler = (JobScheduler)GetSystemService(JobSchedulerService);
        //    var scheduleResult = jobScheduler.Schedule(jobInfo);

        //    if (JobScheduler.ResultSuccess == scheduleResult)
        //    {


        //        //SmsManager.Default.SendTextMessage("+919759369904", null, "Hello World", null, null);

        //        Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Title", "message", "cancel");

        //    }
        //    else
        //    {

        //    }
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }

}
