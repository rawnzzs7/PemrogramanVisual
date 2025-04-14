using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class FruitData
{
    public float Diameter { get; set; }
    public float Weight { get; set; }
    public float Red { get; set; }
    public float Green { get; set; }
    public float Blue { get; set; }
    public string Name { get; set; }
}

public class FruitPrediction
{
    public float PredictedLabel { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Memuat data dari file Excel
        var context = new MLContext();
        var data = LoadData(context);

        // Mengonversi string kelas ke numerik
        var processedData = ProcessData(context, data);

        // Membagi data menjadi training dan testing
        var (trainData, testData) = context.Data.TrainTestSplit(processedData, testFraction: 0.2);

        // Melatih model
        var model = TrainModel(context, trainData);

        // Evaluasi model
        EvaluateModel(context, model, testData);

        // Simulasi prediksi
        SimulatePrediction(context, model);
    }

    // Membaca data dari file Excel (gunakan CSV sebagai contoh jika tidak bisa membaca Excel langsung)
    private static IDataView LoadData(MLContext context)
    {
        // Anda bisa mengganti dengan lokasi file CSV atau menggunakan library lain untuk membaca Excel
        string dataPath = "fruit.csv"; // Misalnya CSV

        // Membaca data ke dalam IDataView
        var data = context.Data.LoadFromTextFile<FruitData>(dataPath, separatorChar: ',', hasHeader: true);
        return data;
    }

    // Memproses data dan mengonversi label menjadi angka
    private static IDataView ProcessData(MLContext context, IDataView data)
    {
        var pipeline = context.Transforms.Conversion.MapValueToKey("Name")
                        .Append(context.Transforms.Concatenate("Features", "Diameter", "Weight", "Red", "Green", "Blue"));

        return pipeline.fit(data).Transform(data);
    }

    // Melatih model
    private static ITransformer TrainModel(MLContext context, IDataView trainData)
    {
        var trainer = context.MulticlassClassification.Trainers.LightGbm(labelColumnName: "Name", featureColumnName: "Features");
        var model = trainer.Fit(trainData);
        return model;
    }

    // Evaluasi model menggunakan test data
    private static void EvaluateModel(MLContext context, ITransformer model, IDataView testData)
    {
        var predictions = model.Transform(testData);
        var metrics = context.MulticlassClassification.Evaluate(predictions);

        Console.WriteLine($"Log-loss: {metrics.LogLoss}");
        Console.WriteLine($"Log-loss reduction: {metrics.LogLossReduction}");
    }

    // Simulasi prediksi pada data baru
    private static void SimulatePrediction(MLContext context, ITransformer model)
    {
        var sampleData = new FruitData
        {
            Diameter = 3.5f,
            Weight = 85.0f,
            Red = 160,
            Green = 85,
            Blue = 2
        };

        var predictor = context.Model.CreatePredictionEngine<FruitData, FruitPrediction>(model);
        var prediction = predictor.Predict(sampleData);
        Console.WriteLine($"Predicted label: {prediction.PredictedLabel}");
    }
}
