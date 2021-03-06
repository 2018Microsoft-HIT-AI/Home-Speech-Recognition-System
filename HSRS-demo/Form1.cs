﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
//using System.Runtime.WindowsRuntime;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json;

using System.Speech.Synthesis;

namespace HSRS_demo
{
    public partial class SmartHomeForm : Form
    {
        public SmartHomeForm()
        {
            InitializeComponent();
            Button.Text = "开始";
            Heater.Image = Resource.HeaterOff;
            Aircondition.Image = Resource.AirconditionOff;
            Waveoven.Image = Resource.WaveovenOff;
            Light.Image = Resource.LightOff;
        }

        // 语音识别器
        SpeechRecognizer recognizer;
        bool isRecording = false;

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                // 第一步
                // 初始化语音服务SDK并启动识别器，进行语音转文本
                
                SpeechFactory speechFactory = SpeechFactory.FromSubscription("5ee7ba6869f44321a40751967accf7a9", "westus");

                // 识别中文
                recognizer = speechFactory.CreateSpeechRecognizer("zh-CN");

                // 识别过程中的中间结果
                recognizer.IntermediateResultReceived += Recognizer_IntermediateResultReceived;
                // 识别的最终结果
                recognizer.FinalResultReceived += Recognizer_FinalResultReceived;
                // 出错时的处理
                recognizer.RecognitionErrorRaised += Recognizer_RecognitionErrorRaised;
            }
            catch (Exception ex)
            {
                if (ex is System.TypeInitializationException)
                {
                    Log("语音SDK不支持Any CPU, 请更改为x64");
                }
                else
                {
                    Log("初始化出错，请确认麦克风工作正常");
                    Log("已降级到文本语言理解模式");

                    TextBox Inputbox = new TextBox
                    {
                        Text = "",
                        Size = new Size(300, 26),
                        Location = new Point(10, 10)
                    };
                    Inputbox.KeyDown += InputBox_KeyDown;
                    Controls.Add(Inputbox);

                    Button.Visible = false;
                }
            }
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            Button.Enabled = false;

            isRecording = !isRecording;
            if (isRecording)
            {
                // 启动识别器
                await recognizer.StartContinuousRecognitionAsync();
                Button.Text = "Stop";
            }
            else
            {
                // 停止识别器
                await recognizer.StopContinuousRecognitionAsync();
                Button.Text = "Start";
            }

