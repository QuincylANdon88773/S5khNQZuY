// 代码生成时间: 2025-10-01 01:52:23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.ML;
using Microsoft.ML.Data;

// 定义数据模型
public class ClusteringData
{
    [LoadColumn(0)]
    public float Feature1 { get; set; }

    [LoadColumn(1)]
    public float Feature2 { get; set; }

    [LoadColumn(2)]
    public float Feature3 { get; set; }

    [LoadColumn(3)]
    public float Label { get; set; }
}

// 定义聚类数据模型
public class ClusteringPrediction
{
    [ColumnName("PredictedLabel")]
    public uint PredictedClusterId { get; set; }
}

public partial class MainWindow : Window
{
    private MLContext mlContext;

    public MainWindow()
    {
        InitializeComponent();
        mlContext = new MLContext();
    }

    // 加载数据并进行聚类
    private void PerformClustering()
    {
        try
        {
            var dataPath = "data.csv";
            var clusteringData = mlContext.Data.LoadFromTextFile<ClusteringData>(dataPath, hasHeader: true, separatorChar: ',');

            var trainer = mlContext.Clustering.Trainers.KMeans()
                .NumberOfClusters(3); // 假设我们想要聚类到3个群集

            var trainingPipeline = mlContext.Clustering.Trainers.KMeans()
                .NumberOfClusters(3)
                .Append(mlContext.Transforms.Concatenate("Features", new string[] { "Feature1", "Feature2", "Feature3" }));

            var trainedModel = mlContext.Clustering.Train(trainingPipeline, clusteringData);

            // 将模型保存到文件系统
            var modelPath = "clusterModel.zip";
            mlContext.Model.Save(trainedModel, clusteringData.Schema, modelPath);

            MessageBox.Show("Clustering complete and model saved as: " + modelPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred during clustering: " + ex.Message);
        }
    }
}
