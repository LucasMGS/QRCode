import 'package:app/main.dart';
import 'package:app/models/QRCodeData.dart';
import 'package:app/enums/validacaoEnum.dart';
import 'package:flutter/material.dart';

class ItemsContainer extends StatefulWidget {
  final List<Item> items;

  const ItemsContainer({Key? key, required this.items}) : super(key: key);

  @override
  _ItemsContainer createState() => _ItemsContainer();
}

class _ItemsContainer extends State<ItemsContainer> {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      margin: EdgeInsets.all(20),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(6),
        border: Border.all(
          color: Colors.grey,
        ),
      ),
      child: ListView.separated(
          separatorBuilder: (_, __) => const Divider(thickness: 0.7),
          physics: ScrollPhysics(),
          shrinkWrap: true,
          itemCount: widget.items.length,
          itemBuilder: (_, index) {
            var item = widget.items[index];
            return ListTile(
              title: Text('Número: ${item.numItem}'),
              subtitle: Row(
                children: [
                  Text(
                    'Descrição:',
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: Colors.black,
                    ),
                  ),
                  SizedBox(width: 5),
                  Container(
                    width: 200,
                    child: Text(
                      item.itemDesc!,
                      overflow: TextOverflow.ellipsis,
                      softWrap: true,
                    ),
                  ),
                ],
              ),
              trailing: item.validacao == Validacao.Dispensado
                  ? Icon(
                      Icons.highlight_remove,
                      color: Colors.red,
                    )
                  : item.validacao == Validacao.Validado
                      ? Icon(Icons.check, color: Colors.green)
                      : Container(width: 0),
              onTap: () {
                showDialog(
                  context: context,
                  builder: (_) => AlertDialog(
                    scrollable: true,
                    title: Text('Item ${item.id}'),
                    content: Column(
                      children: ListTile.divideTiles(
                        context: context,
                        tiles: [
                          ListTile(
                            title: Text('Número'),
                            subtitle: Text('${item.numItem}'),
                          ),
                          ListTile(
                            title: Text('Descrição'),
                            subtitle: Text(item.itemDesc!),
                          ),
                          ListTile(
                            title: Text('Centro de custo'),
                            subtitle: Text(item.centroDeCusto!),
                          ),
                          ListTile(
                            title: Text('CIAP'),
                            subtitle: Text(item.ciap.toString()),
                          ),
                          ListTile(
                            title: Text('COFINS'),
                            subtitle: Text(item.cofins.toString()),
                          ),
                          ListTile(
                            title: Text('Data Entrada'),
                            subtitle: Text(item.dataEntrada!),
                          ),
                          ListTile(
                            title: Text('Data Emissão'),
                            subtitle: Text(item.dataEmissao!),
                          ),
                          ListTile(
                            title: Text('Fornecedor'),
                            subtitle: Text(item.fornecedor!),
                          ),
                          ListTile(
                            title: Text('Frota'),
                            subtitle: Text(item.frota!),
                          ),
                          ListTile(
                            title: Text('ICMS'),
                            subtitle: Text(item.icms.toString()),
                          ),
                          ListTile(
                            title: Text('Localizacao'),
                            subtitle: Text(item.localizacao!),
                          ),
                          ListTile(
                            title: Text('Nota fiscal de entrada'),
                            subtitle: Text(item.notaFiscalEntrada.toString()),
                          ),
                          ListTile(
                            title: Text('PIS'),
                            subtitle: Text(item.pis.toString()),
                          ),
                          ListTile(
                            title: Text('Sub-grupo'),
                            subtitle: Text(item.subGrupo!),
                          ),
                          ListTile(
                            title: Text('Taxa de apreciação'),
                            subtitle: Text(item.taxaApreciacao.toString()),
                          ),
                          ListTile(
                            title: Text('Valor da aquisição'),
                            subtitle: Text(item.valorAquisicao.toString()),
                          ),
                          ListTile(
                            title: Text('Vida útil estimada'),
                            subtitle: Text(item.vidaUtilEstimada.toString()),
                          ),
                        ],
                      ).toList(),
                    ),
                    actions: [
                      IconButton(
                        iconSize: 32,
                        color: Colors.red,
                        icon: Icon(Icons.highlight_off),
                        onPressed: () {
                          setState(() {
                            item.validacao = Validacao.Dispensado;
                          });
                          const snackbar = SnackBar(
                            content: Text('Item dispensado com sucesso!'),
                            backgroundColor: Colors.red,
                          );
                          ScaffoldMessenger.of(context).showSnackBar(snackbar);
                          Navigator.pop(context);
                        },
                      ),
                      IconButton(
                        color: Colors.green,
                        iconSize: 32,
                        icon: Icon(Icons.check),
                        onPressed: () {
                          setState(() {
                            item.validacao = Validacao.Validado;
                          });
                          const snackbar = SnackBar(
                            content: Text('Item validado com sucesso!'),
                            backgroundColor: Colors.green,
                          );
                          ScaffoldMessenger.of(context).showSnackBar(snackbar);
                          Navigator.pop(context);
                        },
                      ),
                    ],
                  ),
                );
              },
            );
          }),
    );
  }
}
