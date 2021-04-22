import '../enums/validacaoEnum.dart';

class Item {
  int? id;
  String? imagem;
  int? numItem;
  String? grupo;
  String? subGrupo;
  String? centroDeCusto;
  String? itemDesc;
  String? localizacao;
  String? frota;
  int? taxaApreciacao;
  int? vidaUtilEstimada;
  int? notaFiscalEntrada;
  String? fornecedor;
  String? dataEntrada;
  String? dataEmissao;
  int? valorAquisicao;
  int? icms;
  int? cofins;
  int? pis;
  bool ciap;
  bool isValidated;
  Validacao validacao;

  Item({
    this.ciap = false,
    this.cofins,
    this.centroDeCusto,
    this.dataEmissao,
    this.dataEntrada,
    this.fornecedor,
    this.frota,
    this.grupo,
    this.icms,
    this.id,
    this.imagem,
    this.isValidated = false,
    this.itemDesc,
    this.localizacao,
    this.notaFiscalEntrada,
    this.numItem,
    this.pis,
    this.subGrupo,
    this.taxaApreciacao,
    this.valorAquisicao,
    this.vidaUtilEstimada,
    this.validacao = Validacao.Nenhum,
  });

  static Item fromJson(Map<String, dynamic> json) {
    return Item(
      centroDeCusto: json['CentroDeCusto'] ?? '',
      ciap: json['CIAP'] ?? false,
      id: json['Id'],
      cofins: json['COFINS'] ?? 0,
      dataEmissao: json['DataEmissao'] ?? '',
      dataEntrada: json['dataEntrada'] ?? '',
      fornecedor: json['Fornecedor'] ?? '',
      frota: json['Frota'] ?? '',
      grupo: json['Grupo'] ?? '',
      icms: json['ICMS'] ?? 0,
      imagem: json['Imagem'] ?? '',
      isValidated: json['IsValidated'] ?? false,
      itemDesc: json['ItemDesc'] ?? '',
      localizacao: json['Localizacao'] ?? '',
      notaFiscalEntrada: json['NotaFiscalEntrada'] ?? 0,
      numItem: json['NumItem'] ?? 0,
      pis: json['PIS'] ?? 0,
      subGrupo: json['SubGrupo'] ?? '',
      taxaApreciacao: json['TaxaApreciacao'] ?? 0,
      valorAquisicao: json['ValorAquisicao'] ?? 0,
      vidaUtilEstimada: json['VidaUtilEstimada'] ?? 0,
    );
  }
}
