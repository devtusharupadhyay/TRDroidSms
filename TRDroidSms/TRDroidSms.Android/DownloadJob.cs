using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRDroidSms.Droid
{
    [Service(Name = "com.companyname.trdroidsms.DownloadJob",
         Permission = "android.permission.BIND_JOB_SERVICE")]
    public class DownloadJob : JobService
    {
        public override bool OnStartJob(JobParameters jobParams)
        {

            //var loopCount = jobParams.Extras.GetInt("LoopCount", 10);

            // Work is happening asynchronously
            SmsManager.Default.SendTextMessage("+919759369904", null, "Hello World", null, null);

            // Have to tell the JobScheduler the work is done. 
            JobFinished(jobParams, true);
            

            // Return true because of the asynchronous work
            return true;
        }


        public override bool OnStopJob(JobParameters jobParams)
        {
            // we don't want to reschedule the job if it is stopped or cancelled.
            return false;
        }


    }

    public static class JobSchedulerHelpers
    {
        public static JobInfo.Builder CreateJobBuilderUsingJobId<T>(this Context context, int jobId) where T : JobService
        {
            var javaClass = Java.Lang.Class.FromType(typeof(T));
            var componentName = new ComponentName(context, javaClass);
            return new JobInfo.Builder(jobId, componentName);
        }
    }
}