/*
  Синапсы: 1 - Возбуждающий, 0 - Замыкающий
  Если входы >= порога ? 1 : 0
  Если замыкающий равен 1, то возвращается 0 и остальное игнорируется
*/
class NeuronException : Exception {
  public NeuronException(string str) : base(str) {
    Console.WriteLine(str);
  }
}

sealed class Neuron {
  public int Limit { get; set; }
  public int[]? Synapses { get; set; }
  public int[]? Connectors { get; set; }
  public int Output = 0;
  public void ExecProcess(int[] input) {
    int counter = 0;
    if (Synapses == null) {
      throw new NeuronException("Synapses are not specified");
    }
    if (input.Length != Synapses.Length) {
      throw new NeuronException("Input word does not match synapses");
    }
    for (int i = 0; i < input.Length; i++) {
      if (Synapses[i] == 0 & input[i] == 1) {
        Output = 0;
        return;
      }
      counter += input[i];
    }
    if (counter >= Limit) {
      Output = 1;
      return;
    }
    Output = 0;
  }
}