using System.Runtime.InteropServices;

public class CallSwiftBridge {
    #if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void _ex_callSwiftMethod(string message);
	[DllImport("__Internal")]
	private static extern void _ReSetiOSBackGroundAudio();
	[DllImport("__Internal")]
	private static extern void _SetiOSBackGroundAudio();
    #endif

    // Use this method to call Example.swiftMethod() in Example.swift
    // from other C# classes.
    public static void CallSwiftMethod(string message) {
        #if UNITY_IOS && !UNITY_EDITOR
        _ex_callSwiftMethod(message);
        #endif
    }

	// Use this method to call Example.swiftMethod() in Example.swift
	// from other C# classes.
	public static void ReSetiOSBackGroundAudio() {
		#if UNITY_IOS && !UNITY_EDITOR
		_ReSetiOSBackGroundAudio();
		#endif
	}
	// Use this method to call Example.swiftMethod() in Example.swift
	// from other C# classes.
	public static void SetiOSBackGroundAudio() {
		#if UNITY_IOS && !UNITY_EDITOR
		_SetiOSBackGroundAudio();
		#endif
	}
}
