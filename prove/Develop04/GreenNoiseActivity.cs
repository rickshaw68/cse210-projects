using System;
using System.Diagnostics;
using System.Threading;

public class GreenNoiseActivity : Activity
{
    public GreenNoiseActivity()
    {
        Console.Clear();
        OpeningMessage();
        Console.WriteLine();
        Console.WriteLine("This activity will help you relax by listening to nature sounds (birds chirping and creek).");
        Console.WriteLine("This activity is best experienced by using headphones if possible.");
        Console.WriteLine();
        PromptForTime();
        CountDown(5);
        Console.WriteLine("Press Enter to start the nature sounds...");
        Console.ReadLine(); // User has to press enter to begin
        PlayNatureSounds(GetActivityTime());
        CompleteMessage(5);
    }

    private void PlayNatureSounds(int duration)
    {
        Console.Clear();
        Console.WriteLine("Playing Nature Sounds...");
        string natureSoundsPath = "nature_sounds.wav"; // Path to the audio file

        // Run audio playback and spinner concurrently using threading
        Thread audioThread = new Thread(() => PlayAudio(natureSoundsPath, duration)); //audio
        Thread spinnerThread = new Thread(() => ShowSpinner(duration)); //spinner

        audioThread.Start();
        spinnerThread.Start();

        audioThread.Join();
        spinnerThread.Join();
    }

    private void PlayAudio(string filePath, int duration) //plays audio after determining system OS (Windows, MAC, Linux)
    {
        string command;
        ProcessStartInfo processStartInfo;
        Process process;

        if (Environment.OSVersion.Platform == PlatformID.Win32NT) // Windows OS
        {
            // Windows using PowerShell to play audio
            command = $"(New-Object Media.SoundPlayer '{filePath}').PlaySync()";
            processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-NoProfile -Command \"{command}\"",
                RedirectStandardOutput = false,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
        }
        else if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
        {
            // macOS 
            if (Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                command = $"afplay '{filePath}'"; //using MAC afplay for audio
            }
            else // Linux
            {
                command = $"aplay '{filePath}'"; //using LINUX aplay for audio
            }

            processStartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{command}\"",
                RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = true,
            };
        }
        else
        {
            throw new NotSupportedException("Sorry, your Operating System is not supported."); //message for unsupported OS
        }

        process = new Process { StartInfo = processStartInfo };
        process.Start();

        // Wait for the specified duration and then kill the process.  This ensures that the audio will end once the user specified
        // time is done.
        Thread.Sleep(duration * 1000);
        if (!process.HasExited)
        {
            process.Kill();
        }

        process.WaitForExit();
        process.Dispose();
    }    
}