            Button.Enabled = true;
        }

        // 识别过程中的中间结果
        private void Recognizer_IntermediateResultReceived(object sender, SpeechRecognitionResultEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Result.Text))
            {
                Log("中间结果: " + e.Result.Text);
            }
        }

        // 识别的最终结果
        private void Recognizer_FinalResultReceived(object sender, SpeechRecognitionResultEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Result.Text))
            {
                Log("最终结果: " + e.Result.Text);
                ProcessTransResult(e.Result.Text);
            }
        }

        // 出错时的处理
        private void Recognizer_RecognitionErrorRaised(object sender, RecognitionErrorEventArgs e)
        {
            Log("错误: " + e.FailureReason);
        }

        private async void ProcessTransResult(string text)
        {
            // 第二步
            // 调用语言理解服务取得用户意图
            string intent = await GetLuisResult(text);

            // 第三步
            // 按照意图控制灯
            Log(intent+"\n\n\n");
            string textToSpeak = "";
            SpeechSynthesizer synthes1 = new SpeechSynthesizer();
            switch (intent)
            {
                
                case "HeaterOn":
                    Heater.Image = Resource.HeaterOn;
                    //await recognizer.StopContinuousRecognitionAsync();   
                    //recognizer.StopContinuousRecognitionAsync();
                    textToSpeak = "The kettle has been turned on.";
                    synthes1.Speak(textToSpeak);//同步
                    //await synthes1.SpeakAsync(textToSpeak);//异步
                    //await recognizer.StartContinuousRecognitionAsync();
                    //recognizer.StartContinuousRecognitionAsync();

                    //
                    break;
                case "HeaterOff":
                    Heater.Image = Resource.HeaterOff;
                    //await recognizer.StopContinuousRecognitionAsync();
                    //Button.Text = "Start";
                    textToSpeak = "The kettle has been turned off";
                    //SpeechSynthesizer synthes2 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    //await recognizer.StartContinuousRecognitionAsync();
                    //Button.Text = "Stop";
                    //synthes.SpeakAsync(textToSpeak);//异步
                    break;
                case "AirconditionOn":
                    Aircondition.Image = Resource.AirconditionOn;
                    textToSpeak = "The airconditoner has been turned on.";
                    //SpeechSynthesizer synthes3 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    break;
                case "AirconditionOff":
                    Aircondition.Image = Resource.AirconditionOff;
                    textToSpeak = "The airconditioner has been turned off";
                    //SpeechSynthesizer synthes4 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    break;
                case "WaveovenOn":
                    Waveoven.Image = Resource.WaveovenOn;
                    textToSpeak = "The microwave oven has been turned on.";
                    //SpeechSynthesizer synthes5 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    break;
                case "WaveovenOff":
                    Waveoven.Image = Resource.WaveovenOff;
                    textToSpeak = "The microwave oven has been turned off";
                    //SpeechSynthesizer synthes6 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    break;
                case "LightOn":
                    Light.Image = Resource.LightOn;
                    textToSpeak = "The light has been turned on.";
                    //SpeechSynthesizer synthes7 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    break;
                case "LightOff":
                    Light.Image = Resource.LightOff;
                    textToSpeak = "The light has been turned off.";
                    //SpeechSynthesizer synthes8 = new SpeechSynthesizer();
                    synthes1.Speak(textToSpeak);//同步
                    break;
                case "AllOn":
                    Light.Image = Resource.LightOn;
                    Waveoven.Image = Resource.WaveovenOn;
                    Aircondition.Image = Resource.AirconditionOn;
                    Heater.Image = Resource.HeaterOn;
                    textToSpeak = "All devices have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "AllOff":
                    Light.Image = Resource.LightOff;
                    Waveoven.Image = Resource.WaveovenOff;
                    Aircondition.Image = Resource.AirconditionOff;
                    Heater.Image = Resource.HeaterOff;
                    textToSpeak = "All devices have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "AirconditionAndHeaterOn":
                    Aircondition.Image = Resource.AirconditionOn;
                    Heater.Image = Resource.HeaterOn;
                    textToSpeak = "Airconditioner and kettle have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "AirconditionAndHeaterOff":
                    Aircondition.Image = Resource.AirconditionOff;
                    Heater.Image = Resource.HeaterOff;
                    textToSpeak = "Airconditioner and kettle have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "AirconditionAndWaveovenOn":
                    Aircondition.Image = Resource.AirconditionOn;
                    Waveoven.Image = Resource.WaveovenOn;
                    textToSpeak = "Airconditioner and microwave oven have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "AirconditionAndWaveovenOff":
                    Aircondition.Image = Resource.AirconditionOff;
                    Waveoven.Image = Resource.WaveovenOff;
                    textToSpeak = "Airconditioner and microwave oven have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "HeaterAndWaveovenOn":
                    Heater.Image = Resource.HeaterOn;
                    Waveoven.Image = Resource.WaveovenOn;
                    textToSpeak = "Kettle and microwave oven have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "HeaterAndWaveovenOff":
                    Heater.Image = Resource.HeaterOff;
                    Waveoven.Image = Resource.WaveovenOff;
                    textToSpeak = "Kettle and microwave oven have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "LightAndAirconditionOn":
                    Light.Image = Resource.LightOn;
                    Aircondition.Image = Resource.AirconditionOn;
                    textToSpeak = "Light and airconditioner have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "LightAndAirconditionOff":
                    Light.Image = Resource.LightOff;
                    Aircondition.Image = Resource.AirconditionOff;
                    textToSpeak = "Light and airconditioner have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "LightAndHeaterOn":
                    Light.Image = Resource.LightOn;
                    Heater.Image = Resource.HeaterOn;
                    textToSpeak = "Light and kettle have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "LightAndHeaterOff":
                    Light.Image = Resource.LightOff;
                    Heater.Image = Resource.HeaterOff;
                    textToSpeak = "Light and kettle have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "LightAndWaveovenOn":
                    Light.Image = Resource.LightOn;
                    Waveoven.Image = Resource.WaveovenOn;
                    textToSpeak = "Light and microwave oven have been turned on.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "LightAndWaveovenOff":
                    Light.Image = Resource.LightOff;
                    Waveoven.Image = Resource.WaveovenOff;
                    textToSpeak = "Light and microwave oven have been turned off.";
                    synthes1.Speak(textToSpeak);
                    break;
                case "None":
                    Log("None\n");
                   
                    break;
                default:
                    Log("Switch clause should not be here.\n");
                    break;
            }

        }

        // 第二步
        // 调用语言理解服务取得用户意图

        private async Task<string> GetLuisResult(string text)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // LUIS 终结点地址, 示例: https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/102f6255-0c32-4f36-9c79-fe12fea4d6c4?subscription-key=9004421650254a74876cf3c888b1d11f&verbose=true&timezoneOffset=0&q=
                // 可在 https://www.luis.ai 中进入app右上角publish中找到

                // 采用自定义的语言理解模型
                string luisEndpoint = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/486fbd29-dd13-4ddb-bd2c-59195138c4b8?subscription-key=8439431b515c408296f44ad9b0688fb3&verbose=true&timezoneOffset=0&q=";
                string luisJson = await httpClient.GetStringAsync(luisEndpoint + text);

                try
                {
                    dynamic result = JsonConvert.DeserializeObject<dynamic>(luisJson);
                    string intent = (string)result.topScoringIntent.intent;
                    double score = (double)result.topScoringIntent.score;
                    //string entity = (string)result.entities.entity;
                    //double score2 = (double)result.entities.score;

                    Log("意图: " + intent + "\r\n得分: " + score + "\r\n");
                    //Log("实体: " + entity + "\r\n得分: " + score2 + "\r\n");
                    
                    return intent;
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    return null;
                }
            }
        }


        #region 界面操作

        private void Log(string message)
        {
            MakesureRunInUI(() =>
            {
                textbox.AppendText(message + "\r\n");
            });
        }

        private void OpenHeater()
        {
            MakesureRunInUI(() =>
            {
                Heater.Image = Resource.HeaterOn;
            });
        }

        private void CloseHeater()
        {
            MakesureRunInUI(() =>
            {
                Heater.Image = Resource.HeaterOff;
            });
        }

        private void OpenAircondition()
        {
            MakesureRunInUI(() =>
            {
                Aircondition.Image = Resource.AirconditionOn;
            });
        }

        private void CloseAircondition()
        {
            MakesureRunInUI(() =>
            {
                Aircondition.Image = Resource.AirconditionOff;
            });
        }

        private void OpenWaveoven()
        {
            MakesureRunInUI(() =>
            {
                Waveoven.Image = Resource.WaveovenOn;
            });
        }

        private void CloseWaveoven()
        {
            MakesureRunInUI(() =>
            {
                Waveoven.Image = Resource.WaveovenOff;
            });
        }

        private void OpenLight()
        {
            MakesureRunInUI(() =>
            {
                Light.Image = Resource.LightOn;
            });
        }

        private void CloseLight()
        {
            MakesureRunInUI(() =>
            {
                Light.Image = Resource.LightOff;
            });
        }

        private void MakesureRunInUI(Action action)
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(action);
                Invoke(action, null);
            }
            else
            {
                action();
            }
        }

        #endregion

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && sender is TextBox)
            {
                TextBox textBox = sender as TextBox;
                e.Handled = true;
                Log(textBox.Text);
                ProcessTransResult(textBox.Text);
                textBox.Text = string.Empty;
            }
        }
    }
}
