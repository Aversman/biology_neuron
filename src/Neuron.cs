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
  public int Layer { get; set; }
  public int Limit { get; set; }
  public int[]? Synapses { get; set; }
  int output = 0;
  void ExecProcess(int[] input) {
    int counter = 0;
    if (Synapses == null) {
      throw new NeuronException("Synapses are not specified");
    }
    if (input.Length != Synapses.Length) {
      throw new NeuronException("Input word does not match synapses");
    }
    for (int i = 0; i < input.Length; i++) {
      if (Synapses[i] == 0 & input[i] == 1) {
        output = 0;
        return;
      }
      counter += input[i];
    }
    if (counter >= Limit) {
      output = 1;
      return;
    }
    output = 0;
  }
  public int GetOutput(int[] input) {
    ExecProcess(input);
    // Debug
    Console.WriteLine(output);
    return output;
  }
}