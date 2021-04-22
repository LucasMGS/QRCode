enum Validacao { Validado, Dispensado, Nenhum }

String enumToString(Validacao validacao) {
  switch (validacao) {
    case Validacao.Dispensado:
      return 'dispensado';
    case Validacao.Nenhum:
      return 'nenhum';
    case Validacao.Validado:
      return 'validado';
  }
}

Validacao stringToEnum(String string) {
  switch (string) {
    case 'dispensado':
      return Validacao.Dispensado;
    case 'nenhum':
      return Validacao.Nenhum;
    case 'validado':
      return Validacao.Validado;
    default:
      return Validacao.Nenhum;
  }
}
