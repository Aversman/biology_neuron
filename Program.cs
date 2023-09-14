using System.Text.Json;

class Program {
  static void Main() {
    string json = File.ReadAllText("input.json");
    Neuron[]? neurons = JsonSerializer.Deserialize<Neuron[]>(json);
    if (neurons == null) {
      throw new NeuronException("input data was not written");
    }
    // Количество тактов
    int n = 3;
    // Входные данные
    int[,] data = {
      {0, 1, 1, 0},
      {0, 0, 1, 1},
      {1, 0, 1, 0}
    };

    Network net = new Network(n, data, neurons);
    net.RunProcess();

    for (int i = 0; i < neurons.Length; i++) {
      Console.WriteLine("Neuron #" + i + ": " + neurons[i].Output);
    }
  }
}