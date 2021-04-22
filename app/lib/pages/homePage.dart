import 'dart:convert';

import 'package:app/widgets/itemsContainer.dart';
import 'package:flutter/material.dart';
import 'package:flutter_barcode_scanner/flutter_barcode_scanner.dart';
import '../models/QRCodeData.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  List<Item> items = [];

  Future<void> _scanQRCode() async {
    try {
      final qrCodeJson = await FlutterBarcodeScanner.scanBarcode(
        '#ff6666',
        'Cancelar',
        true,
        ScanMode.QR,
      );
      // print('qrcodeJson: $qrCodeJson');
      // print('decoded: ${json.decode(qrCodeJson)}');
      if (qrCodeJson != "-1") {
        setState(() {
          var item = Item.fromJson(json.decode(qrCodeJson));
          items.add(item);
        });
      }
    } catch (error) {
      print('Erro ao recuperar os dados: $error');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('QRCode Scanner'),
      ),
      body: items.isNotEmpty
          ? SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Padding(
                    padding: const EdgeInsets.only(left: 20, top: 20),
                    child: Text(
                      'Items',
                      style: TextStyle(fontSize: 20),
                    ),
                  ),
                  ItemsContainer(items: items),
                ],
              ),
            )
          : Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Center(
                  child: Container(
                    child: Text(
                      "Ainda não há nenhum item",
                      style: TextStyle(fontSize: 17),
                    ),
                  ),
                ),
                OutlinedButton(
                  style: OutlinedButton.styleFrom(
                      backgroundColor: Theme.of(context).primaryColor,
                      primary: Colors.white),
                  child: Text(
                    'Ler um QRCode',
                    style: TextStyle(fontWeight: FontWeight.bold),
                  ),
                  onPressed: _scanQRCode,
                ),
              ],
            ),
      floatingActionButton: FloatingActionButton(
        tooltip: 'Escanear um QRCode',
        onPressed: _scanQRCode,
        child: Icon(
          Icons.qr_code_scanner,
          color: Colors.black,
        ),
      ),
    );
  }
}
