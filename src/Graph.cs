class GraphException : Exception {
  public GraphException(string str) : base(str) {
    Console.WriteLine(str);
  }
}

class Graph {
  Neuron[]? neurons;
  // Входные слова за все итерации
  int[,] inputs;
  // Количество итераций
  int n;
  public int Result;
  public Graph(int n, int[,] inputs, Neuron[] neurons) {
    this.n = n;
    this.inputs = inputs;
    this.neurons = neurons;
    Result = 0;
    if (inputs == null) {
      throw new GraphException("Wrong input data");
    }
    if (neurons == null) {
      throw new GraphException("Wrong input data");
    }
    if (inputs.Length != n) {
      throw new GraphException("Wrong input data");
    }
  }
  void ExecProcess(int curTime) {
    if (neurons == null) throw new GraphException("Wrong input data");
    int cursor = 0;
    foreach (var neuron in neurons) {
      if (neuron.Synapses == null) throw new GraphException("Wrong input data");
      if (neuron.Connectors == null) throw new GraphException("Wrong input data");
      int[] inputWord = new int[neuron.Synapses.Length];
      int i;
      for (i = 0; i < neuron.Connectors.Length; i++) {
        inputWord[i] = neurons[neuron.Connectors[i]].Output;
      }
      int curPos;
      if (neuron.Synapses.Length > neuron.Connectors.Length) {
        for (curPos = i; curPos < neuron.Synapses.Length; curPos++) {
          inputWord[curPos] = inputs[curTime, cursor];
          cursor++;
        }
      }
      neuron.ExecProcess(inputWord);
    }
  }
  public void RunProcess() {
    for (int i = 0; i < n; i++) {
      ExecProcess(i);
    }
  }
}