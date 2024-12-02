using UnityEngine;
using System.Collections;
using NeuralNetwork;
using UnityEngine.UI;
using System.Collections.Generic;

public class ColorPicking : MonoBehaviour
{
    // Neural Network Variables
    private const double MinimumError = 0.01;
    private const TrainingType TrType = TrainingType.MinimumError;
    private static NeuralNet net;
    private static List<DataSet> dataSets;

    public Image I1;
    public Image I2;
    public Image I3;

    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;

    bool trained;

    int i = 0;

    // Use this for initialization
    void Start()
    {
        // Input - 3 (r,g,b) -- Output - 3 (Red, Green, Blue)
        net = new NeuralNet(3, 4, 3); // 3 outputs (for red, green, and blue)
        dataSets = new List<DataSet>();
        Next();
    }

    void Next()
    {
        Color c = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        I1.color = c;
        I2.color = c;
        I3.color = c;
        double[] C = { (double)I1.color.r, (double)I1.color.g, (double)I1.color.b };

        if (trained)
        {
            double[] d = tryValues(C);
            if (d[0] > d[1] && d[0] > d[2]) // Red
            {
                pointer1.SetActive(true);
                pointer2.SetActive(false);
                pointer3.SetActive(false);
            }
            else if (d[1] > d[0] && d[1] > d[2]) // Green
            {
                pointer1.SetActive(false);
                pointer2.SetActive(true);
                pointer3.SetActive(false);
            }
            else // Blue
            {
                pointer1.SetActive(false);
                pointer2.SetActive(false);
                pointer3.SetActive(true);
            }
        }
    }

    public void Train(float val)
    {
        double[] C = { (double)I1.color.r, (double)I1.color.g, (double)I1.color.b };
        double[] v = { 0, 0, 0 };

        // Set the output based on which color is dominant
        if (val == 1) v[0] = 1; // Red
        else if (val == 2) v[1] = 1; // Green
        else if (val == 3) v[2] = 1; // Blue

        dataSets.Add(new DataSet(C, v));

        i++;
        if (!trained && i % 10 == 9)
            Train();

        Next();
    }

    private void Train()
    {
        net.Train(dataSets, MinimumError);
        trained = true;
    }

    double[] tryValues(double[] vals)
    {
        return net.Compute(vals);
    }
}
