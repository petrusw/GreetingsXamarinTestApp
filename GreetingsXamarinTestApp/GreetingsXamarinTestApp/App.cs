using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GreetingsXamarinTestApp
{
    public class App : Application
    {
        const string resultLabelText = "resultLabelTExt";

        public App()
        {

            if(Properties.ContainsKey(resultLabelText))
            {
                ResultLabelText = (string)Properties[resultLabelText];
            }

            // The root page of your application
            MainPage = new BasicCalculator();
        }
        public string ResultLabelText { get; set; }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Properties[resultLabelText] = ResultLabelText;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
