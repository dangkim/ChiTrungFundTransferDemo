﻿using Foundation;
using UIKit;
using MaterialControls.MaterialEntry.iOS;
using Caliburn.Micro;

namespace ChiTrung.AppointmentManager.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private readonly CaliburnAppDelegate appDelegate = new CaliburnAppDelegate();
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {            
            global::Xamarin.Forms.Forms.Init();

            // Call in your platform (non-pcl) startup            
            // 1) Link in your main activity or AppDelegate or whatever
            Websockets.Ios.WebsocketConnection.Link();

            BorderlessEntryRenderer.Init();
            LoadApplication(IoC.Get<App>());

            return base.FinishedLaunching(app, options);
        }
    }
}
