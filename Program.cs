using System.Text.Json;

class Program {
  static void Main() {
    string json = File.ReadAllText("input.json");
    Neuron[]? neurons = JsonSerializer.Deserialize<Neuron[]>(json);
    if (neurons == null) {
      throw new NeuronException("input data was not written");
    }
  }
}