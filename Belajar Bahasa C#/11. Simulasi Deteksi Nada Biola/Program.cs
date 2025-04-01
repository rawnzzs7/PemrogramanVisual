using System;
using System.IO;
using System.Linq;
using System.Numerics; // Untuk FFT
using NAudio.Wave;

class Program
{
    static void Main()
    {
        Console.WriteLine("🔹 Sistem Analisis Nada Biola 🔹");
        Console.WriteLine("Tekan ENTER untuk mulai merekam...");
        Console.ReadLine();

        // perekaman dimulai
        using (var waveIn = new WaveInEvent())
        {
            waveIn.WaveFormat = new WaveFormat(44100, 16, 1); // 44.1 kHz, 16-bit, Mono
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.StartRecording();

            Console.WriteLine("Merekam... Tekan ENTER untuk berhenti.");
            Console.ReadLine();

            waveIn.StopRecording();
        }
    }

    static void OnDataAvailable(object sender, WaveInEventArgs e)
    {
        // mengambil data audio dari mikrofon
        byte[] buffer = e.Buffer;
        int bytesRecorded = e.BytesRecorded;
        int samples = bytesRecorded / 2; // 16-bit audio
        double[] audioSamples = new double[samples];

        // byte dikonversi menjadi sample audio
        for (int i = 0; i < samples; i++)
        {
            short sample = (short)(buffer[i * 2] | (buffer[i * 2 + 1] << 8)); // 16-bit PCM
            audioSamples[i] = sample / 32768.0; // normalisasi
        }

        // FFT untuk mendeteksi frekuensi dominan
        double detectedFrequency = GetDominantFrequency(audioSamples, 44100);
        string detectedNote = GetNoteFromFrequency(detectedFrequency);

        // tampilkan hasil
        Console.WriteLine($"Nada Terdeteksi: {detectedNote} ({detectedFrequency:F2} Hz)");

        // simpan hasil ke file
        SimpanHasil($"Nada: {detectedNote}, Frekuensi: {detectedFrequency:F2} Hz");
    }

    static double GetDominantFrequency(double[] audioSamples, int sampleRate)
    {
        int N = audioSamples.Length;
        Complex[] fftBuffer = new Complex[N];

        // masukkan nilai ke buffer FFT
        for (int i = 0; i < N; i++)
        {
            fftBuffer[i] = new Complex(audioSamples[i], 0);
        }

        // FFT
        FourierTransform(fftBuffer);

        // mencari frekuensi dengan amplitudo tertinggi
        double maxMagnitude = 0;
        int maxIndex = 0;
        for (int i = 0; i < N / 2; i++)
        {
            double magnitude = fftBuffer[i].Magnitude;
            if (magnitude > maxMagnitude)
            {
                maxMagnitude = magnitude;
                maxIndex = i;
            }
        }

        // hitung frekuensi dominan
        return maxIndex * sampleRate / (double)N;
    }

    static void FourierTransform(Complex[] buffer)
    {
        int N = buffer.Length;
        if (N <= 1) return;

        // array dipecah menjadi dua bagian
        Complex[] even = new Complex[N / 2];
        Complex[] odd = new Complex[N / 2];
        for (int i = 0; i < N / 2; i++)
        {
            even[i] = buffer[i * 2];
            odd[i] = buffer[i * 2 + 1];
        }

        FourierTransform(even);
        FourierTransform(odd);

        // hitung FFT
        for (int k = 0; k < N / 2; k++)
        {
            Complex t = Complex.Exp(-2 * Math.PI * Complex.ImaginaryOne * k / N) * odd[k];
            buffer[k] = even[k] + t;
            buffer[k + N / 2] = even[k] - t;
        }
    }

    static string GetNoteFromFrequency(double frequency)
    {
        string[] notes = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        double A4 = 440.0;
        int n = (int)Math.Round(12 * Math.Log2(frequency / A4));
        int noteIndex = (n + 9) % 12; // 9 karena A4 adalah index ke-9 di array
        return notes[noteIndex >= 0 ? noteIndex : noteIndex + 12];
    }

    static void SimpanHasil(string data)
    {
        string path = "data_nada.txt";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(data);
        }
    }
}
