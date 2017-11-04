//
//  MyAppController.m
//  Unity-iPhone
//
//  Created by USER on 2017/11/01.
//
//

#import <Foundation/Foundation.h>
#import <AVFoundation/AVFoundation.h>
#import "UnityAppController.h"
#import "unityswift-Swift.h"

@interface MyAppController : UnityAppController
@end

@implementation MyAppController
- (void)preStartUnity
{
    // なんか処理
}

//AVAudioSession* session = [AVAudioSession sharedInstance];
- (void)applicationWillEnterForeground:(UIApplication *)application
{
    [super applicationWillEnterForeground:application];
    NSLog(@"applicationWillEnterForeground!");
    
}

UIApplicationState state = [[UIApplication sharedApplication] applicationState];

- (void)applicationDidEnterBackground:(UIApplication *)application
{
    [super applicationDidEnterBackground:application];
    // なんか処理
    NSLog(@"applicationDidEnterBackground!");
    
    UIApplicationState state = [application applicationState];
    if (state == UIApplicationStateInactive) {
        NSLog(@"Sent to background by locking screen");
    } else if (state == UIApplicationStateBackground) {
        if (![[NSUserDefaults standardUserDefaults] boolForKey:@"kDisplayStatusLocked"]) {
            NSLog(@"Sent to background by home button/switching to other app");
            NSError* error = nil;
            AVAudioSession* session = [AVAudioSession sharedInstance];
            [session setCategory:AVAudioSessionCategorySoloAmbient error:&error];
            
        } else {
            NSLog(@"Sent to background by locking screen");
        }
        [[NSUserDefaults standardUserDefaults] setBool:NO forKey:@"kDisplayStatusLocked"];
    }
    
    
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(MyAppController)
