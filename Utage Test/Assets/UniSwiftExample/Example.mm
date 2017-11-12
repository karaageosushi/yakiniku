//
//  Example.mm
//  Unity-iPhone
//
//  Created by Masayuki Iwai on 7/10/16.
//
//

#import <Foundation/Foundation.h>
#import "unityswift-Swift.h"
extern "C" {
    void _ex_callSwiftMethod(const char *message) {
        // You can access Swift classes directly here.
        [Example swiftMethod:[NSString stringWithUTF8String:message]];
    }
    void _playBgm(const char *message) {
        // You can access Swift classes directly here.
        [Example playBgm:[NSString stringWithUTF8String:message]];
    }
    void _GotoBackGround(const char *message) {
        // You can access Swift classes directly here.
        [Example GotoBackGround:[NSString stringWithUTF8String:message]];
    }
    
    void _ReturnBackGround(const char *message) {
        // You can access Swift classes directly here.
        [Example ReturnBackGround:[NSString stringWithUTF8String:message]];
    }
    void _DisposeTimer(const char *message) {
        // You can access Swift classes directly here.
        [Example DisposeTimer:[NSString stringWithUTF8String:message]];
    }
    
}
