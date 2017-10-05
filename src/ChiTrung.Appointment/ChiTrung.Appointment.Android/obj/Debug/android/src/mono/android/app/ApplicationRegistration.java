package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("ChiTrung.AppointmentManager.Droid.Application, ChiTrung.Appointment.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", md598f0e454452c3a154e6b6feb5c79beb8.Application.class, md598f0e454452c3a154e6b6feb5c79beb8.Application.__md_methods);
		mono.android.Runtime.register ("Caliburn.Micro.CaliburnApplication, Caliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=null", md5829c04c8adcda52a360bc26da6c6d4c8.CaliburnApplication.class, md5829c04c8adcda52a360bc26da6c6d4c8.CaliburnApplication.__md_methods);
		
	}
}
