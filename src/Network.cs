class NetworkException : Exception {
  public NetworkException(string str) : base(str) {
    Console.WriteLine(str);
  }
}

class Network {
  // Массив нейронов
  Neuron[]? neurons;
  // Входные слова за все итерации
  int[,] inputs;
  // Количество итераций
  int n;
  public Network(int n, int[,] inputs, Neuron[] neurons) {
    this.n = n;
    this.inputs = inputs;
    this.neurons = neurons;
    if (inputs == null) {
      throw new NetworkException("inputs data must not be null");
    }
  }
  // Синапсы сортируются. Сначала рассматриваются не висячие синапсы
  // Далее из входного слова по порядку заполняются висячие синапсы
  // Тем самым образуем входное слово для нейрона и выполняем его процесс
  void ExecProcess(int curTime) {
    if (neurons == null) throw new NetworkException("neurons data must not be null");
    int cursor = 0;
    foreach (var neuron in neurons) {
      if (neuron.Synapses == null) throw new NetworkException("Neuron.Synapses must not be null");
      if (neuron.Connectors == null) throw new NetworkException("Neuron.Connectors must not be null");
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