//
//  Example.swift
//  Unity-iPhone
//
//  Created by Masayuki Iwai on 7/10/16.
//
//

import Foundation
import UIKit
import AVFoundation
import MediaPlayer

class Example : NSObject {
    static func callUnityMethod(_ message: String) {
        // Call a method on a specified GameObject.
        UnitySendMessage("CallbackTarget", "OnCallFromSwift", message)
    }
    
    static func swiftMethod(_ message: String) {
        print("\(#function) is called with message: \(message)")
        
        self.callUnityMethod("Hello, Unity!")
    }
    
    //----------------------------------------------------------------------
    
    
    
    
    
    //Audio再生メソッド-------------------------------------------------------------------------
    
    static var audioPlayer: AVAudioPlayer!
    static func setBgmPath(_ message: String){
    }
    
    static func playBgm(_ message: String){
        setBgmPath(message);
        audioPlayer.numberOfLoops = -1;
        audioPlayer.play();
        //audioPlayer.isPlaying
    }
    
    static func stopBgm(){
        audioPlayer.stop();
    }
    
    
    
    //---------------------------------------------------------------
    
    // システムの再生状況を取得するインスタンス
    static var player = MPMusicPlayerController.systemMusicPlayer()
    
    static func ShowCurrentBgm(_ message: String){
        
    }
    
    static var backgroundTaskIdentifier: UIBackgroundTaskIdentifier?
    
    static var timer: Timer!
    
    //バックグラウンドに行く前にUnityから呼ぶ
    static func GotoBackGround(_ message: String){
        print("GotoBackGround")
        inBackGround = true
        movingTimer = true
        backgroundTaskIdentifier = UIApplication.shared.beginBackgroundTask(expirationHandler: {
            UIApplication.shared.endBackgroundTask(self.backgroundTaskIdentifier!)
        })
        
        DisposeTimer("");
        timer = Timer.scheduledTimer(timeInterval: 1, target: self, selector: #selector(Example.update), userInfo: nil, repeats: true)
        limit = (Int)(message)!
        print(limit)
        count = 0
    }
    
    static func DisposeTimer(_ message: String){
        //タイマー破棄
        if(timer != nil){
            if (timer?.isValid)! {
                timer?.invalidate()
            }
        }
    }
    
    static var movingTimer = false;
    static var inBackGround = false;
    //バックグラウンドから戻った時にUnityから呼ぶ
    static func ReturnBackGround(_ message: String){
        print("ReturnBackGround")
        //音楽を正常にするSwiftの処理を書く
        SetiOSBackGroundAudio();
        inBackGround = false
        count = 0
    }
    
    
    static var count = 0
    static var limit = 0
    
    //タイマーでアップデートで処理したい機能を書く
    static func update(){
        count+=1
        print(count)
        //5秒以上経過していたら、音楽を停止する
        if(count > limit && movingTimer){
            ReSetiOSBackGroundAudio();
            movingTimer = false
        }
        
    }
    
    //音楽のバックグラウンド再生を行うメソッド
    static func SetiOSBackGroundAudio(){
        print("SetiOSBackGroundAudio")
        /// バックグラウンドでも再生できるカテゴリに設定する
        let session = AVAudioSession.sharedInstance()
        do {
            try session.setCategory(AVAudioSessionCategoryPlayback)
        } catch  {
            // エラー処理
            fatalError("カテゴリ設定失敗")
        }
        
        // sessionのアクティブ化
        do {
            try session.setActive(true)
        } catch {
            // audio session有効化失敗時の処理
            // (ここではエラーとして停止している）
            fatalError("session有効化失敗")
        }
    }
    
    //音楽のバックグラウンド再生をリセットするメソッド
    static func ReSetiOSBackGroundAudio(){
        print("ReSetiOSBackGroundAudio")
        /// バックグラウンド再生不可カテゴリに設定する
        let session = AVAudioSession.sharedInstance()
        do {
            try session.setCategory(AVAudioSessionCategoryAmbient)
        } catch  {
            // エラー処理
            fatalError("カテゴリ設定失敗")
        }
        
        // sessionのアクティブ化
        do {
            try session.setActive(true)
        } catch {
            // audio session有効化失敗時の処理
            // (ここではエラーとして停止している）
            fatalError("session有効化失敗")
        }
    }
    /*
     override func applicationDidEnterBackground(_ application: UIApplication) {
     super.applicationDidEnterBackground(application)
     print("applicationDidEnterBackground!!!!!!!!!!!")
     // サブクラス側でなんかする
     }
     override func applicationWillEnterForeground(_ application: UIApplication) {
     super.applicationWillEnterForeground(application)
     print("applicationWillEnterForeground!!!!!!!!!!!")
     // サブクラス側でなんかする
     }
     */
}





