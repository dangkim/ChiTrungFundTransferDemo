package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("ChiTrung.Appointment.Droid.Application, ChiTrung.Appointment.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", md5be1c0a1a7d06a8bdd87db0b3f13156dc.Application.class, md5be1c0a1a7d06a8bdd87db0b3f13156dc.Application.__md_methods);
		mono.android.Runtime.register ("Caliburn.Micro.CaliburnApplication, Caliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=null", md5829c04c8adcda52a360bc26da6c6d4c8.CaliburnApplication.class, md5829c04c8adcda52a360bc26da6c6d4c8.CaliburnApplication.__md_methods);
		
	}
}
